using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    internal static class ExtensionMethods
    {
        internal static string ToCSV(this Book b)
        {
            return string.Format("{0};{1};{2};{3}",
                b.ISBN, b.Title, b.Author, b.Format);
        }

        
    }
}
