using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Interface.Interfaces;
using DB_Interface.Models;


namespace ConsoleInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======");
            Console.WriteLine("Begin Run");
            Console.WriteLine("=======");
            Console.WriteLine();

            Console.WriteLine("All Records");
            Console.WriteLine("=======");
            Console.WriteLine();

            var records = Database.AllRecords<Author>();

            foreach(Author record in records)
            {
                Console.WriteLine($"{record.LastName}, {record.FirstName}: {record.Id}");
            }

            Console.WriteLine();
            Console.WriteLine("======");
            Console.WriteLine("CreateRecord(author)");
            Console.WriteLine();

            Author author = new Author
            {
                FirstName = "John",
                LastName = "Henry"
            };

            long recordID = Database.CreateRecord(author);
            Console.WriteLine($"Inserted Record {recordID}: {author.FirstName}");

            author = new Author
            {
                FirstName = "Jane",
                LastName = "Smith"
            };

            recordID = Database.CreateRecord(author);
            Console.WriteLine($"Inserted Record {recordID}: {author.FirstName}");
            

            records = Database.AllRecords<Author>();

            foreach (Author record in records)
            {
                Console.WriteLine($"{record.LastName}, {record.FirstName}: {record.Id}");
            }

            Console.WriteLine();
            Console.WriteLine("======");
            Console.WriteLine("GetRecord(n)");
            Console.WriteLine();

            Author entry = Database.GetRecord<Author>(recordID);
            Console.WriteLine($"{entry.LastName}, {entry.FirstName}: {entry.Id}");
            entry = Database.GetRecord<Author>(2);
            Console.WriteLine($"{entry.LastName}, {entry.FirstName}: {entry.Id}");

            entry.LastName = "Fixed if for you!";
            Console.WriteLine($"Updating Record {entry.Id}");
            if (Database.UpdateRecord(entry))
            {
                Console.WriteLine("Success!");
                Console.WriteLine($"{entry.Id}: {entry.LastName}");
            }
            else
            {
                Console.WriteLine("Failed!");
            }

            Console.WriteLine($"Deleting Record {entry.Id}.{entry.LastName}");
            if (Database.DeleteRecord(entry))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }

            records = Database.AllRecords<Author>();

            foreach (Author record in records)
            {
                Console.WriteLine($"{record.LastName}, {record.FirstName}: {record.Id}");
            }



            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();
        }
    }
}
