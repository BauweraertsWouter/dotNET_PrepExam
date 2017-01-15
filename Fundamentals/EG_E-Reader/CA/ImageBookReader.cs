using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class ImageBookReader : IReader
    {
        private ImageBook Book { get; set; }
        private int currentPage;

        public ImageBookReader(ImageBook book)
        {
            this.Book = book;
        }

        public object Previous()
        {
            if (currentPage > 1 && currentPage <= Book.Images.Count())
                currentPage--;
            else
                currentPage = 1;

            return GetPage(currentPage);
        }

        public object Next()
        {
            if (currentPage > 0 && currentPage < Book.Images.Count())
                currentPage++;
            else
                currentPage = 1;
            return GetPage(currentPage);
        }

        private object GetPage(int currentPage)
        {
            return Book.Images.ElementAt(currentPage - 1);
        }
    }
}
