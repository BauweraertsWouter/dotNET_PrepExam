using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    abstract class Book : INavigatable
    {
        //private int isbn;

        /*public int ISBN {
            get { return isbn; }
            set { this.isbn = value; }
            }*/
        public ISBN ISBN { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public BookFormat Format { get; private set; }

        //public Book(){}

        public Book(string title, string author, BookFormat format = BookFormat.TXT)
        {
            ISBN = ISBN.GetNewISBN();
            Title = title;
            Author = author;
            Format = format;
        }

        public abstract String GetInfo();

        public sealed override string ToString()
        {
            return string.Format("Book: '{0}', by '{1} ({2}, {3})", this.Title, this.Author, this.ISBN, this.Format);
        }

        public abstract object Previous();
        public abstract object Next();
    }
}
