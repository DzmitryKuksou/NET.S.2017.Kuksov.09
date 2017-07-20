using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesBooks;
using Books;

namespace BinaryFileStore
{
    public class Binaryfile:IStorageBook<Book>
    {
        /// <summary>
        /// file
        /// </summary>
        private string path;
        /// <summary>
        /// c-or
        /// </summary>
        /// <param name="path">file</param>
        public Binaryfile(string paths)
        {
            if(paths == null) throw new ArgumentNullException();
            if (!File.Exists(paths)) throw new ArgumentNullException();
            this.path = paths;
        }
        /// <summary>
        /// load from file
        /// </summary>
        /// <returns>books</returns>
        public List<Book> Load()
        {
            List<Book> books = new List<Book>();
            string name, author, year;
            int pages;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    name = reader.ReadString();
                    author = reader.ReadString();
                    year = reader.ReadString();
                    pages = reader.ReadInt32();

                    books.Add(new Book(name, author, year, pages));
                }
            }

            return books;
        }
        /// <summary>
        /// saving in file
        /// </summary>
        /// <param name="books">list of books</param>
        public void Save(List<Book> books)
        {
            if (books == null) throw new ArgumentNullException();
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book element in books)
                {
                    writer.Write(element.Name);
                    writer.Write(element.YearEdition);
                    writer.Write(element.Authors);
                    writer.Write(element.NumberOfPage);
                    writer.Write("----");
                }
            }
        }
        public override string ToString()
        {
            return path;
        }
    }
}
