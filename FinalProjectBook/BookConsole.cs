using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBook
{
    public  class BookConsole
    {
        public static void Main(string[] args)
        {
            BookManager bookManager = new BookManager();
            while (true)
            {
                Console.WriteLine("this is book manager program. Choose from the following options");
                Console.WriteLine("1. Add A New Book");
                Console.WriteLine("2. Display All The Books");
                Console.WriteLine("3. Search for a Book by Title");
                Console.WriteLine("0. Exit");

                int number = Convert.ToInt32(Console.ReadLine());
                if(number < 0 || number > 3)
                {
                    Console.WriteLine("Invalid input.");
                }

                switch (number)
                {
                    case 0: Console.WriteLine("thank you for using book manager program");
                        return;
                    case 1: AddBook(bookManager); break;
                    case 2: bookManager.DisplayBookList(); break;
                    case 3: SearchBook(bookManager); break;
                    default: Console.WriteLine("Invalid input, try again."); break;
                }
            }
        }

        public static void AddBook(BookManager bookManager)
        {
            Console.Write("Enter the book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the publication year: ");
            string temp = Console.ReadLine();
            if (IsInteger(temp))
            {
                int year = Convert.ToInt32(temp);
                bookManager.AddBook(title, name, year);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        public static void SearchBook(BookManager bookManager)
        {
            Console.Write("Enter the book title to search for: ");
            string name = Console.ReadLine();
            var book = bookManager.GetBook(name);
            if(book == null)
            {
                Console.WriteLine("book with that title does not exist.");
            }
            else
            {
                Console.WriteLine("Book found. Here are the details: ");
                Console.WriteLine(book.Title + " " + book.Author + " " + book.Year);
            }
        }

        private static bool IsInteger(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
