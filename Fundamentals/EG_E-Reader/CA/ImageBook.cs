using System;
using System.Collections.Generic;
using System.Linq;

namespace CA
{
    class ImageBook : Book
    {
        private int currentPage;
        public IEnumerable<char> Images { get; private set; }

        public ImageBook(string title, string author, IEnumerable<char> images)
            :base(title, author, BookFormat.CBR)
        {
            Images = images;
        }

        public override string GetInfo()
        {
            return string.Format("ImageBook: '{0}', by {1} ({2} pics)", this.Title, this.Author, this.Images.Count<char>());
        }

        public override object Previous()
        {
            if (currentPage > 1 && currentPage <= Images.Count())
                currentPage--;
            else
                currentPage = 1;

            return GetPage(currentPage);
        }

        public override object Next()
        {
            if (currentPage > 0 && currentPage < Images.Count())
                currentPage++;
            else
                currentPage = 1;
            return GetPage(currentPage);
        }

        private object GetPage(int currentPage)
        {
            return Images.ElementAt(currentPage -1);
        }

        
    }
}
