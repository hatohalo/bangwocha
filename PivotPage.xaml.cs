using Hatohalo.HttpNet;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Store;
using Windows.Media.SpeechRecognition;
using Windows.Phone.UI.Input;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.System.Profile;
using Windows.System.Threading;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using 帮我查.Common;
using 帮我查.Data;

// “透视应用程序”模板在 http://go.microsoft.com/fwlink/?LinkID=391641 上有介绍

namespace 帮我查
{


    public sealed partial class PivotPage : Page
    {
 
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// 延时线程计时器
        /// </summary>
        private ThreadPoolTimer _timer;
        public PivotPage()
        {




            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

             //数据源绑定
            BangdingRun();

        }


        private async void InitBG()
        {
            try
            {
                StorageFile file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/bg002.png"));
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                IStorageFolder ISF = ApplicationData.Current.LocalFolder;
                await file.CopyAsync(ISF, "mybg.png", NameCollisionOption.ReplaceExisting);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(fileStream);
                ImageBrush ib = new ImageBrush();
                ib.Stretch = Stretch.UniformToFill;
                ib.ImageSource = bitmapImage;
                this.Background = ib;
            }
            catch { }
 
        }
        /// <summary>
        /// 逐个选项卡绑定菜单
        /// </summary>
        private async void BangdingRun()
        {
            bool gogo_InitBG = false;
            try
            {
                //设置背景
                StorageFile fileBG = await ApplicationData.Current.LocalFolder.GetFileAsync("mybg.png");
                IRandomAccessStream fileStream = await fileBG.OpenAsync(Windows.Storage.FileAccessMode.Read);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(fileStream);
                ImageBrush ib = new ImageBrush();
                ib.Stretch = Stretch.UniformToFill;
                ib.ImageSource = bitmapImage;
                this.Background = ib;
           
            }
            catch {
                gogo_InitBG = true;
            }
            if (gogo_InitBG)
            {
                InitBG();
            }
         
           
            //常用
            SampleDataGroup db1 = await SampleDataSource.GetGroupAsync("Group-1");
            Bangding(db1, _LV_changyongA);
            //生活
            SampleDataGroup db2 = await SampleDataSource.GetGroupAsync("Group-2");
            Bangding(db2, _LV_shenghuoB);
            //技术
            SampleDataGroup db3 = await SampleDataSource.GetGroupAsync("Group-3");
            Bangding(db3, _LV_jishu);
            //定制
            SampleDataGroup db4 = await SampleDataSource.GetGroupAsync("Group-4");
            Bangding(db4, _LV_dingzhi);
 
        }

        /// <summary>
        /// 绑定某个选项卡，同时把事件回调放入属性中
        /// </summary>
        /// <param name="db"></param>
        /// <param name="lv"></param>
        private  void Bangding(SampleDataGroup db,ListView lv)
        {
            
            dianji D = new dianji(dianjiGOGOGO);
            foreach (SampleDataItem IT in db.Items)
            {
                IT.djDelegate = D;
            }
            lv.DataContext = db;
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
        /// 使用在导航过程中传递的内容填充页。在从以前的会话
        /// 重新创建页时，也会提供任何已保存状态。
        /// </summary>
        /// <param name="sender">
        /// 事件的来源；通常为 <see cref="NavigationHelper"/>。
        /// </param>
        /// <param name="e">事件数据，其中既提供在最初请求此页时传递给
        /// <see cref="Frame.Navigate(Type, Object)"/> 的导航参数，又提供
        /// 此页在以前会话期间保留的状态的
        /// 的字典。首次访问页面时，该状态将为 null。</param>
        private  void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: 创建适用于问题域的合适数据模型以替换示例数据


            //发送统计用户行为埋点
            Begin_tongji("首页");

            try
            {
                //处理磁贴进入
                CheckTile(e.NavigationParameter);

                //处理语音指令
                CheckVoicCommandToDoWhat();

                //处理选择背景图片
                CheckOpenPickerToDoWhat();
            }
            catch { }
    
        }

        /// <summary>
        /// 保留与此页关联的状态，以防挂起应用程序或
        /// 从导航缓存中放弃此页。值必须符合序列化
        /// <see cref="SuspensionManager.SessionState"/> 的序列化要求。
        /// </summary>
        /// <param name="sender">事件的来源；通常为 <see cref="NavigationHelper"/>。</param>
        ///<param name="e">提供要使用可序列化状态填充的空字典
        ///的事件数据。</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: 在此处保存页面的唯一状态。
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
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //注册语音指令配置文件
            if (e.NavigationMode == NavigationMode.New)
            {
                try
                {
                    var storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///ChineseVoiceCommandDefinition_8.1.xml"));
                    await Windows.Media.SpeechRecognition.VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(storageFile);
                }
                catch
                { }
             
            }


 
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

        /// <summary>
        /// 开始发送使用信息
        /// </summary>
        /// <param name="mod"></param>
        private async void Begin_tongji_Run(string mod)
        {
            try
            {
                ClassHttp CH = new ClassHttp();
                CH.HttpURL = URLSTR.tongji;
                IDictionary<string, string> CS = new Dictionary<string, string>();
                //可选参数，但如果要获取的地址不是网页，而是一个文件或图片，服务器一般默认配置不接受Post进而导致无法获取到。
                //直接使用图片地址的，不要设置这个参数，避免使用Post方式，直接传递null。

                HardwareToken hardwareToken = HardwareIdentification.GetPackageSpecificToken(null);
                EasClientDeviceInformation easClientDeviceInformation = new EasClientDeviceInformation();


                CS["mod"] = mod;
                CS["hardwareToken_Id"] = Buffer2Base64(hardwareToken.Id);
                CS["hardwareToken_Signature"] = Buffer2Base64(hardwareToken.Signature);
                CS["hardwareToken_Certificate"] = Buffer2Base64(hardwareToken.Certificate);
                CS["easClientDeviceInformation_Version"] = "固件版本:" + easClientDeviceInformation.SystemFirmwareVersion + "★硬件版本:" + easClientDeviceInformation.SystemHardwareVersion;
                CS["easClientDeviceInformation_FriendlyName"] = easClientDeviceInformation.FriendlyName;
                CS["easClientDeviceInformation_OperatingSystem"] = easClientDeviceInformation.OperatingSystem;
                CS["easClientDeviceInformation_SystemManufacturer"] = easClientDeviceInformation.SystemManufacturer;
                CS["easClientDeviceInformation_SystemProductName"] = easClientDeviceInformation.SystemProductName;
                IDictionary<string, object> RE = await CH.LoadHttpText(CS);
            }
            catch(Exception exx)
            { }
       
 
        }

        /// <summary>
        /// 延时发送使用信息，实际上是开线程处理，即使页面跳转，延迟到了也会进行处理
        /// </summary>
        /// <param name="mod"></param>
        private void Begin_tongji(string mod)
        {
            //
            _timer = ThreadPoolTimer.CreateTimer(
                (timer) =>
                {
                    var ignored = Dispatcher.RunAsync(CoreDispatcherPriority.High,
                        () =>
                        {
                            //;
                     
                        });
                },
                TimeSpan.FromMilliseconds(200),
                (timer) =>
                {
                    var ignored = Dispatcher.RunAsync(CoreDispatcherPriority.High,
                        () =>
                        {
                            //;
                            Begin_tongji_Run(mod);
                        });
                });
        }

        /// <summary>
        /// 选择背景图片后的一些处理
        /// </summary>
        private async void CheckOpenPickerToDoWhat()
        {
            if (PublicS.commandArgs_PickFile == null)
            {
                return;
            }
            FileOpenPickerContinuationEventArgs commandArgs_PickFile_thisone = PublicS.commandArgs_PickFile;
            PublicS.commandArgs_PickFile = null;
            if ((commandArgs_PickFile_thisone.ContinuationData["Operation"] as string) == "bjtp" &&
                commandArgs_PickFile_thisone.Files.Count > 0)
            {
                StorageFile file = commandArgs_PickFile_thisone.Files[0];
                IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                
                IStorageFolder ISF = ApplicationData.Current.LocalFolder;
                await file.CopyAsync(ISF, "mybg.png", NameCollisionOption.ReplaceExisting);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(fileStream);
                ImageBrush ib = new ImageBrush();
                ib.Stretch = Stretch.UniformToFill;
                ib.ImageSource = bitmapImage;
                this.Background = ib;
               
            }
        }
 
        /// <summary>
        /// 根据参数处理桌面磁贴的进入
        /// </summary>
        /// <param name="CS"></param>
        private void CheckTile(object CS)
        {
            if (CS == null || CS.ToString().Trim() == "")
            {
                return;
            }
            Type T = Type.GetType("帮我查." + CS.ToString());
            if (T != null)
            {
                Begin_tongji("磁贴进入." + CS.ToString());
                Frame.Navigate(T, "");
            }


        }

        /// <summary>
        /// 检查是否通过语音命令要做一些事情
        /// </summary>
        private async void CheckVoicCommandToDoWhat()
        {
            if (PublicS.commandArgs == null)
            {
                return;
            }
            VoiceCommandActivatedEventArgs commandArgs_thisone = PublicS.commandArgs;
            PublicS.commandArgs = null;
            SpeechRecognitionResult speechRecognitionResult = commandArgs_thisone.Result;
            string navigationTarget = speechRecognitionResult.SemanticInterpretation.Properties["NavigationTarget"][0];
            Begin_tongji(navigationTarget + "[来自小娜]");
            if (navigationTarget.IndexOf("特殊:") >= 0)
            {
                switch (navigationTarget)
                {
                    case "特殊:百度搜索":
          
                        Windows.System.LauncherOptions lo = new Windows.System.LauncherOptions();
                        lo.TreatAsUntrusted = false;
                        await Windows.System.Launcher.LaunchUriAsync(new Uri("http://www.baidu.com/s?wd=" + speechRecognitionResult.Text.Replace("度娘", "").Replace("百度", "")), lo);
                        break;
                    case "特殊:百度百科搜索":

                        Windows.System.LauncherOptions lo2 = new Windows.System.LauncherOptions();
                        lo2.TreatAsUntrusted = false;
                        await Windows.System.Launcher.LaunchUriAsync(new Uri("http://baike.baidu.com/search?word=" + speechRecognitionResult.Text.Replace("百度百科", "")), lo2);
                        break;
                    case "特殊:维基百科搜索":

                        Windows.System.LauncherOptions lo3 = new Windows.System.LauncherOptions();
                        lo3.TreatAsUntrusted = false;
                        await Windows.System.Launcher.LaunchUriAsync(new Uri("http://zh.wikipedia.org/w/index.php?search=" + speechRecognitionResult.Text.Replace("维基百科", "")), lo3);
                        break;
                    default:
                        break;
                } 
            }
            else
            {
                Type TT = Type.GetType(navigationTarget);
                Frame.Navigate(TT, commandArgs_thisone);
            }
     
            
        }

        private void _zhuye_Loaded(object sender, RoutedEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;


             

        }

        private void _zhuye_Unloaded(object sender, RoutedEventArgs e)
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
            Application.Current.Exit();

        }


        private void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(test), null);
        }
 

        /// <summary>
        /// 控件的点击事件相应
        /// </summary>
        /// <param name="showname"></param>
        /// <param name="anniu"></param>
        /// <param name="CS"></param>
        private async void dianjiGOGOGO(UCmenu UC, string anniu, IDictionary<string, object> CS)
        {
            switch (anniu)
            {
                case "进入功能":
                    SampleDataItem sdi = UC.DataContext as SampleDataItem;
                    Type T = Type.GetType("帮我查." + sdi.UniqueId);
                    if (T != null)
                    {
                        Begin_tongji(sdi.UniqueId);
                        Frame.Navigate(T, "");
                    }
                    else
                    {
                        Frame.Navigate(Type.GetType("帮我查.test"), null);
                    }
                    
               
                    break;
                case "右上":
                    await new MessageDialog("预览版此功能不可用，晚些时候更新。").ShowAsync();
                    break;
                case "右下":
                    await new MessageDialog("预览版此功能不可用，晚些时候更新。").ShowAsync();
                    break;
                default:
                    break;
            }

           

        }

        private async void AddAppBarButton2_Click(object sender, RoutedEventArgs e)
        {
 
            await Windows.System.Launcher.LaunchUriAsync(new Uri("zune:reviewapp?appid=" + CurrentApp.AppId)); 
        }

        private void AddAppBarButton4_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(jianyi), null);
        }

        private void AddAppBarButton1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(gengxinjihua), null);
        }

        private void xiaonashuoming_Click(object sender, RoutedEventArgs e)
        {
            
            Frame.Navigate(typeof(xiaonashuoming), null);
             
        }
 
        private void bg_chunse_Click(object sender, RoutedEventArgs e)
        {
          
            InitBG();
           

 
        }

        private void bg_tuian_Click(object sender, RoutedEventArgs e)
        {
 
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");
            picker.ContinuationData["Operation"] = "bjtp";
            picker.PickSingleFileAndContinue();
            
           
        }

       

 
    }
}
