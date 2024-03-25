using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
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
using WPFBO;
using WPFService;
using WPFSolutionStudentScoreManagerment.ViewModels;

namespace WPFSolutionStudentScoreManagerment
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private readonly ILopService lopService = null;
        private readonly IAccountService accountService = null;
        public TeacherWindow()
        {
            InitializeComponent();
            lopService = new LopService();
            accountService = new AccountService();
            dtg_Students.ItemsSource = lopService.GetAllLop();
            var lop = lopService.GetAllLop();
            string defaultClassCode = lop.Select(x => x.Malp).Distinct().FirstOrDefault();

        }

        

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_ClassId.Text) ||
                                       string.IsNullOrWhiteSpace(txt_ClassName.Text) ||
                                                          string.IsNullOrWhiteSpace(txt_SchoolYear.Text))
                {
                    MessageBox.Show("không được để trống!!!");
                    return;
                }
                if (lopService.GetLopById(txt_ClassId.Text) == null)
                {
                    MessageBox.Show("Lớp không tồn tại trong hệ thống");
                    return;
                }
                int? schoolYear = null;
                if (!string.IsNullOrEmpty(txt_SchoolYear.Text) && int.TryParse(txt_SchoolYear.Text, out int parsedSchoolYear))
                {
                    schoolYear = parsedSchoolYear;
                }

                Lop lop = new Lop
                {
                    Malp = txt_ClassId.Text,
                    Tenlp = txt_ClassName.Text,
                    Nk = schoolYear
                };
                bool isSuccessful = lopService.UpdateLop(lop);
                if (isSuccessful)
                {
                    MessageBox.Show("Cập nhật lớp thành công");
                    dtg_Students.ItemsSource = lopService.GetAllLop();
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật lớp thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(User.Role == "Teacher")
            {
                MessageBox.Show("Bạn không có quyền xóa lớp");
                return;
            }
            else
            {
                string id = txt_ClassId.Text;
                if (lopService.GetLopById(id) == null)
                {
                    MessageBox.Show("Lớp không tồn tại trong hệ thống");
                    return;
                }
                bool isSuccessful = lopService.DeleteLop(id);
                if (isSuccessful)
                {
                    MessageBox.Show("Xóa lớp thành công");
                    dtg_Students.ItemsSource = lopService.GetAllLop();
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa lớp thất bại");
                }
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            //var account = accountService.GetAccountByRole(User.Role);
            if(User.Role == "Admin")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            } 
        }

        private void dtg_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = (Lop)dtg_Students.SelectedItem;
            if (selectedRow != null)
            {
                LopDetail lopDetail = new LopDetail();
                lopDetail.SetClassID(selectedRow.Malp);

                // Hiển thị cửa sổ
                lopDetail.Show();
            }
            else
            {
                // Thông báo người dùng về việc chưa chọn dòng nào
                MessageBox.Show("Vui lòng chọn một lớp để xem chi tiết.");
            }
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
                    if (item is Lop lop)
                    {
                        return lop.Malp.Contains(txt_Search.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Tenlp.Contains(txt_Search.Text, StringComparison.OrdinalIgnoreCase)
                               || lop.Nk.ToString().Contains(txt_Search.Text, StringComparison.OrdinalIgnoreCase);
                    }

                    return false;
                };
            }
        }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }
    }
}
