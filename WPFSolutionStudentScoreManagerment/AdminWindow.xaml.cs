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
using WPFBO;

namespace WPFSolutionStudentScoreManagerment
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btn_Sinhvien_Click(object sender, RoutedEventArgs e)
        {
            WindowStudents windowstudent = new WindowStudents();
            windowstudent.Show();
            this.Close();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btn_Lop_Click(object sender, RoutedEventArgs e)
        {
            TeacherWindow lop = new TeacherWindow();
            lop.Show();
            this.Close();
        }

        private void btn_MonHoc_Click(object sender, RoutedEventArgs e)
        {
            WindowMonHoc monHoc = new WindowMonHoc();
            monHoc.Show();
            this.Close();
        }

        private void btn_Diem_Click(object sender, RoutedEventArgs e)
        {
            TeacherWindow diem = new TeacherWindow();
            diem.Show();
            this.Close();
        }
    }
}
