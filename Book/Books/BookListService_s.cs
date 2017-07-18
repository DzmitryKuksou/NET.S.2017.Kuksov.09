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
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
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
            String str = String.Empty;
            StringBuilder str1 = new StringBuilder();
            BinaryReader reader = new BinaryReader(File.Open(file, FileMode.OpenOrCreate));
            while (reader.PeekChar() > -1)
            {
                str = str1.Append(reader.Read().ToString()).ToString();
            }
            if (str.Contains(book.ToString("G")) == false) throw new Exception("There are no this book");
            else str.Replace(book.ToString("G"), "");
            reader.Close();
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
    }
}

