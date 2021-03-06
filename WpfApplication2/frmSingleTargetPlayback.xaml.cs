﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
    public partial class frmSingleTargetPlayback : Window
    {
        public frmSingleTargetPlayback()
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


        private void ButtonQuery_Click(object sender, RoutedEventArgs e)
        {
            if (StartTime.SelectedTime != null && EndTime.SelectedTime != null && StartDate.SelectedDate != null && EndDate.SelectedDate != null)
            {
                if (StartDate.SelectedDate <= EndDate.SelectedDate)
                {
                    if (StartDate.SelectedDate == EndDate.SelectedDate && StartTime.SelectedTime > EndTime.SelectedTime)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(500);
                        }).ContinueWith(t =>
                        {
                            MainSnackbar.MessageQueue.Enqueue("开始时间不能晚于结束时间!");
                        }, TaskScheduler.FromCurrentSynchronizationContext());

                        return;
                    }

                    if (((DateTime)EndDate.SelectedDate - (DateTime)StartDate.SelectedDate).TotalDays > 90)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(500);
                        }).ContinueWith(t =>
                        {
                            MainSnackbar.MessageQueue.Enqueue("时间范围不能超过三个月!");
                        }, TaskScheduler.FromCurrentSynchronizationContext());

                        return;
                    }

                    ///do some thing
                }
                else
                {
                    Task.Factory.StartNew(() =>
                    {
                        Thread.Sleep(500);
                    }).ContinueWith(t =>
                    {
                        MainSnackbar.MessageQueue.Enqueue("开始时间不能晚于结束时间!");
                    }, TaskScheduler.FromCurrentSynchronizationContext());

                    return;
                }

            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                }).ContinueWith(t =>
                {
                    MainSnackbar.MessageQueue.Enqueue("请先输入时间范围");
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //add BlackoutDates
            StartDate.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), new DateTime(2100, 1, 1)));
            EndDate.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), new DateTime(2100, 1, 1)));

            StartDate.SelectedDate = DateTime.Now.AddDays(-1).Date;
            StartDate.Text = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            EndDate.SelectedDate = DateTime.Now.Date;

            StartTime.SelectedTime = DateTime.Now;
            EndTime.SelectedTime = DateTime.Now;
        }
    }
}
