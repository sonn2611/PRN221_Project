using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WPFService;
using WPFSolutionStudentScoreManagerment.ViewModels;

namespace WPFSolutionStudentScoreManagerment
{
    /// <summary>
    /// Interaction logic for WindowDetailScores.xaml
    /// </summary>
    public partial class WindowDetailScores : Window
    {
        private readonly IDiemsvService diemsvService = null;
        public string MaSv { get; set; }
        public WindowDetailScores(string ma)
        {
            InitializeComponent();
            diemsvService = new DiemsvService();
            LoadDataScores(ma);
        }
        public void LoadDataScores(string sv)
        {
            var list = diemsvService.GetDiemsvByMasv(sv).Select(x => new ScoresStudent
            {
                Tensv = x.MasvNavigation.Tensv,
                Tenmh = x.MamhNavigation.Tenmh,
                Diem = x.Diem
            }).ToList();
            dtg_Scores.ItemsSource = list;
        }
    }
}
