using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SharcProject
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
       List<SignUpInfo> StudentSignUp = new List<SignUpInfo>();

        public SignUp()
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

       

        private void SignUp1_(object sender, RoutedEventArgs e)
        {
            Boolean PasswordCheck = Password_();
            Boolean EmailCheck = Email_();
            

            if (Name.Text == "" )
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
            else if (EmailCheck==false)
            {
                MessageBox.Show("Enter correct email");
            }
            else
            {
                bool tem = true;
                if (Gender.Text == "Female") 
                {
                    tem = false;
                
                }
                Stream obs = File.Open("StudentLoginInfo.txt", FileMode.OpenOrCreate);
                obs.Close();
                Stream fs = File.Open("StudentLoginInfo.txt", FileMode.Open);
                if (fs.Length > 0)
                {
                    BinaryFormatter biin = new BinaryFormatter();
                    this.StudentSignUp = (List<SignUpInfo>)biin.Deserialize(fs);
                    fs.Close();
                }
                else { fs.Close(); }
                SignUpInfo obj = new SignUpInfo(Name.Text, Username.Text, Email.Text, Convert.ToString(Password.Password), tem,Convert.ToString(Dateofbirth.SelectedDate));
                StudentSignUp.Add(obj);
                
                Stream ob = File.Open("StudentLoginInfo.txt", FileMode.OpenOrCreate);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(ob, this.StudentSignUp);
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






    }
}
