using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPFBO;
using WPFRepo;
using WPFService;
using WPFSolutionStudentScoreManagerment.ViewModels;

namespace WPFSolutionStudentScoreManagerment
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private readonly IDiemsvService diemsvService = null;
        private readonly ISinhvienService sinhvienService = null;
        public string Id;
        public StudentWindow()
        {
            InitializeComponent();
            diemsvService = new DiemsvService();
            sinhvienService = new SinhvienService();
            LoadDataScores();
            LoadDataScoresStudent();
        }

        public void LoadDataScores()
        {
            var list = diemsvService.GetDiemsvByMasv(User.MaSv).Select(x => new ScoresStudent
            {
                Tensv = x.MasvNavigation.Tensv,
                Tenmh = x.MamhNavigation.Tenmh,
                Diem = x.Diem
            }).ToList();
            dtg_Scores.ItemsSource = list;
        }
        public void LoadDataScoresStudent()
        {
            var students = sinhvienService.GetAllSinhVien();
            var diem = diemsvService.GetAllDiemsv();
            var s = sinhvienService.GetSinhvienById(User.MaSv);
            var list = sinhvienService.GetStudentsWithAveragePoints(students, diem, s.Malp);
            dtg_ScoresStudent.ItemsSource = list;
        }
        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dtg_ScoresStudent.SelectedItem as TopSinhVien;
            //Id = selectedStudent.Id;
            WindowDetailScores windowDetailScores = new WindowDetailScores(selectedStudent.Id);
            windowDetailScores.ShowDialog();
        }

        private void dtg_ScoresStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dtg_ScoresStudent.ItemsSource);

            if (collectionView != null)
            {
                // Áp dụng bộ lọc dựa trên nội dung của TextBox
                collectionView.Filter = item =>
                {
                    if (string.IsNullOrWhiteSpace(txt_SearchStudent.Text))
                        return true; // Nếu TextBox trống, hiển thị tất cả

                    // Điều kiện tìm kiếm, thay đổi thành điều kiện tương ứng với cấu trúc dữ liệu của bạn
                    if (item is TopSinhVien lop)
                    {
                        return lop.Id.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Tenhocsinh.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Diemtb.ToString().Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase);
                    }
                    return false;
                };
            }
        }
    }
}
