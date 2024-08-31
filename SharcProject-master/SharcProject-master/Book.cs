using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharcProject
{
    [Serializable()]
    class Book
    {

       
        public Book(string bookName, string link)
        {
            BookName = bookName;
            Link = link;
        }

        string BookName
        {
            set;
            get;
        }
        string Link
        {
            set;
            get;

        }


    }
}
