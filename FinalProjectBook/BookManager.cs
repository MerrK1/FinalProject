using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectBook
{
    public class BookManager
    {
        private List<Book> bookList = new List<Book>();

        public void AddBook(string name, String author, int year)
        {
            bookList.Add(new Book(name, author, year));
        }

        public void DisplayBookList()
        {
            if(bookList.Count == 0)
            {
                Console.WriteLine("no books in the list yet.");
                return;
            }
            foreach(Book book in bookList)
            {
                Console.WriteLine(book.Title + " " + book.Author + " " + book.Year);
            }
        }

        public Book GetBook(string name)
        {
            foreach(Book book in bookList)
            {
                if (book.Title == name)
                {
                    return book;
                }
            }
            return null;
        }
    }
}
