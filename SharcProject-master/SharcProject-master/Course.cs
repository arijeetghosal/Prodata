using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharcProject
{
    [Serializable()]
    public class Course
    {
        public Course(string teachername, string coursename, string courseDescription)
        {
            Teachername = teachername;
            Coursename = coursename;
            CourseDescription = courseDescription;
        }

        string Teachername
        {
            set;
            get;
        }
        string Coursename
        {
            set;
            get;

        }
        string CourseDescription
        {
            set;
            get;

        }
        public override string ToString()
        {
            return Teachername + "  " + Coursename + "  " + CourseDescription;
        }
        
        



    }
}
