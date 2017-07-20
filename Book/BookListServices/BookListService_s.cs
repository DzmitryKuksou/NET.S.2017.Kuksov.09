using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using InterfacesBooks;

namespace BookListService_s
{
    public class BookListService
    {
        /// <summary>
        /// temporary storage
        /// </summary>
        List<Book> bookStore;
        /// <summary>
        /// c-or
        /// </summary>>
        public BookListService()
        {
            bookStore = new List<Book>();
        }
        /// <summary>
        /// adding book
        /// </summary>
        /// <param name="book">book</param>
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            bookStore.Add(book);
        }
        /// <summary>
        /// Remove Book
        /// </summary>
        /// <param name="book">book</param>
        public bool RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            return bookStore.Remove(book);
        }
        /// <summary>
        /// sorting by tag
        /// </summary>
        /// <param name="compare">tag of sort</param>
        public void SortBooksByTag(IComparer<Book> compare)
        {
            if (compare == null) throw new ArgumentNullException();
            this.bookStore.Sort(compare);
        }
        /// <summary>
        /// finding book in list
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>true or false</returns>
        public Book FindBookByTag(IFindBook book)
        {
            if (book == null) throw new ArgumentNullException();
            foreach (Book element in bookStore)
                if (book.Find(element)) return element;
            return null;
        }
        /// <summary>
        /// saving to bin file
        /// </summary>
        /// <param name="store">store to save</param>
        public void Save(IStorageBook<Book> store)
        {
            if (store == null) throw new ArgumentNullException();
            store.Save(bookStore);
        }
        /// <summary>
        /// loading from store
        /// </summary>
        /// <param name="store">store to load</param>
        public void Load(IStorageBook<Book> store)
        {
            if (store == null) throw new ArgumentNullException();
            List<Book> books = store.Load();
            foreach (Book element in books)
                bookStore.Add(element);
        }
        /// <summary>
        /// converting to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (Book element in bookStore)
                str.Append(element.ToString());
            return str.ToString();
        }
    }
}

