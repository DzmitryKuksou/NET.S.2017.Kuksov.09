using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using InterfacesBooks;

namespace TagClasses
{
    public class FindByName : IFindBook
    {
        /// <summary>
        /// field
        /// </summary>
        private string name;

        /// <summary>
        /// c-or.
        /// </summary>
        /// <param name="name">Book name.</param>
        public FindByName(string name)
        {
            if (name == null) throw new ArgumentNullException();
            this.name = name;
        }
        /// <summary>
        /// Comparing 
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>true or false</returns>
        public bool Find(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            return book.Name == name;
        }
    }
}
