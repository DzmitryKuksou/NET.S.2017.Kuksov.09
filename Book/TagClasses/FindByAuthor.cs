using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using InterfacesBooks;

namespace TagClasses
{
    class FindByAuthor : IFindBook
    {
        /// <summary>
        /// field
        /// </summary>
        private string author;

        /// <summary>
        /// c-or.
        /// </summary>
        /// <param name="name">Book name.</param>
        public FindByAuthor(string author)
        {
            if (author == null) throw new ArgumentNullException();
            this.author = author;
        }
        /// <summary>
        /// Comparing 
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>true or false</returns>
        public bool Find(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            return book.Authors == author;
        }
    }
}