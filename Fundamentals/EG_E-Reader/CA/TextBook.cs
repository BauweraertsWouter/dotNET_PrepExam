using System;
using System.Linq;

namespace CA
{
    class TextBook : Book
    {
        public string Content { get; private set; }

        public TextBook(string title, string author, string content, BookFormat format = BookFormat.TXT)
            :base(title, author, format)
        {
            Content = content;
        }

        public override string GetInfo()
        {
            return string.Format("TextBook: '{0}', by {1} ({2} chars",
                Title, Author, Content.Count<char>());
        }
    }
}
