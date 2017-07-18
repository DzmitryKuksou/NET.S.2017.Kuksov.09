using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using BookListService_s;

namespace Books
{
    public class Book: ICloneable, IFormattable
    {
        /// <summary>
        /// storage of book
        /// </summary>
        private BookListService storage;
        static int count;
        private int id;
        /// <summary>
        /// Properties
        /// </summary>
        public string Name { get; private set; }
        public string Authors { get; private set; }
        public string YearEdition { get; private set; }
        public string NumberOfPage { get; private set; }
        /// <summary>
        /// c-or
        /// </summary>
        static Book()
        {
            BookListService storage = new BookListService();
            count++;
        } 
        /// <summary>
        /// C-OR
        /// </summary>
        /// <param name="name">name of book</param>
        /// <param name="authors">authors of book</param>
        /// <param name="yearEdition"> year edition</param>
        /// <param name="numberOfPage">number of page</param>
        public Book(string name, string authors,  string yearEdition, string numberOfPage)
        {
            if (name == null || authors == null || yearEdition == null || numberOfPage == null) throw new ArgumentNullException();
            Name = name;
            Authors = authors;
            YearEdition = yearEdition;
            NumberOfPage = numberOfPage;
            id = count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Book book = obj as Book;
            if (book == null) throw new ArgumentException();
            if (String.Equals(Name, book.Name) && String.Equals(YearEdition, book.YearEdition) && String.Equals(NumberOfPage, book.NumberOfPage) && String.Equals(Authors, book.Authors)) //== true && SurName == book.SurName && Authors = book.Authors && YearEdition = book.YearEdition && NumberOfPage == book.NumberOfPage)
                return true;
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return id;
        }
        /// <summary>
        /// converting in format string
        /// </summary>
        /// <returns>string format</returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// return string format
        /// </summary>
        /// <param name="format">format</param>
        /// <returns>string format</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// return string format
        /// </summary>
        /// <param name="format">format</param>
        /// <param name="provider">provider format</param>
        /// <returns>string format</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            switch (format.ToUpperInvariant())
            {
                case "G":
                    return $"Name: {Name}, authors: {Authors}, year edition: {YearEdition}, number of page: {NumberOfPage}";
                case "P":
                    return $"Name: {Name}, authors: {Authors}";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
        /// <summary>
        /// return new equal book
        /// </summary>
        /// <returns>new book</returns>
        public Book Clone()
        {
            return new Book(Name, Authors, YearEdition, NumberOfPage);
        }
        /// <summary>
        /// return new equal book
        /// </summary>
        /// <returns>new book</returns>
        object ICloneable.Clone()
        {
            return new Book(Name, Authors, YearEdition, NumberOfPage);
        }
    }
}
