using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;

namespace InterfacesBooks
{
    public interface IStorageBook<Book>
    {
        void Save(List<Book> books);
        List<Book> Load();
    }
    public interface IFindBook
    {
        bool Find(Book book);
    }
}
