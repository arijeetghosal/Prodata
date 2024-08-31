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

namespace SharcProject
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window 
    {
       
        SignUpInfo std;
        public Profile(SignUpInfo std)
        {
            this.std = std;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Username_(object sender, RoutedEventArgs e)
        {
            Usernametxt.Text = std.username;

        }
            
      
            
 
        private void Email_Loaded(object sender, RoutedEventArgs e)
        {
            Emailtxt.Text = std.Email;
        
        }
    }
}
