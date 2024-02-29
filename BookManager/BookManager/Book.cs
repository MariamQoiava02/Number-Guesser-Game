using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    //An object of this class holds information about books. 
    internal class Book
    {
        public string title;
        public string author;
        public int year;

        public Book(string title, string author, int year)
        {
            this.title = title; 
            this.author = author;
            this.year = year;
        }
    }
}
