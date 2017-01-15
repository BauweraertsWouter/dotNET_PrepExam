using System;
using System.Linq;

namespace CA
{
    class TextBook : Book
    {
        private int pageSize = 35;
        private int currentPage;

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

        public override object Previous()
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            else currentPage = 1;

            return GetPage(currentPage);
        }

        public override object Next()
        {
            double numberOfPages = Math.Ceiling((double)Content.Length / pageSize);
            if ((double)currentPage < numberOfPages) currentPage++;
            else currentPage = 1;

            return GetPage(currentPage);
        }

        private object GetPage(int currentPage)
        {
            int remainingTextSize = Content.Length - (pageSize * (currentPage - 1));
            if (remainingTextSize < 0) remainingTextSize = 0;

            return Content.Substring((currentPage - 1) * pageSize, Math.Min(pageSize, remainingTextSize));
        }

        
    }
}
