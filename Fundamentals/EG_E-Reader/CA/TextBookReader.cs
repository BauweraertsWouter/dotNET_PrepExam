using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class TextBookReader : IReader
    {
        private int currentPage;
        private int pageSize = 35;

        private TextBook Book {  get; set; }

        public TextBookReader(TextBook book)
        {
            this.Book = book;
        }

        public object Previous()
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            else currentPage = 1;

            return GetPage(currentPage);
        }

        public object Next()
        {
            double numberOfPages = Math.Ceiling((double)Book.Content.Length / pageSize);
            if ((double)currentPage < numberOfPages) currentPage++;
            else currentPage = 1;

            return GetPage(currentPage);
        }

        private object GetPage(int currentPage)
        {
            int remainingTextSize = Book.Content.Length - (pageSize * (currentPage - 1));
            if (remainingTextSize < 0) remainingTextSize = 0;

            return Book.Content.Substring((currentPage - 1) * pageSize, Math.Min(pageSize, remainingTextSize));
        }
    }
}
