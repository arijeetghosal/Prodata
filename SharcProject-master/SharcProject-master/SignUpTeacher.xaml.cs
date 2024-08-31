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
using System.Text.RegularExpressions;

namespace SharcProject
{
    /// <summary>
    /// Interaction logic for SignUpTeacher.xaml
    /// </summary>
    public partial class SignUpTeacher : Window
    {
        List<SignUpInfo> TeacherSignUp = new List<SignUpInfo>();
        public SignUpTeacher()
        {
            InitializeComponent();
        }
        private Boolean Email_()
        {
            string email = Email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                return true;
            }

            else
            {
                return false;
            }


        }

        private Boolean Password_()
        {
            string password = Password.Password;

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            Match match = regex.Match(password);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean Username_()
        {

            string username = Username.Text;
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{4,}$");
            Match match = regex.Match(username);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void SignUp1_(object sender, RoutedEventArgs e)
        {
            Boolean PasswordCheck = Password_();
            Boolean EmailCheck = Email_();
            Boolean UsernameCheck = Username_();

            if (Name.Text == "")
            {

                MessageBox.Show("Enter your name");
            }
            else if (Username.Text == "")
            {
                MessageBox.Show("Enter the username");
            }
            else if (Email.Text == "")
            {
                MessageBox.Show("Enter the email");
            }
            else if (Password.Password == "")
            {
                MessageBox.Show("Enter the password");
            }
            else if (Gender.Text == "")
            {
                MessageBox.Show("Select your gender");

            }
            else if (Dateofbirth.SelectedDate == null)
            {
                MessageBox.Show("Select your Dob");
            }
            else if (PasswordCheck == false)
            {
                MessageBox.Show("Password must contain a Capital Alphabet and a digit");
            }
            else if (EmailCheck == false)
            {
                MessageBox.Show("Enter correct email");
            }
            else if (UsernameCheck == false)
            {
                MessageBox.Show("Username must Contain a Cpital letter and A numeri value");
            }
            else
            {
                bool tem = true;
                if (Gender.Text == "Female")
                {
                    tem = false;

                }
                Stream obbs = File.Open("TeacherLoginInfo.txt", FileMode.OpenOrCreate);
                obbs.Close();
                Stream fss = File.Open("TeacherLoginInfo.txt", FileMode.Open);
                if (fss.Length > 0)
                {
                    BinaryFormatter biiin = new BinaryFormatter();
                    this.TeacherSignUp = (List<SignUpInfo>)biiin.Deserialize(fss);
                    fss.Close();
                }
                else { fss.Close(); }
                SignUpInfo obbj = new SignUpInfo(Name.Text, Username.Text, Email.Text, Convert.ToString(Password.Password), tem, Convert.ToString(Dateofbirth.SelectedDate));
                TeacherSignUp.Add(obbj);

                Stream ob = File.Open("TeacherLoginInfo.txt", FileMode.OpenOrCreate);
                BinaryFormatter biin = new BinaryFormatter();
                biin.Serialize(ob, this.TeacherSignUp);
                ob.Close();


                Login obj1 = new Login();
                obj1.Show();
                this.Hide();

            }

        }

        private void Email_(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_(object sender, TextCompositionEventArgs e)
        {

        }

        private void Dateofbirth_(object sender, TextCompositionEventArgs e)
        {

        }

        private void Username_(object sender, TextCompositionEventArgs e)
        {

        }
    }
}

