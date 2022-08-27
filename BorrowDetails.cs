using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Project2
{

    class BorrowDetails : Details
    {
        public int userId;
        public string userName;
        public string userAddress;
        public int borrowBookId;
        public DateTime borrowDate;
        public int borrowCount;
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>();

        private static int uniqueId = 0;

        public int Id
        {
            get => userId;

            set
            {
                userId = Id;
            }
        }

        public string Name
        {
            get => userName;

            set
            {
                userName = Name;
            }
        }

        void Details.AddBook()
        {
            throw new NotImplementedException();
        }

        void Details.RemoveBook()
        {
            throw new NotImplementedException();
        }

        public void SearchBook()
        {
            Book book = new Book();
            Console.Write("Please Enter The Particular Book Id for Search: ");
            int find = int.Parse(Console.ReadLine());

            if (Book.bookList.Exists(x => x.bookId == find))
            {
                foreach (Book searchId in Book.bookList)
                {
                    if (searchId.bookId == find)
                    {
                        Console.WriteLine("Searched Book infromation:-");
                        Console.WriteLine("Book id: {0}\n" +
                        "Book name: {1}\n" +
                        "Book price: {2}\n" +
                        "Book Count: {3}", searchId.bookId, searchId.bookName, searchId.bookPrice, searchId.bookCount);
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", find);
            }
        }

        public void Borrow()
        {
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            Console.WriteLine("User id: {0}", (borrow.userId = uniqueId + 1));
            Console.Write("Name: ");

            borrow.userName = Console.ReadLine();

            Console.Write("Book id: ");
            borrow.borrowBookId = int.Parse(Console.ReadLine());
            Console.Write("Number of Books: ");
            borrow.borrowCount = int.Parse(Console.ReadLine());
            Console.Write("Address: ");
            borrow.userAddress = Console.ReadLine();
            borrow.borrowDate = DateTime.Now;
            Console.WriteLine("Date - {0} and Time - {1}", borrow.borrowDate.ToShortDateString(), borrow.borrowDate.ToShortTimeString());
            //Console.WriteLine("Book Borrowed succesfully");

            if (Book.bookList.Exists(x => x.bookId == borrow.borrowBookId))
            {
                foreach (Book searchId in Book.bookList)
                {
                    if (searchId.bookCount >= searchId.bookCount - borrow.borrowCount && searchId.bookCount - borrow.borrowCount >= 0)
                    {
                        if (searchId.bookId == borrow.borrowBookId)
                        {
                            searchId.bookCount = searchId.bookCount - borrow.borrowCount;
                            Console.WriteLine("Number of {0} book remaining = {1}", searchId.bookName, searchId.bookCount);
                            Console.WriteLine("Book borrowed successfully by " + borrow.userName);
                            break;
                        }
                    }

                }

            }
            else
            {
                Console.WriteLine("Book id {0} not found", borrow.borrowBookId);
            }
            BorrowDetails.borrowList.Add(borrow);
        }

        public void ReturnBook()
        {
            Book book = new Book();
            Console.WriteLine("Enter following details: ");

            Console.Write("Book id: ");
            int returnId = int.Parse(Console.ReadLine());

            Console.Write("Number of Books: ");
            int returnCount = int.Parse(Console.ReadLine());

            if (Book.bookList.Exists(y => y.bookId == returnId))
            {
                foreach (Book addReturnBookCount in Book.bookList)
                {
                    if (addReturnBookCount.x >= returnCount + addReturnBookCount.bookCount)
                    {
                        if (addReturnBookCount.bookId == returnId)
                        {
                            addReturnBookCount.bookCount = addReturnBookCount.bookCount + returnCount;
                            Console.WriteLine($"{addReturnBookCount.bookName} book returned successfully!!!");
                            break;
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Count exists the actual count");
                        //break;
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Book id {0} not found", returnId);
            }
        }
    }
}
