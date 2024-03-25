using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for LopDetail.xaml
    /// </summary>
    public partial class LopDetail : Window
    {
        private readonly IDiemsvService diemsvService = null;
        private readonly ISinhvienService sinhvienService = null;
        private readonly IMonhocRepository monhocService = null;
        public string classID { get; set; }
        public LopDetail()
        {
            InitializeComponent();
            diemsvService = new DiemsvService();
            sinhvienService = new SinhvienService();
            monhocService = new MonhocRepository();
            var monhoc = monhocService.GetAllMonhoc();
            cbx_Subject.ItemsSource = monhoc/*.Select(x => x.Tenmh).Distinct().ToList()*/;
            cbx_Subject.SelectedValuePath = "Mamh";
            cbx_Subject.DisplayMemberPath = "Tenmh";

        }
        public void SetClassID(string malp)
        {
            classID = malp;
            LoadData();
        }

        private void LoadData()
        {
            // Thiết lập ItemsSource sau khi classID được thiết lập
            dtg_Class.ItemsSource = sinhvienService.GetSinhvienByLop(classID);
        }
        private void dtg_Class_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dtg_Scores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = (Sinhvien)dtg_Class.SelectedItem;
            var list = diemsvService.GetDiemsvByMasv(selectedRow.Masv).Select(x => new ScoresStudent
            {
                Masv = x.Masv,
                Tensv = x.MasvNavigation.Tensv,
                Tenmh = x.MamhNavigation.Tenmh,
                Mamh = x.Mamh,
                Diem = x.Diem
            }).ToList();

            dtg_Scores.ItemsSource = list;
        }

        private void btn_SearchStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SearchScores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedSubject = cbx_Subject.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(txt_Point.Text) || (cbx_Subject.Text == ""))
                {
                    MessageBox.Show("Không được để trống");
                    return;
                }
                if (!double.TryParse(txt_Point.Text, out _))
                {
                    MessageBox.Show("Điểm phải là số");
                    return;
                }
                if (double.Parse(txt_Point.Text) < 0 || double.Parse(txt_Point.Text) > 10)
                {
                    MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10");
                    return;
                }
                var selectedRow = (Sinhvien)dtg_Class.SelectedItem;
                var s = diemsvService.GetAllDiemsv().Any(x => x.Mamh == cbx_Subject.SelectedValue.ToString()
                                                            && x.Masv == selectedRow.Masv);
                if (s)
                {
                    MessageBox.Show("Sinh viên này đã học môn này");
                    return;
                }
                //var selectedRowSubject = (Diemsv)dtg_Scores.SelectedItem;
                Diemsv diemsv = new Diemsv()
                {
                    Masv = selectedRow.Masv,
                    Mamh = cbx_Subject.SelectedValue.ToString(),
                    //Mamh = selectedRowSubject.Mamh,
                    Diem = double.Parse(txt_Point.Text)
                };
                bool isSuccessful = diemsvService.AddDiemsv(diemsv);
                if (isSuccessful)
                {
                    MessageBox.Show("Thêm điểm thành công");
                    var list = diemsvService.GetDiemsvByMasv(diemsv.Masv).Select(x => new ScoresStudent
                    {
                        Tensv = x.MasvNavigation.Tensv,
                        Tenmh = x.MamhNavigation.Tenmh,
                        Diem = x.Diem
                    }).ToList();
                    dtg_Scores.ItemsSource = list;
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm điểm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Point.Text))
                {
                    MessageBox.Show("Không được để trống");
                    return;
                }
                if (!double.TryParse(txt_Point.Text, out _))
                {
                    MessageBox.Show("Điểm phải là số");
                    return;
                }

                var selectedRow = (Sinhvien)dtg_Class.SelectedItem;
                var selectedRowSubject = (ScoresStudent)dtg_Scores.SelectedItem;
                if (double.Parse(txt_Point.Text) < 0 || double.Parse(txt_Point.Text) > 10)
                {
                    MessageBox.Show("Điểm phải nằm trong khoảng từ 0 đến 10");
                    return;
                }
                Diemsv diemsv = diemsvService.GetDiemsvByMonhoc(selectedRowSubject.Tenmh);
                diemsv.Masv = selectedRow.Masv;
                diemsv.Mamh = cbx_Subject.SelectedValue.ToString();
                diemsv.Diem = double.Parse(txt_Point.Text);
                bool isSuccessful = diemsvService.UpdateDiemsv(diemsv);
                if (isSuccessful)
                {
                    MessageBox.Show("Cập nhật điểm thành công");
                    var list = diemsvService.GetDiemsvByMasv(diemsv.Masv).Select(x => new ScoresStudent
                    {
                        Tensv = x.MasvNavigation.Tensv,
                        Tenmh = x.MamhNavigation.Tenmh,
                        Diem = x.Diem
                    }).ToList();
                    dtg_Scores.ItemsSource = list;
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật điểm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*if (User.Role == "Teacher")
                {
                    MessageBox.Show("Bạn không có quyền xóa điểm");
                    return;
                }
                else
                {*/
                    var selectedRowSubject = (ScoresStudent)dtg_Scores.SelectedItem;
                    Diemsv diemsv = diemsvService.GetDiemsvByMonhoc(selectedRowSubject.Tenmh);
                    diemsvService.DeleteDiemsv(diemsv.Masv, diemsv.Mamh);
                    var list = diemsvService.GetDiemsvByMasv(diemsv.Masv).Select(x => new ScoresStudent
                    {
                        Tensv = x.MasvNavigation.Tensv,
                        Tenmh = x.MamhNavigation.Tenmh,
                        Diem = x.Diem
                    }).ToList();
                    dtg_Scores.ItemsSource = list;
                MessageBox.Show("Xóa điểm thành công");
            }
            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtSearchScores_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilterScores();
        }

        private void TxtSearchStudent_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilterStudent();
        }
        private void ApplyFilterStudent()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dtg_Class.ItemsSource);

            if (collectionView != null)
            {
                // Áp dụng bộ lọc dựa trên nội dung của TextBox
                collectionView.Filter = item =>
                {
                    if (string.IsNullOrWhiteSpace(txt_SearchStudent.Text))
                        return true; // Nếu TextBox trống, hiển thị tất cả

                    // Điều kiện tìm kiếm, thay đổi thành điều kiện tương ứng với cấu trúc dữ liệu của bạn
                    if (item is Sinhvien lop)
                    {
                        return lop.Masv.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Tensv.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Dcsv.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase);
                    }
                    return false;
                };
            }
        }
        private void ApplyFilterScores()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dtg_Scores.ItemsSource);

            if (collectionView != null)
            {
                // Áp dụng bộ lọc dựa trên nội dung của TextBox
                collectionView.Filter = item =>
                {
                    if (string.IsNullOrWhiteSpace(txt_SearchScores.Text))
                        return true; // Nếu TextBox trống, hiển thị tất cả

                    // Điều kiện tìm kiếm, thay đổi thành điều kiện tương ứng với cấu trúc dữ liệu của bạn
                    if (item is ScoresStudent lop)
                    {
                        return lop.Tensv.Contains(txt_SearchScores.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Tenmh.Contains(txt_SearchScores.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Diem.ToString().Contains(txt_SearchScores.Text, StringComparison.OrdinalIgnoreCase);
                    }

                    return false;
                };
            }
        }

        private void cbx_Subject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
