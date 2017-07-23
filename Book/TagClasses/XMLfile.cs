using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Books;
using System.Xml.Linq;

namespace TagClasses
{
    class XMLfile
    {
        public string Path { get; set; }
        /// <summary>
        /// saving in xml file
        /// </summary>
        /// <param name="books">list of books</param>
        public void Save(List<Book> books)
        {
            if (!File.Exists(Path)) throw new Exception("there are no file for saving!");
            XDocument doc = new XDocument(Path);
            foreach(Book element in books)
            {
                doc.Add(new XElement("Book", new XAttribute("Name", element.Name), new XElement("Authors", element.Authors), new XElement("NumberOfPage", element.NumberOfPage), new XElement("YearEdition", element.YearEdition)));
            }

        }
        /// <summary>
        /// Loading from xml file
        /// </summary>
        /// <returns>list of book</returns>
        public List<Book> Load()
        {
            if (!File.Exists(Path)) throw new Exception("there are no file for saving!");
            XDocument doc = XDocument.Load(Path);
            List<Book> books = new List<Book>();
            foreach (XElement element in doc.Element("Book").Elements())
            {
                books.Add(new Book((Book)element.Elements("Book")));
            }
            return books;
        }
    }
}
