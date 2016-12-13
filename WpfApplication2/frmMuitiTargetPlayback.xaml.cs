using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class frmMuitiTargetPlayback : Window
    {
        public frmMuitiTargetPlayback()
        {
            InitializeComponent();
            lRST.Add(new Test3() { IsSelected = true, Name = "中国", Description = "df445655"});
            lRST.Add(new Test3() { IsSelected = false, Name = "英国", Description = "df44345" });
            lRST.Add(new Test3() { IsSelected = false, Name = "日本", Description = "df4434655" });
            lRST.Add(new Test3() { IsSelected = false, Name = "新加坡", Description = "df4677655" });
            lRST.Add(new Test3() { IsSelected = false, Name = "美国", Description = "df45675655" });

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

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public ObservableCollection<Test3> lRST = new ObservableCollection<Test3>();
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

            listbox.ItemsSource = lRST;
 
            load = true;
        }
        bool load = false;
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (this.lRST != null )
            {
                foreach(var x in this.lRST)
                {
                    x.IsSelected = true;
                }
            }

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this.lRST != null)
            {
                foreach (var x in this.lRST)
                {
                    x.IsSelected = false;

                }

            }
        }

        private void ButtonQuery_Click(object sender, RoutedEventArgs e)
        {
            bool haveItem = false;
            foreach (var i in lRST)
            {
                if (i.IsSelected == true)
                {
                    haveItem = true;
                    break;
                }
            }
            if (!haveItem)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                }).ContinueWith(t =>
                {
                    MainSnackbar.MessageQueue.Enqueue("请选择回放目标!");
                }, TaskScheduler.FromCurrentSynchronizationContext());

                return;
            }
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
                    MainSnackbar.MessageQueue.Enqueue("请先输入时间范围!");
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextVesselID.Text == "1")
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                }).ContinueWith(t =>
                {
                    MainSnackbar.MessageQueue.Enqueue("您输入的船舶批号不存在!");
                    TextVesselID.Text = null;

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                this.lRST.Add(new Test3() { Name = "中国", Description = TextVesselID.Text });
                this.TextVesselID.Text = null;
            }
            
        }

    }


    public class Test3 : INotifyPropertyChanged 
    {

        private bool _isSelected;
        private string _name;
        private string _description;
        private char _code;
        private double _numeric;
        private string _food;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                if (PropertyChanged != null)//有改变  
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));//对Name进行监听  
                }
            }
        }

        public char Code
        {
            get { return _code; }
            set
            {
                if (_code == value) return;
                _code = value;
                if (PropertyChanged != null)//有改变  
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Code"));//对Name进行监听  
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                if (PropertyChanged != null)//有改变  
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));//对Name进行监听  
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value) return;
                _description = value;
                if (PropertyChanged != null)//有改变  
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));//对Name进行监听  
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }

}
