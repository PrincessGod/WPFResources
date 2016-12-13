using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ee : Window
    {
        public delegate void dDeleteRows(IList rows);
        public dDeleteRows OnDeleteRows;
        public ee()
        {
            InitializeComponent();

            ObservableCollection<_PositonRealInfo> po = new ObservableCollection<_PositonRealInfo>();
            po.Add(new _PositonRealInfo() { co = "中国", di = 156, he = 234, ms = 0, mt = 4, nu = "St7898", sn = 8977, st = "客船" });
            po.Add(new _PositonRealInfo() { co = "日本", di = 126, he = 78, ms = 0, mt = 4, nu = "St06598", sn = 8977, st = "货船" });
            po.Add(new _PositonRealInfo() { co = "加拿大", di = 54, he = 98, ms = 0, mt = 4, nu = "St789798", sn = 8977, st = "邮轮" });
            dataGrid.ItemsSource = po;          
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (OnDeleteRows != null)
            {
                this.OnDeleteRows(dataGrid.SelectedItems);
            }
        }

            
    }

    public class _PositonRealInfo
    {
        /// <summary>
        ///  中文国家名 没有时返回空，为：“其他”可做过滤条件
        /// </summary>
        public string co { get; set; }
        /// <summary>
        /// 船航向direction	实际值=direction/10
        /// </summary>
        public int di { get; set; }
        /// <summary>
        /// 船艏向heading
        /// </summary>
        public int he { get; set; }
        /// <summary>
        /// 纬度latitude	实际值=lat/600000       
        /// </summary>
        public int la { get; set; }

        /// <summary>
        /// 经度longitude	实际值=lon/600000
        /// </summary>
        public int lo { get; set; }
        /// <summary>
        ///信息来源meg_sour	融合模式忽略此参数为0
        ///原始模式如下：
        ///信息来源，编号如下：
        ///1：农业部
        ///2：海事局
        ///3：Hai Jian
        ///可做过滤条件
        /// </summary>
        public int ms { get; set; }
        /// <summary>
        ///信息类型meg_type
        ///1：Argos及海事卫星
        ///2：北斗
        ///3：AIS静态
        ///4：AIS动态
        ///5：LRIT
        ///7：Hai Jian
        ///15：综合信息
        /// </summary>
        public int mt { get; set; }
        /// <summary>
        /// 目标编号num	原始模式为原始编号
        /// 融合模式为融合后重新编批批号
        /// </summary>
        public string nu { get; set; }
        /// <summary>
        /// ship_Name
        /// </summary>
        public int sn { get; set; }
        /// <summary>
        /// 船舶类型ship_Type	中文船舶类型，可做过滤条件
        /// </summary>
        public string st { get; set; }
    }
}
