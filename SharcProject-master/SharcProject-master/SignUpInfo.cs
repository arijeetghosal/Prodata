using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharcProject
{
    [Serializable()]
    public class SignUpInfo
    {
       
        public SignUpInfo(string name, string username, string email, string password, bool gender, string dob)
        {
            this.name = name;
            this.username = username;
            Email = email;
            this.password = password;
            this.gender = gender;
            Dob = dob;
                        
        }

        public string name { get; set; }
        public string username { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public bool gender { get; set; }
        public string Dob { get; set; }
        public List<Course> cou { get; set; }
      
    }
}
