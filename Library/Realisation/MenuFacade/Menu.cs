
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Realisation.MenuFacade
{
    public class Menu
    {
        public Menu() { }
        public void NewLine()
        {
            Console.WriteLine();
        }


        public void StartMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Import");
            Console.WriteLine("2. Export");
            Console.WriteLine("3. Analysis");
            Console.WriteLine("4. Process Data");
            Console.WriteLine("5. Create");
            Console.WriteLine("6. Update");
            Console.WriteLine("7. Delete");
            Console.WriteLine("8. Exit");
        }
        public void WrongCommand()
        {
            Console.WriteLine(" Wrong command. Try again.");
        }

        public void TypeRequest()
        {
            Console.WriteLine("Choose type of data:");
            Console.WriteLine("1. BankAccount");
            Console.WriteLine("2. Category");
            Console.WriteLine("3. Operation");
        }

        public void FileTypeRequest()
        {
            Console.WriteLine("Choose type of file:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. CSV");
            Console.WriteLine("3. YAML");
        }
        public void FilePathRequest()
        {
            Console.WriteLine("Write file path");
        }

        public void FileErrorResponse()
        {
            Console.WriteLine("There is an exception. while reading file.");
        }

        public void NameRequest() 
        {
            Console.WriteLine("Write Name");
        }
        public void GuidRequest(string field) 
        {
            Console.WriteLine($"Write GUID for {field}");
        }
        public void WrongGuidResponse() 
        {
            Console.WriteLine("Wrong GUID. Try again");
        }

        public void FloatRequest(string field)
        {
            Console.WriteLine($"Write float {field}");
        }
        public void WrongAmountResponse()
        {
            Console.WriteLine("Wrong float. Try again");
        }
        public void WrongOperationResponse() 
        {
            Console.WriteLine("Wrong operation");
        }
        public void CreateString(Guid id) 
        {
            Console.WriteLine($"Created. Id = {id}");
        }

        public void StringRequest()
        {
            Console.WriteLine("OK");
        }
    }
}
