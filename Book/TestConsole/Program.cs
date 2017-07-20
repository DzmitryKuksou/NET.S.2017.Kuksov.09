using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using BookListService_s;
using BinaryFileStore;
using TagClasses;
using InterfacesBooks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService();
            Book b1 = new Book("zzzz", "y", "1111", 123);
            Book b2 = new Book("www", "ww", "1845", 990);
            Book b3 = new Book("www","ww", "1845", 990);
            Console.WriteLine(Book.Compare(b1, b2, new CompareByAuthor())); 

            Console.WriteLine(b1.Equals(b2));
            Console.WriteLine(b2.Equals(b3)); 
            service.AddBook(b1);
            service.AddBook(b2); 
            service.AddBook(b3);                     
            service.RemoveBook(b1); 
            Console.WriteLine(service.FindBookByTag(new FindByName("www")));
            service.SortBooksByTag(new CompareByAuthor());
            Binaryfile VV = new Binaryfile("C:/Users/User/Desktop/GitHub/NET.S.2017.Kuksov.09/Book/TestConsole/Store.txt");
            service.Save(VV);
        }
    }
}
