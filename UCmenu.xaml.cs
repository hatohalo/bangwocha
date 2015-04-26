using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using 帮我查.Common;
using 帮我查.Data;

// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace 帮我查
{
    /// <summary>
    /// 一个事件委托
    /// </summary>
    /// <param name="showname">被点击的显示名</param>
    /// <param name="showname">被点击的标记名</param>
    /// <param name="anniu">被点击的按钮</param>
    /// <param name="CS">其他参数</param>
    public delegate void dianji(UCmenu UC, string anniu, IDictionary<string, object> CS);

    public sealed partial class UCmenu : UserControl
    {
        #region 属性





        //private dianji djgo = null;
        ///// <summary>
        ///// 事件委托
        ///// </summary>
        //public dianji DJgo
        //{
        //    get
        //    {
        //        return djgo;
        //    }
        //    set
        //    {
        //        djgo = value;
        //    }
        //}

        //public static readonly DependencyProperty ShowNameProperty = DependencyProperty.Register("ShowName", typeof(string), typeof(UCmenu), new PropertyMetadata("未定义"));
        ///// <summary>
        ///// 显示名称
        ///// </summary>
        //public string ShowName
        //{
        //    get 
        //    {
        //        return (string)GetValue(ShowNameProperty);
        //    }
        //    set 
        //    {
        //        SetValue(ShowNameProperty, value);
        //    }
        //}

        //public static readonly DependencyProperty ShowMyInfoProperty = DependencyProperty.Register("ShowMyInfo", typeof(string), typeof(UCmenu), new PropertyMetadata("未定义说明", new PropertyChangedCallback(OnShowMyInfoChanged)));
        //private static void OnShowMyInfoChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (sender != null && sender is UCmenu)
        //    {
        //        UCmenu this_this = sender as UCmenu;
        //        this_this._info.Text = e.NewValue.ToString();

        //    } 
        //}
        ///// <summary>
        ///// 显示的说明
        ///// </summary>
        //public string ShowMyInfo
        //{
        //    get
        //    {
        //        return (string)GetValue(ShowMyInfoProperty);
        //    }
        //    set
        //    {
        //        SetValue(ShowMyInfoProperty, value);
                
        //    }
        //}

        //public static readonly DependencyProperty BiaoJiNameProperty = DependencyProperty.Register("BiaoJiName", typeof(string), typeof(UCmenu), new PropertyMetadata("test"));
        ///// <summary>
        ///// 英文标记名称
        ///// </summary>
        //public string BiaoJiName
        //{
        //    get
        //    {
        //        return (string)GetValue(BiaoJiNameProperty);
        //    }
        //    set
        //    {
        //        SetValue(BiaoJiNameProperty, value);
        //    }
        //}
        #endregion

        private double anniuTM = 0.05;
        private double zuoTM = 0.4;
        public UCmenu()
        {

            this.InitializeComponent();
       
            //小按钮背景透明
            _MenuANNIU_you.Background.Opacity = anniuTM;
            //大按钮色块颜色随机
            Color[] D_Background = new Color[] { Color.FromArgb(255, 112, 181, 255), Color.FromArgb(255, 255, 246, 74), Color.FromArgb(255, 168, 255, 17), Color.FromArgb(255, 255, 112, 112), 
                Color.FromArgb(255, 123, 124, 152), Color.FromArgb(255, 156, 179, 169), Color.FromArgb(255, 243, 193, 170), Color.FromArgb(255, 226, 146, 135), Color.FromArgb(255, 230, 64, 78), Color.FromArgb(255, 255, 166, 33)   };
            Random rd = new Random(DateTime.Now.Millisecond);
            int i = rd.Next(0, D_Background.Count() - 1);
            _MenuANNIU_zuo.Background = new SolidColorBrush(D_Background[i]);
            _MenuANNIU_zuo.Background.Opacity = zuoTM;
            //说明文字透明
            _MenuANNIU_zhong.Background.Opacity = 0.001;

            //边框透明 
            _biankuang.Background.Opacity = 0.05;

 
           
        }


 

        #region 特效

        private void _MenuANNIU_zuo_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_zuo.Background.Opacity = zuoTM;
        }

        private void _MenuANNIU_zuo_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_zuo.Background.Opacity = zuoTM;
        }

        private void _MenuANNIU_zuo_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int i = rd.Next(20,90);
            _MenuANNIU_zuo.Background.Opacity =  Convert.ToDouble(i)/100;
        }

        private void _MenuANNIU_zuo_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_zuo.Background.Opacity = zuoTM;
        }

        private void _MenuANNIU_zuo_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_zuo.Background.Opacity = zuoTM;
        }

        private void _MenuANNIU_zuo_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_zuo.Background.Opacity = zuoTM;
        }

        private void _MenuANNIU_zuo_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
     
            SampleDataItem sdi = this.DataContext as SampleDataItem;
            dianji djgo = sdi.djDelegate;
            if (djgo != null)
            { djgo(this, "进入功能", null); }
           
        }

        private void Image_PointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int i = rd.Next(20, 90);
            _MenuANNIU_you.Background.Opacity = Convert.ToDouble(i) / 100;
        }

        private void Image_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            SampleDataItem sdi = this.DataContext as SampleDataItem;
            dianji djgo = sdi.djDelegate;
            if (djgo != null)
            { djgo(this, "右上", null); }
        }

        private void Image_PointerCanceled_1(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerCaptureLost_1(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerEntered_1(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerExited_1(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerMoved_1(object sender, PointerRoutedEventArgs e)
        {
            _MenuANNIU_you.Background.Opacity = anniuTM;
        }

        private void Image_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        {
            Random rd = new Random(DateTime.Now.Millisecond);
            int i = rd.Next(20, 90);
            _MenuANNIU_you.Background.Opacity = Convert.ToDouble(i) / 100;
        }

        private void Image_PointerReleased_1(object sender, PointerRoutedEventArgs e)
        {
            SampleDataItem sdi = this.DataContext as SampleDataItem;
            dianji djgo = sdi.djDelegate;
            if (djgo != null)
            { djgo(this, "右下", null); }
        }

        #endregion


    }
}
