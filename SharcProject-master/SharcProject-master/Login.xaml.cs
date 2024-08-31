using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Speech.Synthesis;
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

namespace SharcProject
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        List<SignUpInfo> StudentSignUp = new List<SignUpInfo>();
        List<SignUpInfo> TeacherSignUp = new List<SignUpInfo>();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SignUpTeacher obj = new SignUpTeacher();
            obj.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)


        {
            string username = Username.Text;

            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{4,}$");
            Match match = regex.Match(username);
            //Admin Login
            if (Username.Text == "" && Password.Password == "")
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.Speak("Fields can not be empty");


            } 
            else
            {
                if (Username.Text == "admin" && Password.Password == "1234")
                {
                   
                    Admin obj1 = new Admin( );
                    SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                    speechSynthesizer.Speak("Welcome Admin");
                    obj1.Show();
                    this.Hide();

                }
                else if (match.Success)
                {
                    Stream fss = File.Open("TeacherLoginInfo.txt", FileMode.Open);
                    BinaryFormatter binn = new BinaryFormatter();
                    this.TeacherSignUp = (List<SignUpInfo>)binn.Deserialize(fss);
                    int c = 0;
                    while (c <= TeacherSignUp.Count - 1)
                    {
                        if (Username.Text == TeacherSignUp[c].username && Convert.ToString(Password.Password) == TeacherSignUp[c].password)
                        {
                          
                            Teacher obj = new Teacher(TeacherSignUp[c]);
                            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                            speechSynthesizer.Speak("Welcome" + TeacherSignUp[c].name);
                            obj.Show();
                            
                            this.Hide();
                            break;

                        }
                        else
                        {
                            c++;
                        }

                    }
                    fss.Close();
                    if (c == TeacherSignUp.Count)
                    {
                        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                        speechSynthesizer.Speak("Invalid Username or Password");
                    }
                }

                else
                {
                    Stream fs = File.Open("StudentLoginInfo.txt", FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    this.StudentSignUp = (List<SignUpInfo>)bin.Deserialize(fs);
                    int c = 0;
                    while (c <= StudentSignUp.Count - 1)
                    {
                        if (Username.Text == StudentSignUp[c].username && Convert.ToString(Password.Password) == StudentSignUp[c].password)
                        {
                          
                            Student obj = new Student(StudentSignUp[c]);
                            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                            speechSynthesizer.Speak("Welcome" + StudentSignUp[c].name);
                            obj.Show();
                            this.Hide();
                            break;

                        }
                        else
                        {
                            c++;
                        }

                    }
                    fs.Close();
                    if (c == StudentSignUp.Count)
                    {
                        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                        speechSynthesizer.Speak("Invalid Username or Password");
                    }
                }
            }
            }
           
     

        private void SignUpStudent_btn(object sender, RoutedEventArgs e)
        {
            SignUp obj = new SignUp();
            obj.Show();
            this.Show();
        }
    }
}
