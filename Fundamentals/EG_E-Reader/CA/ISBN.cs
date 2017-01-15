using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    sealed class ISBN
    {
        private static int prevYear;
        private static int prevNumber;
        private readonly int year;
        private readonly int number;

        public ISBN(int year, int number)
        {
            this.year = year;
            this.number = number;
        }

        public override string ToString()
        {
            return string.Format("{0:d4}-{1:d4}",
                this.year,
                this.number);
        }

        public static ISBN Parse(string isbnString)
        {
            if(System.Text.RegularExpressions.Regex.IsMatch(isbnString, @"^\d{4}-\d{4}$"))
            {
                int year = Int32.Parse(isbnString.Substring(0, 4));
                int number = Int32.Parse(isbnString.Substring(5, 4));
                return new ISBN(year, number);
            }else
            {
                throw new FormatException("Invalid ISBN-format!");
            }
        }

        public static bool TryParse(string isbnString, out ISBN isbn)
        {
            try
            {
                isbn = ISBN.Parse(isbnString);
                return true;
            }catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                isbn = null;
                return true;
            }
        }

        public static ISBN GetNewISBN()
        {
            if(prevYear != DateTime.Today.Year)
            {
                prevYear = DateTime.Today.Year;
                prevNumber = 0;
            }
            return new ISBN(prevYear, ++prevNumber);
        }
    }
}
