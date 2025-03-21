using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.MenuFacade
{
    public enum ActionType
    {
        Import,
        Export,
        Analysis,
        ProcessData,
        Create,
        Update,
        Delete,
        Exit
    }
    public enum InstanceType
    {
        BankAccount,
        Category,
        Operation
    }
    public enum FileType 
    {
        JSON,
        CSV,
        YAML
    }
    public class MenuProxi
    {
        Menu _menu;

        public MenuProxi(Menu menu)
        {
            _menu = menu;
        }

        public ActionType GetAction()
        {
            ConsoleKey action = ConsoleKey.None;
            while (true)
            {
                _menu.StartMenu();
                action = Console.ReadKey().Key;
                _menu.NewLine();
                try
                {
                    int val = (int)action - 49;
                    if (0 <= val  && val < 8) 
                    {
                        return (ActionType)val;
                    }
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    _menu.WrongCommand();
                }
            }
        }

        public InstanceType GetTypeOfData() 
        {
            ConsoleKey action = ConsoleKey.None;
            while (true)
            {
                _menu.TypeRequest();
                action = Console.ReadKey().Key;
                _menu.NewLine();
                try
                {
                    int val = (int)action - 49;
                    if (0 <= val && val < 3)
                    {
                        return (InstanceType)val;
                    }
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    _menu.WrongCommand();
                }
            }
        }

        public FileType GetFileType() 
        {
            ConsoleKey action = ConsoleKey.None;
            while (true)
            {
                _menu.FileTypeRequest();
                action = Console.ReadKey().Key;
                _menu.NewLine();
                try
                {
                    int val = (int)action - 49;
                    if (0 <= val && val < 3)
                    {
                        return (FileType)val;
                    }
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    _menu.WrongCommand();
                }
            }
        }

        public string GetFilePath() 
        {
            _menu.FilePathRequest();
            return Console.ReadLine();
        }

        public void FileErrorResponse()
        {
            _menu.FileErrorResponse();
        }

        public string GetName() 
        {
            _menu.NameRequest();
            return Console.ReadLine();
        }


        public Guid GetGuid(string field)
        {
            _menu.GuidRequest(field);
            string input = Console.ReadLine();
            Guid guid = Guid.Empty;
            while (!Guid.TryParse(input, out guid)) 
            {
                _menu.WrongGuidResponse();
                input = Console.ReadLine();
            }
            return guid;
        }

        public float GetFloat(string field) 
        {
            _menu.FloatRequest(field);
            string input = Console.ReadLine();
            float amount = 0;
            while (!float.TryParse(input, out amount))
            {
                _menu.WrongAmountResponse();
                input = Console.ReadLine();
            }
            return amount;
        }
        public void WrongOperation() 
        {
            _menu.WrongOperationResponse();
        }

        public void WrongGuid() 
        {
            _menu.WrongGuidResponse();
        }
        public void CreateString(Guid id) 
        {
            _menu.CreateString(id);
        }
        public void SendOK() 
        {
            _menu.StringRequest();
        }
    }
}
