using 帮我查.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Activation;
using Windows.Media.SpeechRecognition;
using Windows.Phone.UI.Input;
using Hatohalo.HttpNet;
using Windows.Storage;
using Windows.UI.StartScreen;
using Windows.UI;

// “基本页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

namespace 帮我查
{
    /// <summary>
    /// 可独立使用或用于导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SUBmain_gongzi : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public SUBmain_gongzi()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// 获取与此 <see cref="Page"/> 关联的 <see cref="NavigationHelper"/>。
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// 获取此 <see cref="Page"/> 的视图模型。
        /// 可将其更改为强类型视图模型。
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// 使用在导航过程中传递的内容填充页。  在从以前的会话
        /// 重新创建页时，也会提供任何已保存状态。
        /// </summary>
        /// <param name="sender">
        /// 事件的来源; 通常为 <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">事件数据，其中既提供在最初请求此页时传递给
        /// <see cref="Frame.Navigate(Type, Object)"/> 的导航参数，又提供
        /// 此页在以前会话期间保留的状态的
        /// 字典。 首次访问页面时，该状态将为 null。</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            if (e.NavigationParameter == null)
            {
                return;
            }

            if (e.NavigationParameter.GetType().Equals(typeof(string)))
            {
                string CS = e.NavigationParameter.ToString();
                this.DefaultViewModel["CS"] = CS;

                //处理浏览器
                _htmltianqiV.Source = new Uri("http://dp.sina.cn/dpool/tools/money/index.php?pos=63&vt=4");
                
            }
            if (e.NavigationParameter.GetType().Equals(typeof(VoiceCommandActivatedEventArgs)))
            {
                VoiceCommandActivatedEventArgs commandArgs_thisone = e.NavigationParameter as VoiceCommandActivatedEventArgs;
                SpeechRecognitionResult speechRecognitionResult = commandArgs_thisone.Result;

                string voiceCommandName = speechRecognitionResult.RulePath[0];
                string textSpoken = speechRecognitionResult.Text;
                string navigationTarget = speechRecognitionResult.SemanticInterpretation.Properties["NavigationTarget"][0];
       
                _htmltianqiV.Source = new Uri("http://dp.sina.cn/dpool/tools/money/index.php?pos=63&vt=4");

            }
        }

        /// <summary>
        /// 保留与此页关联的状态，以防挂起应用程序或
        /// 从导航缓存中放弃此页。值必须符合
        /// <see cref="SuspensionManager.SessionState"/> 的序列化要求。
        /// </summary>
        /// <param name="sender">事件的来源；通常为 <see cref="NavigationHelper"/></param>
        ///<param name="e">提供要使用可序列化状态填充的空字典
        ///的事件数据。</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper 注册

        /// <summary>
        /// 此部分中提供的方法只是用于使
        /// NavigationHelper 可响应页面的导航方法。
        /// <para>
        /// 应将页面特有的逻辑放入用于
        /// <see cref="NavigationHelper.LoadState"/>
        /// 和 <see cref="NavigationHelper.SaveState"/> 的事件处理程序中。
        /// 除了在会话期间保留的页面状态之外
        /// LoadState 方法中还提供导航参数。
        /// </para>
        /// </summary>
        /// <param name="e">提供导航方法数据和
        /// 无法取消导航请求的事件处理程序。</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _htmltianqiV.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            _loadquanquan.IsActive = true;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        private async void _htmltianqiV_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            try
            {
                //动态加载jquery
                Uri dataUri = new Uri("ms-appx:///DataModel/jquery-1.11.1.min.js");
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                string jqText = await FileIO.ReadTextAsync(file);
                await _htmltianqiV.InvokeScriptAsync("eval", new List<string> { jqText });
                await _htmltianqiV.InvokeScriptAsync("eval", new List<string> { ";var BWCJQ_haha= jQuery.noConflict();" });
                

                // 向 html 中注册脚本,删除不想让用户看到的东西
                List<string> arguments = new List<string> { "var ReSet_yhb_haha_num = 0; var ReSet_yhb_haha_interval = null;  function ReSet_yhb_haha(){ if(ReSet_yhb_haha_num > 20){clearInterval(ReSet_yhb_haha_interval)};   BWCJQ_haha(\".n1\").hide();  BWCJQ_haha(\".n2\").hide(); BWCJQ_haha(\".n2\").hide(); BWCJQ_haha(\".barw:contains('转发微博')\").hide(); BWCJQ_haha(\"a:contains('个人理财首页')\").hide();BWCJQ_haha(\"a:contains('外汇')\").hide(); BWCJQ_haha(\"h1\").hide();BWCJQ_haha(\".top\").hide(); BWCJQ_haha(\".foot\").hide();  return 'ok';}    function ReSet_yhb_haha_dingshi(){window.setInterval(ReSet_yhb_haha, 100); }" };
                await _htmltianqiV.InvokeScriptAsync("eval", arguments);

                // 调用刚刚注册的脚本
                string result1 = await _htmltianqiV.InvokeScriptAsync("ReSet_yhb_haha", null);
                string result2 = await _htmltianqiV.InvokeScriptAsync("ReSet_yhb_haha_dingshi", null);

         
            }
            catch (Exception ex)
            {
                ;
            }
            _loadquanquan.IsActive = false;
            _htmltianqiV.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void _htmltianqiV_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            _htmltianqiV.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            _loadquanquan.IsActive = true;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (_htmltianqiV.CanGoBack)
            {

                //进行浏览器后退
                _htmltianqiV.GoBack();
                //禁止返回的那种后退
                PublicS.CanBeBack = false;

            }
            else
            {
                //允许后退
                PublicS.CanBeBack = true;
            }


        }



        private void AddAppBarButton1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PivotPage), null);
        }

        private void AddAppBarButton2_Click(object sender, RoutedEventArgs e)
        {
            _htmltianqiV.Source = new Uri("http://dp.sina.cn/dpool/tools/money/index.php?pos=63&vt=4");
        }

        private async void Pin(string imageUriString, string ID, string showname)
        {
            Uri logo = new Uri(imageUriString); // 方块图块的 Logo

            // 创建一个 SecondaryTile 对象
            SecondaryTile secondaryTile = new SecondaryTile();
            secondaryTile.TileId = ID;
            secondaryTile.Arguments = ID;
            secondaryTile.DisplayName = showname;
            secondaryTile.VisualElements.ShowNameOnSquare150x150Logo = true;
            secondaryTile.VisualElements.ShowNameOnSquare310x310Logo = true;
            secondaryTile.VisualElements.BackgroundColor = Color.FromArgb(0, 0, 0, 0);
            secondaryTile.VisualElements.ForegroundText = ForegroundText.Light;
            secondaryTile.VisualElements.Square150x150Logo = logo;
            secondaryTile.LockScreenDisplayBadgeAndTileText = true;


            // 请求固定此 SecondaryTile，并指定确认框的显示位置
            bool isPinned = await secondaryTile.RequestCreateAsync();
        }
        private void citie_Click(object sender, RoutedEventArgs e)
        {

            Pin("ms-appx:///Assets/Square150x150Logo.scale-240.png", this.GetType().Name, "帮我查-工资");
        }
    }
}
