using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    //A class that has a list of books and different operations for them.
    internal class BookAdmin
    {
        //variable that holds the list of books. (empty in the beginning)
        private List<Book> bookList = new List<Book>();

        //Gets the title, the author, and the year from the arguments of the method
        //Creates a new Book object, and adds it to the list
        public void AddBook(string title, string author, int year) {
            bookList.Add(new Book(title, author, year));
        }

        //Returns the book list variable
        public List<Book> GetBookList()
        {
            return bookList;
        }

        //Gets the title of the book from the argument 
        //Searches the book list by title
        //Returns the book if it exists in the list, otherwise it returns null
        public Book? GetBook(string title)
        {
            return bookList.Find((book) => book.title.ToUpper() == title.ToUpper());
        }

    }
}
