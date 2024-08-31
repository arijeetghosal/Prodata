using Microsoft.Win32;
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
    /// Interaction logic for Teacher.xaml
    /// </summary>
    public partial class Teacher : Window
    {

        List<Course> Courseinfo = new List<Course>();
      
        List<Book> Bookinfo = new List<Book>();
        SignUpInfo st;
        public Teacher(SignUpInfo std)
        {
            InitializeComponent();
            st = std;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Hidden;
            Dashboard_grid.Visibility = Visibility.Visible;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Course_grid.Visibility = Visibility.Visible;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Hidden;
            Dashboard_grid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Visible;
            EBook_grid.Visibility = Visibility.Hidden;
            Dashboard_grid.Visibility = Visibility.Hidden;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Visible;
            Dashboard_grid.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_BtnClick(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog obj = new OpenFileDialog();
            obj.InitialDirectory = @"c:\";
            obj.ShowDialog();
            url.Text = obj.FileName;
        }



        private void Add_Course_(object sender, RoutedEventArgs e)
        {
            if (CourseName.Text == "" && CourseDescription.Text == "")
            {
                MessageBox.Show("Fields can not be empty");

            }
            else
            {
                Stream obs = File.Open("CourseInfo.txt", FileMode.OpenOrCreate);
                obs.Close();
                Stream fs = File.Open("CourseInfo.txt", FileMode.Open);
                if (fs.Length > 0)
                {
                    BinaryFormatter biin = new BinaryFormatter();
                    this.Courseinfo = (List<Course>)biin.Deserialize(fs);
                    fs.Close();
                }
                else { fs.Close(); }
                Course Cobj = new Course(st.name,CourseName.Text, CourseDescription.Text);
                Courseinfo.Add(Cobj);
                Stream ob = File.Open("CourseInfo.txt", FileMode.OpenOrCreate);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(ob, this.Courseinfo);
                ob.Close();
                MessageBox.Show("Course Added");
                CourseName.Text = "";
                CourseDescription.Text = "";
            }


        }

        private void Add_Lecture_(object sender, RoutedEventArgs e)
        {
           
        }

        private void Profile_Btn_(object sender, RoutedEventArgs e)
        {
            Profile obj = new Profile(st);
            obj.Show();
        }

        private void arrow_Click(object sender, RoutedEventArgs e)
        {
            Course_grid.Visibility = Visibility.Hidden;
            VideoLecture_grid.Visibility = Visibility.Hidden;
            EBook_grid.Visibility = Visibility.Hidden;
            Dashboard_grid.Visibility = Visibility.Hidden;
        }

        private void AddBook_(object sender, RoutedEventArgs e)
        {
            

            Stream obs = File.Open("BookInfo.txt", FileMode.OpenOrCreate);
            obs.Close();
            Stream fs = File.Open("BookInfo.txt", FileMode.Open);
            if (fs.Length > 0)
            {
                BinaryFormatter biin = new BinaryFormatter();
                this.Bookinfo = (List<Book>)biin.Deserialize(fs);
                fs.Close();
            }
            else { fs.Close(); }
            Book obj = new Book(Book_Name.Text, Book_Link.Text);
            Bookinfo.Add(obj);

            Stream ob = File.Open("BookInfo.txt", FileMode.OpenOrCreate);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(ob, this.Bookinfo);
            ob.Close();
            MessageBox.Show("Book Added");
            Book_Name.Text = "";
            Book_Link.Text = "";
            

        }

        private void Courselabel_(object sender, RoutedEventArgs e)
        {
            Stream fss = File.Open("CourseInfo.txt", FileMode.Open);
            BinaryFormatter binn = new BinaryFormatter();
            this.Courseinfo= (List<Course>)binn.Deserialize(fss);
            Courselabel.Content = Courseinfo.Count;
            fss.Close();
          
            
        }

        private void Course_Bar_(object sender, RoutedEventArgs e)
        {
            Stream fss = File.Open("CourseInfo.txt", FileMode.Open);
            BinaryFormatter binn = new BinaryFormatter();
            this.Courseinfo = (List<Course>)binn.Deserialize(fss);
            Course_Bar.Value = Courseinfo.Count;
            fss.Close();
            
        }
    }

}
