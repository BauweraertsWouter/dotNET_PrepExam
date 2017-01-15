using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new TextBook(title: "C# Language", author: "Kdg", content: "C# is one of the programming languages designed for the Common Language Infrastructure");
            Console.WriteLine(b1.GetInfo());
            Console.WriteLine(b1.ToString());
            Console.WriteLine();

            Book b2 = new TextBook(title: "Title2",author: "Autor2",content: "Content2");
            if (b2 != null)
            {
                Console.WriteLine(b2.GetInfo());
                Console.WriteLine(b2.ToString());
            }

            char[] images = { 'A', 'B', 'C', 'D' };
            ImageBook ib1 = new ImageBook("Some images presentated as chars", "KdG", images);
            Console.WriteLine(ib1.GetInfo());

            Book b3 = ib1;
            Console.WriteLine(b3.ToString());

            string text = "C# is one of the programming languages designed for the Common Language Infrastructure";
            IReader tb = new TextBookReader(new TextBook("C# Language", "KdG", text, BookFormat.PDF));
            Console.WriteLine(tb.ToString());

            Console.WriteLine("Next: " + tb.Next());
            Console.WriteLine("Next: " + tb.Next());
            Console.WriteLine("Next: " + tb.Next());
            Console.WriteLine("Previous: " + tb.Previous());
            Console.WriteLine("Next: " + tb.Next());
            Console.WriteLine("Next: " + tb.Next());
            Console.WriteLine("Next: " + tb.Next());

            Console.WriteLine();

            char[] images2 = { 'A', 'B', 'C', 'D' };
            IReader ib2 = new ImageBookReader(new ImageBook("Some Images", "KdG", images));
            Console.WriteLine(ib2.ToString());

            Console.WriteLine("Next: " + ib2.Next());
            Console.WriteLine("Next: " + ib2.Next());
            Console.WriteLine("Next: " + ib2.Next());
            Console.WriteLine("Previous: " + ib2.Previous());
            Console.WriteLine("Next: " + ib2.Next());
            Console.WriteLine("Next: " + ib2.Next());
            Console.WriteLine("Next: " + ib2.Next());

            Console.ReadLine();
        }
    }
}
