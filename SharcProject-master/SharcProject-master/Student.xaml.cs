using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace SharcProject
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    ///  
    public partial class Student : Window
    {
        List<Course> Courseinfo = new List<Course>();
        List<SignUpInfo> stsign = new List<SignUpInfo>();
        List<Book> Bookinfo = new List<Book>();
        SignUpInfo st;
        public Student(SignUpInfo std)
        {
            st = std;
           
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Profile obj = new Profile(st);
            obj.Show();
        }

        private void Logout_BtnClick(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Help obj = new Help();
            obj.Show();
            this.Hide();
        }

       

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            Dashboard_grid.Visibility = Visibility.Visible;
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            FindTeacher_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            Dashboard_grid.Visibility = Visibility.Hidden;
            Course_grid.Visibility = Visibility.Visible;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            FindTeacher_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
            Dashboard_grid.Visibility = Visibility.Hidden;
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Visible;
            FindTeacher_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            
            Dashboard_grid.Visibility = Visibility.Hidden;
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            FindTeacher_grid.Visibility = Visibility.Visible;
            EBook_grid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            
            Dashboard_grid.Visibility = Visibility.Hidden;
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            FindTeacher_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Visible;
        }

        private void Course_DataGrid_(object sender, RoutedEventArgs e)
        {

            Course_dataGrid.ItemsSource = Courseinfo;
           
          
        }

        private void arrow_Click(object sender, RoutedEventArgs e)
        {
            Dashboard_grid.Visibility = Visibility.Hidden;
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            FindTeacher_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Hidden;
        }

        private void Teacher_Combo_(object sender, RoutedEventArgs e)
        {
            Stream ob = File.Open("CourseInfo.txt", FileMode.OpenOrCreate);
            BinaryFormatter biiin = new BinaryFormatter();
            this.Courseinfo = (List<Course>)biiin.Deserialize(ob);
            ob.Close();
            Teacher_Combo.ItemsSource = Courseinfo;
           
            
        }

        private void Teacher_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Selec_Teacher_Click(object sender, RoutedEventArgs e)
        {
            Stream ob = File.Open("StudentLoginInfo.txt", FileMode.OpenOrCreate);
            BinaryFormatter biiin = new BinaryFormatter();
            this.stsign = (List<SignUpInfo>)biiin.Deserialize(ob);
            
            ob.Close();
            int q = 0;
            for (int i = 0; i < stsign.Count; i++) 
            {
                if (stsign.Equals(st)) 
                {
                    q = i;
                    break;
                }
            }
            stsign.RemoveAt(q);
            string w = Convert.ToString( Teacher_Combo.SelectedItem);
            for (int i = 0; i < Courseinfo.Count; i++)
            {
                if (Courseinfo[i].ToString().Equals(w))
                {
                    q = i;
                    break;
                }
            }
            List<Course> sda= new List<Course>();
            sda.Add(Courseinfo[q]);
            st.cou = sda;
            stsign.Add(st);
            Stream obj = File.Open("StudentLoginInfo.txt", FileMode.OpenOrCreate);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(obj, this.stsign);
            obj.Close();

        }

        private void Ebook_DataGrid_(object sender, RoutedEventArgs e)
        {

            //Stream ab = File.Open("BookInfo.txt", FileMode.Open);
            //BinaryFormatter Bf = new BinaryFormatter();
            //this.Bookinfo = (List<Book>)Bf.Deserialize(ab);
            //Ebook_DataGrid.ItemsSource = Bookinfo;
            //ab.Close();
        }
    }
}
