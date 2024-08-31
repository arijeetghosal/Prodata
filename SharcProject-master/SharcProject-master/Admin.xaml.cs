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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace SharcProject
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        List<SignUpInfo> StudentSignUp = new List<SignUpInfo>();
        List<SignUpInfo> TeacherSignUp = new List<SignUpInfo>();
        List<Course> Courseinfo = new List<Course>();
      
        List<Book> Bookinfo = new List<Book>();
        public Admin()
        {
            List<SignUpInfo> StudentSignUp = new List<SignUpInfo>();
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Dashboard_grid.Visibility = Visibility.Visible; 
            StudentEnroll_grid.Visibility = Visibility.Hidden;
            TeacherEnroll_grid.Visibility = Visibility.Hidden;
            Ebook_grid.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dashboard_grid.Visibility = Visibility.Hidden;
            StudentEnroll_grid.Visibility = Visibility.Visible;
            TeacherEnroll_grid.Visibility = Visibility.Hidden;
            Ebook_grid.Visibility = Visibility.Hidden;
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dashboard_grid.Visibility = Visibility.Hidden;
            StudentEnroll_grid.Visibility = Visibility.Hidden;
            TeacherEnroll_grid.Visibility = Visibility.Visible;
            Ebook_grid.Visibility = Visibility.Hidden;
        }

        private void arrow_Click(object sender, RoutedEventArgs e)
        {
            main.Visibility = Visibility.Visible;
            Dashboard_grid.Visibility = Visibility.Hidden;
            StudentEnroll_grid.Visibility = Visibility.Hidden;
            TeacherEnroll_grid.Visibility = Visibility.Hidden;
            Ebook_grid.Visibility = Visibility.Hidden;
        }

        private void Student_DataGrid_(object sender, RoutedEventArgs e)
        {

            Stream fs = File.Open("StudentLoginInfo.txt", FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            this.StudentSignUp = (List<SignUpInfo>)bin.Deserialize(fs);
            Student_DataGrid.ItemsSource = StudentSignUp;
            fs.Close();

        }

        private void TeacherEnroll_grid_(object sender, RoutedEventArgs e)
        {
            Stream fss = File.Open("TeacherLoginInfo.txt", FileMode.Open);
            BinaryFormatter binn = new BinaryFormatter();
            this.TeacherSignUp = (List<SignUpInfo>)binn.Deserialize(fss);
            Teacher_DataGrid.ItemsSource = TeacherSignUp;
            fss.Close();
        }

        private void Teacher_Count_(object sender, RoutedEventArgs e)
        {
            Stream fss = File.Open("TeacherLoginInfo.txt", FileMode.Open);
            BinaryFormatter binn = new BinaryFormatter();
            this.TeacherSignUp = (List<SignUpInfo>)binn.Deserialize(fss);
            
            Teacher_Count.Content = TeacherSignUp.Count;
            fss.Close();
        }

        private void Student_Count_(object sender, RoutedEventArgs e)
        {
            Stream fs = File.Open("StudentLoginInfo.txt", FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            this.StudentSignUp = (List<SignUpInfo>)bin.Deserialize(fs);
            
            Student_Count.Content = StudentSignUp.Count();
            fs.Close();
        }

        private void Teacher_Bar_(object sender, RoutedEventArgs e)
        {
            Stream fss = File.Open("TeacherLoginInfo.txt", FileMode.Open);
            BinaryFormatter binn = new BinaryFormatter();
            this.TeacherSignUp = (List<SignUpInfo>)binn.Deserialize(fss);
          Teacher_Bar.Value= TeacherSignUp.Count;
            fss.Close();
        }

        private void Student_Bar_(object sender, RoutedEventArgs e)
        {
            Stream fs = File.Open("StudentLoginInfo.txt", FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            this.StudentSignUp = (List<SignUpInfo>)bin.Deserialize(fs);
            Student_Bar.Value= StudentSignUp.Count();
            fs.Close();
        }

        private void E_book_Btn_(object sender, RoutedEventArgs e)
        {
            Dashboard_grid.Visibility = Visibility.Hidden;
            StudentEnroll_grid.Visibility = Visibility.Hidden;
            TeacherEnroll_grid.Visibility = Visibility.Hidden;
            Ebook_grid.Visibility = Visibility.Visible;
        }

        private void Course_Count_(object sender, RoutedEventArgs e)
        {
            Stream fs = File.Open("CourseInfo.txt", FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            this.Courseinfo = (List<Course>)bin.Deserialize(fs);

            Course_Count.Content = Courseinfo.Count();
            fs.Close();
        }

        private void Course_bar_(object sender, RoutedEventArgs e)
        {
            Stream fs = File.Open("CourseInfo.txt", FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            this.Courseinfo = (List<Course>)bin.Deserialize(fs);
            Course_bar.Value = Courseinfo.Count();
            fs.Close();
        }

        private void Video_count_(object sender, RoutedEventArgs e)
        {
          
        }

        private void Video_bar_(object sender, RoutedEventArgs e)
        {
          
        }

        private void admin_Btn_(object sender, RoutedEventArgs e)
        {
            
        }

        private void Student_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Ebook_DataGrid_(object sender, RoutedEventArgs e)
        {
            //Stream fs = File.Open("BookInfo.txt", FileMode.Open);
            //BinaryFormatter bin = new BinaryFormatter();
            //this.Bookinfo = (List<Book>)bin.Deserialize(fs);
            //Ebook_DataGrid.ItemsSource = StudentSignUp;
            //fs.Close();
        }
    }
}
