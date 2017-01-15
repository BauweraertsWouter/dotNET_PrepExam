using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class BookReader : IReader
    {
        private delegate object Navigate();

        private Navigate previousNavHandler;
        private Navigate nextNavHandler;

        public BookReader(Book bookToRead)
        {
            this.LoadBook(bookToRead);
        }

        private void LoadBook(Book bookToRead)
        {
            IReader reader = null;

            TextBook textBook = bookToRead as TextBook;
            if (textBook != null)
                reader = new TextBookReader(textBook);
            else
            {
                ImageBook imageBook = bookToRead as ImageBook;
                if (imageBook != null)
                {
                    reader = new ImageBookReader(imageBook);
                }
            }

            if (reader != null)
            {
                previousNavHandler = reader.Previous;
                nextNavHandler = reader.Next;
            }
            else throw new InvalidCastException("Unable to load the book");
        }

        public object Previous()
        {
            return previousNavHandler;
        }

        public object Next()
        {
            return nextNavHandler;
        }
    }
}
