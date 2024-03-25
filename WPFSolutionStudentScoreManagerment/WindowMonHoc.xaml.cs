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
using WPFService;

namespace WPFSolutionStudentScoreManagerment
{
    /// <summary>
    /// Interaction logic for WindowMonHoc.xaml
    /// </summary>
    public partial class WindowMonHoc : Window
    {
        private readonly IMonhocService monhocService = null;
        private readonly ISinhvienService sinhvienService = null;
        public WindowMonHoc()
        {
            InitializeComponent();
            monhocService = new MonhocService();
            sinhvienService = new SinhvienService();
            LoadData();
        }
        public void LoadData()
        {
            dtg_MonHoc.ItemsSource = monhocService.GetAllMonhoc();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_SubjectId.Text) ||
                                            string.IsNullOrWhiteSpace(txt_SubjectName.Text) ||
                                                                   string.IsNullOrWhiteSpace(txt_SubjectSotc.Text))
                {
                    MessageBox.Show("không được để trống ");
                    return;
                }
                if (monhocService.GetMonhocById(txt_SubjectId.Text) != null)
                {
                    MessageBox.Show("Môn học đã tồn tại trong hệ thống");
                    return;
                }
                
                if (!int.TryParse(txt_SubjectSotc.Text, out _))
                {
                    MessageBox.Show("Điểm phải là số");
                    return;
                }
/*                if (int.Parse(txt_SubjectSotc.Text) < 0 || int.Parse(txt_SubjectSotc.Text) > 4)
                {
                    MessageBox.Show("Số tín chỉ phải lớn hơn 0 và nhỏ hơn 4");
                    return;
                }*/

                Monhoc monhoc = new Monhoc
                {
                    Mamh = txt_SubjectId.Text,
                    Tenmh = txt_SubjectName.Text,
                    Sotc = int.Parse(txt_SubjectSotc.Text)
                };
                bool isSuccessful = monhocService.AddMonhoc(monhoc);
                if (isSuccessful)
                {
                    MessageBox.Show("Thêm môn học thành công");
                    dtg_MonHoc.ItemsSource = monhocService.GetAllMonhoc();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm môn học thất bại");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_SubjectId.Text) ||
                                      string.IsNullOrWhiteSpace(txt_SubjectName.Text) ||
                                                        string.IsNullOrWhiteSpace(txt_SubjectSotc.Text))
                {
                    MessageBox.Show("không được để trống!!!");
                    return;
                }
                if (monhocService.GetMonhocById(txt_SubjectId.Text) == null)
                {
                    MessageBox.Show("Môn học Không tồn tại trong hệ thống");
                    return;
                }
                
                if (!int.TryParse(txt_SubjectSotc.Text, out _))
                {
                    MessageBox.Show("Điểm phải là số");
                    return;
                }
                /*if (int.Parse(txt_SubjectSotc.Text) < 0 || int.Parse(txt_SubjectSotc.Text) > 4)
                {
                    MessageBox.Show("Số tín chỉ phải lớn hơn 0 và nhỏ hơn 4");
                    return;
                }*/
                Monhoc monhoc = new Monhoc
                {
                    Mamh = txt_SubjectId.Text,
                    Tenmh = txt_SubjectName.Text,
                    Sotc = int.Parse(txt_SubjectSotc.Text)
                };
                bool isSuccessful = monhocService.UpdateMonhoc(monhoc);
                if (isSuccessful)
                {
                    MessageBox.Show("Sửa môn học thành công");
                    dtg_MonHoc.ItemsSource = monhocService.GetAllMonhoc();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Sửa môn học thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            string id = txt_SubjectId.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Mã môn học không được để trống");
                return;
            }
            bool isSuccessful = monhocService.DeleteMonhoc(id);
            if (isSuccessful)
            {
                MessageBox.Show("Xóa môn học thành công");
                dtg_MonHoc.ItemsSource = monhocService.GetAllMonhoc();
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa môn học thất bại");
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void dtg_MonHoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var monhoc = dtg_MonHoc.SelectedItem as WPFBO.Monhoc;
            var list = monhocService.GetStudentsInMonHoc(monhoc.Mamh);
            dtg_Student.ItemsSource = list;
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dtg_MonHoc.ItemsSource);

            if (collectionView != null)
            {
                // Áp dụng bộ lọc dựa trên nội dung của TextBox
                collectionView.Filter = item =>
                {
                    if (string.IsNullOrWhiteSpace(txt_SearchSubject.Text))
                        return true; // Nếu TextBox trống, hiển thị tất cả

                    // Điều kiện tìm kiếm, thay đổi thành điều kiện tương ứng với cấu trúc dữ liệu của bạn
                    if (item is Monhoc lop)
                    {
                        return lop.Mamh.Contains(txt_SearchSubject.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Tenmh.Contains(txt_SearchSubject.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Sotc.ToString().Contains(txt_SearchSubject.Text, StringComparison.OrdinalIgnoreCase);
                    }

                    return false;
                };
            }
        }
        private void dtg_Student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtSearchStudent_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilterStudent();
        }
        private void ApplyFilterStudent()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dtg_Student.ItemsSource);

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
                        return lop.Masv.Contains(txt_SearchSubject.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Tensv.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Dcsv.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Malp.Contains(txt_SearchStudent.Text, StringComparison.OrdinalIgnoreCase);
                    }

                    return false;
                };
            }
        }
    }
}
