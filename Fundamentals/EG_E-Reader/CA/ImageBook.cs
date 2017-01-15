﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class ImageBook : Book
    {
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
    }
}
