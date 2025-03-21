using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Realisation.FileHandlers;
using Library.Realisation.MenuFacade;
using Library.Realisation.Storages;
using Microsoft.Extensions.DependencyInjection;
using Library.Abstractions.Factories;
using Library.Realisation.Models;
using Library.Realisation.Factories;
using Library.Abstractions;
using Library.Abstractions.Models;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;

namespace Library.Realisation
{
    public class App
    {
        IServiceProvider _provider;

        private readonly MenuProxi _menuProxi;

        private readonly JsonFileHandler _jsonFileHandler;
        private readonly CsvFileHandler _csvFileHandler;
        private readonly YamlFileHandler _yamlFileHandler;

        private readonly AccountStorage<BankAccount> _accountStorage;
        private readonly CategoryStorage<Category> _categoryStorage;
        private readonly OperationStorage<Operation> _operationStorage;

        private readonly AccountFactory _accountFactory;
        private readonly CategoryFactory _categoryFactory;
        private readonly OperationFactory _operationFactory;

        private readonly Processor _processor;


        public App()
        {
            _provider = Settings.ConfigureServices();

            _jsonFileHandler = _provider.GetService<JsonFileHandler>();
            _csvFileHandler = _provider.GetService<CsvFileHandler>();
            _yamlFileHandler = _provider.GetService<YamlFileHandler>();

            _accountStorage = _provider.GetService<AccountStorage<BankAccount>>();
            _categoryStorage = _provider.GetService<CategoryStorage<Category>>();
            _operationStorage = _provider.GetService<OperationStorage<Operation>>();

            _accountFactory = _provider.GetService<AccountFactory>();
            _categoryFactory = _provider.GetService<CategoryFactory>();
            _operationFactory = _provider.GetService<OperationFactory>();

            _menuProxi = _provider.GetService<MenuProxi>();

            _processor = _provider.GetService<Processor>();
        }

        public bool Solution()
        {
            ActionType startAction = _menuProxi.GetAction();
            IFileHandler fileHandler;

            if (startAction == ActionType.Import || startAction == ActionType.Export)
            {
                InstanceType type = _menuProxi.GetTypeOfData();

                FileType fileType = _menuProxi.GetFileType();
                fileHandler = fileType switch
                {
                    FileType.JSON => _jsonFileHandler,
                    FileType.CSV => _csvFileHandler,
                    FileType.YAML => _yamlFileHandler,
                };

                string filepath = _menuProxi.GetFilePath();

                if (startAction == ActionType.Import)
                {
                    switch (type)
                    {
                        case InstanceType.BankAccount:
                            {
                                var v = fileHandler.Load<BankAccount>(filepath);
                                if (v is null) 
                                {
                                    _menuProxi.FileErrorResponse();
                                }
                                Array.ForEach(fileHandler.Load<BankAccount>(filepath).ToArray(),
                                    x => _accountStorage.Add(x));
                                break;
                            }
                        case InstanceType.Category:
                            {
                                Array.ForEach(fileHandler.Load<Category>(filepath).ToArray(),
                                    x => _categoryStorage.Add(x));
                                break;
                            }
                        case InstanceType.Operation:
                            {
                                Array.ForEach(fileHandler.Load<Operation>(filepath).ToArray(),
                                    x => _operationStorage.Add(x));
                                break;
                            }
                    };
                }
                else
                {
                    switch (type)
                    {
                        case InstanceType.BankAccount:
                            fileHandler.Save(_accountStorage, filepath);
                            break;
                        case InstanceType.Category:
                            fileHandler.Save(_categoryStorage, filepath);
                            break;
                        case InstanceType.Operation:
                            fileHandler.Save(_operationStorage, filepath);
                            break;
                    }
                }
            }
            else if (startAction == ActionType.Exit)
            {
                return false;
            }
            else if (startAction == ActionType.ProcessData) 
            {
                _processor.Execute(_accountStorage, _operationStorage);
            }
            return true;
        }
        public void Start()
        {
            while (Solution())
            {
            }
        }
    }
}
