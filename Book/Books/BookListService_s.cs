using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;

namespace BookListService_s
{
    public class BookListService
    {
        /// <summary>
        /// storage 
        /// </summary>
        private string file = "C:/Users/User/Desktop/GitHub/NET.S.2017.Kuksov.09/Book/BookListStorage.txt";
        /// <summary>
        /// Add Book
        /// </summary>
        /// <param name="book">book</param>
        private Book[] books = new Book[10];
        private static int count;
        public BookListService(Book book)
        {
            books[count++] = book;
        }
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            if (find(book) == false) throw new Exception("There are no this book");
            BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate));
            writer.Write(book.ToString("G"));
            writer.Close();
        }
        /// <summary>
        /// Remove Book
        /// </summary>
        /// <param name="book">book</param>
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            if(find(book) == false) throw new Exception("There are no this book");
            BinaryWriter writer = new BinaryWriter(File.Open(file, FileMode.OpenOrCreate));
            writer.Write(str);
            writer.Close();
        }
        public void FindBookByTag(string name)
        {
            //to do
        }
        public void SortBooksByTag(string str)
        {
            //to do
        }
        private bool find(Book book)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (book.Equals(books[i]) == true) return true;
            }
            return false;
        }
    }
}

