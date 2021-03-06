﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class frmDigAnalysis : Window
    {
        public frmDigAnalysis()
        {
            InitializeComponent();
        }

        #region 窗口标题栏
        /// <summary>
        /// 拖动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        int i = 0;
        /// <summary>
        /// 标题栏双击事件
        /// </summary>
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i += 1;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; i = 0; };
            timer.IsEnabled = true;

            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;
                this.WindowState = this.WindowState == WindowState.Maximized ?
                              WindowState.Normal : WindowState.Maximized;
            }
        }

        /// <summary>
        /// 窗口最小化
        /// </summary>
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //设置窗口最小化
        }

        /// <summary>
        /// 窗口最大化与还原
        /// </summary>
        private void btn_max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                this.WindowState = WindowState.Maximized; //设置窗口最大化
            }
        }

        #endregion
 


        private void buton_ToggleClick4(object sender, RoutedEventArgs e)
        {

        }


        private void btn1_check(object sender, RoutedEventArgs e)
        {
            btn2.IsChecked = false;
            btn3.IsChecked = false;
            btn5.IsChecked = false;
            BottomText.Visibility = System.Windows.Visibility.Visible;
        }

        private void btn1_uncheck(object sender, RoutedEventArgs e)
        {
            BottomText.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btn2_check(object sender, RoutedEventArgs e)
        {
            btn1.IsChecked = false;
            btn3.IsChecked = false;
            btn5.IsChecked = false;
            BottomText2.Visibility = System.Windows.Visibility.Visible;
        }

        private void btn2_uncheck(object sender, RoutedEventArgs e)
        {
            BottomText2.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btn3_check(object sender, RoutedEventArgs e)
        {
            btn2.IsChecked = false;
            btn1.IsChecked = false;
            btn5.IsChecked = false;
            BottomText3.Visibility = System.Windows.Visibility.Visible;
        }

        private void btn3_uncheck(object sender, RoutedEventArgs e)
        {
            BottomText3.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btn5_check(object sender, RoutedEventArgs e)
        {
            btn2.IsChecked = false;
            btn3.IsChecked = false;
            btn1.IsChecked = false;
 
        }

        private void btn5_uncheck(object sender, RoutedEventArgs e)
        {
 
        }
    }
}
