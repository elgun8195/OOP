using GeneralPractice.Models;
using System;

namespace GeneralPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(typeof(User));
            //byte role;
            //bool isNum;
            //do
            //{
            //    Console.WriteLine("Role (1. Admin, 2.Member):");
            //    string roleStr = Console.ReadLine();
            //    isNum = byte.TryParse(roleStr, out role);
            //} while (!isNum || !Enum.IsDefined(typeof(Role), role));

            Book book1 = new Book("test", "testov", 255);
            Book book2 = new Book("test2", "testov2", 2525);            
            Library library = new Library(2);
            bool check = true;
            do
            {
            Console.WriteLine("======= MENU ======");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Get book by id");
            Console.WriteLine("3. Get all books");
            Console.WriteLine("4. Delete book by id");
            Console.WriteLine("5. Edit book name");
            Console.WriteLine("6. Filter by page count");
            Console.WriteLine("0. Quit");
            string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        library.AddBook(book1);
                        library.AddBook(book2);
                        Console.WriteLine();
                        break;
                case "2":
                    library.AddBook(book1);
                    library.GetBookById(2);


                    break;
                case "3":

                    break;
                case "0":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("wrong input!!!");
                        break;
                }

            } while (false);
        }
    }
}
