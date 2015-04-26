using Hatohalo.HttpNet;
using System;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Windows.System.Profile;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using 帮我查.Common;

// “基本页”项模板在 http://go.microsoft.com/fwlink/?LinkID=390556 上有介绍

namespace 帮我查
{
    /// <summary>
    /// 可独立使用或用于导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class jianyi : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public jianyi()
        {
            this.InitializeComponent();

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


        /// <summary>
        /// 用于设备信息的转换
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private string Buffer2Base64(IBuffer buffer)
        {
            if (buffer == null)
            {
                return "null";
            }
            using (var dataReader = DataReader.FromBuffer(buffer))
            {
                try
                {
                    var bytes = new byte[buffer.Length];
                    dataReader.ReadBytes(bytes);

                    return Convert.ToBase64String(bytes);
                }
                catch (Exception ex)
                {
                    return "nothing";
                }
            }
        }

        private async void _tj_Click(object sender, RoutedEventArgs e)
        {
            if (_tb2.Text.Trim() == "")
            {
                await new MessageDialog("你好!至少说点什么呗？").ShowAsync();
                return;
            }
            _tj.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            _tjing.IsActive = true;
    
            try
            {
               
                ClassHttp CH = new ClassHttp();
                CH.HttpURL = URLSTR.jianyi;
                IDictionary<string, string> CS = new Dictionary<string, string>();
                //可选参数，但如果要获取的地址不是网页，而是一个文件或图片，服务器一般默认配置不接受Post进而导致无法获取到。
                //直接使用图片地址的，不要设置这个参数，避免使用Post方式，直接传递null。

                HardwareToken hardwareToken = HardwareIdentification.GetPackageSpecificToken(null);

                CS["hardwareToken_Id"] = Buffer2Base64(hardwareToken.Id);
                CS["daming"] = _tb1.Text;
                CS["jianyi"] = _tb2.Text;
                IDictionary<string, object> RE = await CH.LoadHttpText(CS);
                string re = RE["返回内容"].ToString();
                await new MessageDialog(re).ShowAsync();
            }
            catch (Exception exx)
            { }
       
            _tj.Visibility = Windows.UI.Xaml.Visibility.Visible;
            _tjing.IsActive = false;

            Frame.Navigate(typeof(PivotPage), null);
           
        }
    }
}
