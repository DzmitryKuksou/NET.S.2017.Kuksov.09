using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesBooks;
using Books;

namespace TagClasses
{
    public class CompareByAuthor:IComparer<Book>
    {
        /// <summary>
        /// comparing of books by author
        /// </summary>
        /// <param name="lhs">book1</param>
        /// <param name="rhs">book2</param>
        /// <returns>number</returns>
        public int Compare(Book lhs, Book rhs)
        {
            return lhs.Authors.CompareTo(rhs.Authors);
        }
    }
}
