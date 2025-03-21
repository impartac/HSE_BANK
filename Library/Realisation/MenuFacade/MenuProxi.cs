using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.MenuFacade
{
    public enum ActionType
    {
        Import,
        Export,
        Statistic,
        Analysis,
        ProcessData,
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
                    if (0 <= val  && val < 6) 
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

    }
}
