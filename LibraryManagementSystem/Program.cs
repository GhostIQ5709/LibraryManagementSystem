using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Run the library management system
            library.Run();
            Console.ReadKey();
        }
    }
}
