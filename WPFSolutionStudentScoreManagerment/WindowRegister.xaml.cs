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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFBO;
using WPFService;

namespace WPFSolutionStudentScoreManagerment
{
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        private readonly IAccountService accountService = null;
        private readonly ISinhvienService sinhvienService = null;
        public WindowRegister()
        {
            InitializeComponent();
            accountService = new AccountService();
            sinhvienService = new SinhvienService();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Email.Text) ||
                    string.IsNullOrWhiteSpace(txt_Password.Password) ||
                    string.IsNullOrWhiteSpace(txt_Gender.Text) ||
                    string.IsNullOrWhiteSpace(txt_Masv.Text))
                {
                    MessageBox.Show("không được để trống !!");
                    return;
                }
                if(accountService.GetAccountByEmail(txt_Email.Text) != null)
                {
                    MessageBox.Show("Email đã tồn tại trong hệ thống");
                    return;
                }
                if (sinhvienService.GetSinhvienById(txt_Masv.Text) == null)
                {
                    MessageBox.Show("Student không tồn tại trong hệ thống");
                    return;
                }
               
                if (!txt_Email.Text.Contains("@gmail.com"))
                {
                    MessageBox.Show("Invalid email format.");
                    return;
                }
                if (!(txt_Gender.Text.Equals("Female", StringComparison.OrdinalIgnoreCase) || txt_Gender.Text.Equals("Male", StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Giới tính chỉ được nhập là Female hoặc Male");
                    return;
                }

                // Gọi hàm RegisterAccount từ AccountService
                Account account = new Account();
                account.Email = txt_Email.Text;
                account.Password = txt_Password.Password;
                account.Role = "Student";
                account.Masv = txt_Masv.Text;
                bool isSuccessful = accountService.AddAccount(account);
                if (isSuccessful)
                {
                    MessageBox.Show("Đăng ký tài khoản thành công");
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký tài khoản thất bại");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
