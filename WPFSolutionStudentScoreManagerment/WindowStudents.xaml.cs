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
    /// Interaction logic for WindowStudents.xaml
    /// </summary>
    public partial class WindowStudents : Window
    {
        private readonly ISinhvienService SinhvienService;
        public WindowStudents()
        {
            InitializeComponent();
            SinhvienService = new SinhvienService();
            var sinhvien = SinhvienService.GetAllSinhVien();
            dtg_Students.ItemsSource = sinhvien;
            string defaultClassCode = sinhvien.Select(x => x.Malp).Distinct().FirstOrDefault();

            cbx_Classcode.SelectedItem = defaultClassCode;
            //cbx_SearchClass.SelectedItem = defaultClassCode;
            cbx_Classcode.ItemsSource = sinhvien.Select(x => x.Malp).Distinct().ToList();
            //cbx_SearchClass.ItemsSource = sinhvien.Select(x => x.Malp).Distinct().ToList();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedClassCode = cbx_Classcode.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(selectedClassCode) ||
                    string.IsNullOrWhiteSpace(txt_Code.Text) ||
                        string.IsNullOrWhiteSpace(txt_Name.Text) ||
                        string.IsNullOrWhiteSpace(txt_Address.Text))
                {
                    MessageBox.Show("không được để trống!!!");
                    return;
                }
                if (SinhvienService.GetSinhvienById(txt_Code.Text) != null)
                {
                    MessageBox.Show("Student đã tồn tại trong hệ thống");
                    return;
                }
                Sinhvien sinhvien = new Sinhvien()
                {
                    Masv = txt_Code.Text,
                    Tensv = txt_Name.Text,
                    Dcsv = txt_Address.Text,
                    Malp = selectedClassCode
                };
                bool isSuccessful = SinhvienService.AddSinhvien(sinhvien);
                if (isSuccessful)
                {
                    MessageBox.Show("Thêm sinh viên thành công");
                    dtg_Students.ItemsSource = SinhvienService.GetAllSinhVien();
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Code.Text))
                {
                    MessageBox.Show("Mã sinh viên không được để trống");
                    return;
                }
                if(string.IsNullOrWhiteSpace(txt_Name.Text) ||
                   string.IsNullOrWhiteSpace(txt_Address.Text))
                {
                    MessageBox.Show("Tên sinh viên và địa chỉ không được để trống");
                    return;
                }
                string selectedClassCode = cbx_Classcode.SelectedItem.ToString();
                Sinhvien sinhvien = new Sinhvien()
                {
                    Masv = txt_Code.Text,
                    Tensv = txt_Name.Text,
                    Dcsv = txt_Address.Text,
                    Malp = selectedClassCode
                };
                bool isSuccessful = SinhvienService.UpdateSinhvien(sinhvien);
                if (isSuccessful)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công");
                    dtg_Students.ItemsSource = SinhvienService.GetAllSinhVien();
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật sinh viên thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            string code = txt_Code.Text;
            if(SinhvienService.GetSinhvienById(code).Equals(null))
            {
                MessageBox.Show("Student không tồn tại trong hệ thống");
                return;
            }
            bool isSuccessful = SinhvienService.DeleteSinhvien(code);
            if (isSuccessful)
            {
                MessageBox.Show("Xóa sinh viên thành công");
                dtg_Students.ItemsSource = SinhvienService.GetAllSinhVien();
                return;
            }
            else
            {
                MessageBox.Show("Xóa sinh viên thất bại");
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }

        private void ApplyFilter()
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dtg_Students.ItemsSource);

            if (collectionView != null)
            {
                // Áp dụng bộ lọc dựa trên nội dung của TextBox
                collectionView.Filter = item =>
                {
                    if (string.IsNullOrWhiteSpace(txt_Search.Text))
                        return true; // Nếu TextBox trống, hiển thị tất cả

                    // Điều kiện tìm kiếm, thay đổi thành điều kiện tương ứng với cấu trúc dữ liệu của bạn
                    if (item is Sinhvien lop)
                    {
                        return lop.Masv.Contains(txt_Search.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Tensv.Contains(txt_Search.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Malp.Contains(txt_Search.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Dcsv.Contains(txt_Search.Text, StringComparison.OrdinalIgnoreCase);
                    }

                    return false;
                };
            }
        }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void dtg_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
