using System;
using System.Collections.Generic;

namespace Capstone_Project2
{
    class Program
    {
        static void details()
        {
            if (Book.bookList.Count == 0)
            {
                Console.WriteLine("No books to display");
                return;
            }

            foreach (Book searchId in Book.bookList)
            {
                Console.WriteLine("Book infromation:-");
                Console.WriteLine("Book id: {0}\n" +
                "Book name: {1}\n" +
                "Book price: {2}\n" +
                "Book Count: {3}", searchId.bookId, searchId.bookName, searchId.bookPrice, searchId.bookCount);
                Console.WriteLine();
            }
        }

        static void PerformOperation(Details details)
        {
            bool close = true;
            while (close)
            {
                Console.WriteLine("\nOption To Select\n" +
                                    "1)Press 1 to Add book\n" +
                                    "2)Press 2 to Delete book\n" +
                                    "3)Press 3 to Search book\n" +
                                    "4)Press 4 to Borrow book\n" +
                                    "5)Press 5 to Return book\n" +
                                    "6)Press 6 to get the details of all books\n" +
                                    "7)Logout\n");
                Console.WriteLine("--------------------------");

                Console.Write("Enter the Option you want to perform: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            if (details is Book)
                            {
                                details.AddBook();
                            }
                            else
                            {
                                Console.WriteLine("You are not allowed to perform this operation. Sorry...\n");
                            }

                            break;
                        }

                    case 2:
                        {
                            if (details is Book)
                            {
                                details.RemoveBook();
                            }
                            else
                            {
                                Console.WriteLine("You are not allowed to perform this operation. Sorry...\n");
                            }

                            break;
                        }

                    case 3:
                        {
                            details = new BorrowDetails();

                            details.SearchBook();
                            break;
                        }

                    case 4:
                        {
                            details = new BorrowDetails();

                            details.Borrow();
                            break;
                        }

                    case 5:
                        {
                            details = new BorrowDetails();

                            details.ReturnBook();
                            break;
                        }

                    case 6:
                        {
                            Program.details();
                            break;
                        }

                    case 7:
                        return;

                    case 0:
                        Console.WriteLine("Invalid option\n Please Retry...");
                        break;
                };

            }
        }

        static void Main(string[] args)
        {
            /*
            List<Book> bookList = new List<Book>();
            List<BorrowDetails> borrowList = new List<BorrowDetails>();
            Book book = new Book();
            BorrowDetails borrow = new BorrowDetails();
            */

            //static void Main(string[] args)

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("--------------------------- Welcome to MyLibrary --------------------------- \n");

                Console.WriteLine("1. Login \n2. Exit\n");
                int value = int.Parse(Console.ReadLine());

                if (value == 1)
                {
                    Console.Write("Please Enter the UserName (Admin/User): ");
                    string username = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();

                    Details details = new BorrowDetails();

                    if (username == "Admin" && password == "admin@123")
                        details = new Book();
                    else if (username == "User" && password == "user@123")
                        details = new BorrowDetails();
                    else
                    {
                        Console.WriteLine("Incorrect username or password. Please try again...");
                        continue;
                    }

                    PerformOperation(details);
                }
                else
                    return;

            }

            Console.ReadLine();

        }
    }
}
