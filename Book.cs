using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Project2
{
    class Book : Details
    {
        public int bookId;
        public string bookName;
        public int bookPrice;
        public int bookCount;
        public int x;
        public static List<Book> bookList = new List<Book>();

        public int Id
        {
            get => bookId;

            set
            {
                bookId = Id;
            }
        }

        public string Name
        {
            get => bookName;

            set
            {
                bookName = Name;
            }
        }

        public void AddBook()
        {
            Book book = new Book();
            Console.WriteLine("Book Id: {0}", book.bookId = bookList.Count + 1);
            Console.Write("Book Name: ");
            book.bookName = Console.ReadLine();
            Console.Write("Enter the MRP of Book: ");
            book.bookPrice = int.Parse(Console.ReadLine());
            Console.Write("Number of Books You want Add: ");
            book.x = book.bookCount = int.Parse(Console.ReadLine());

            bookList.Add(book);
        }

        public void RemoveBook()
        {
            Book book = new Book();
            Console.Write("Enter Book id to delete : ");

            int Del = int.Parse(Console.ReadLine());

            if (bookList.Exists(x => x.bookId == Del))
            {
                var bookToDelete = GetBook(Del);
                bookList.Remove(bookToDelete);
                Console.WriteLine("Book {0} with id {1} has been deleted", bookToDelete.bookName, Del);
            }
            else
            {
                Console.WriteLine("Invalid Book id");
            }

            //bookList.Add(book);
        }

        private Book GetBook(int id)
        {
            foreach (Book eachBook in bookList)
            {
                if (eachBook.bookId == id)
                    return eachBook;
            }

            return null;
        }

        void Details.SearchBook()
        {
            throw new NotImplementedException();
        }

        void Details.Borrow()
        {
            throw new NotImplementedException();
        }

        void Details.ReturnBook()
        {
            throw new NotImplementedException();
        }
    }
}
