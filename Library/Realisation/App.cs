using System;
using System.Collections.Generic;
using System.Linq;
using Library.Realisation.FileHandlers;
using Library.Realisation.MenuFacade;
using Library.Realisation.Storages;
using Microsoft.Extensions.DependencyInjection;
using Library.Realisation.Models;
using Library.Realisation.Factories;
using Library.Abstractions;
using Library.Abstractions.Models;
using Library.Realisation.Analytics;

namespace Library.Realisation
{
    public class App
    {
        private readonly IServiceProvider _provider;

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

        private readonly AnalyticsFacade _analyticsFacade;

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

            _menuProxi = _provider.GetService<MenuProxi>();

            _processor = _provider.GetService<Processor>();

            _accountFactory = _provider.GetService<AccountFactory>();
            _categoryFactory = _provider.GetService<CategoryFactory>();
            _operationFactory = _provider.GetService<OperationFactory>();

            _analyticsFacade = _provider.GetService<AnalyticsFacade>();
        }

        public bool Solution()
        {
            ActionType startAction = _menuProxi.GetAction();

            switch (startAction)
            {
                case ActionType.Import:
                    HandleImport();
                    break;

                case ActionType.Export:
                    HandleExport();
                    break;

                case ActionType.ProcessData:
                    _processor.Execute(_accountStorage, _operationStorage);
                    break;
                case ActionType.Analysis:
                    foreach (var v in _analyticsFacade.Execute(_accountStorage, _categoryStorage, _operationStorage)) 
                    {
                        Console.WriteLine(v);
                    }
                    break;

                case ActionType.Create:
                    HandleCreate();
                    break;
                case ActionType.Update:
                    HandleUpdate();
                    break;
                case ActionType.Delete:
                    HandleDelete();
                    break;

                case ActionType.Exit:
                    _menuProxi.SendOK();
                    return false;
            }

            return true;
        }
        private void HandleDelete() 
        {
            InstanceType type = _menuProxi.GetTypeOfData();
            Guid id = _menuProxi.GetGuid("id");
            switch (type)
            {
                case InstanceType.BankAccount:
                    if (_accountStorage[id] == null)
                    {
                        _menuProxi.WrongGuid();
                        return;
                    }
                    _accountStorage.Remove(id);
                    break;

                case InstanceType.Category:
                    if (_categoryStorage[id] == null)
                    {
                        _menuProxi.WrongGuid();
                        return;
                    }
                    _categoryStorage.Remove(id);
                    break;

                case InstanceType.Operation:
                    if (_operationStorage[id] == null)
                    {
                        _menuProxi.WrongGuid();
                        return;
                    }
                    _operationStorage.Remove(id);
                    break;
            }
        }
        private void HandleCreate()
        {
            InstanceType type = _menuProxi.GetTypeOfData();
            string name;
            switch (type)
            {
                case InstanceType.BankAccount:
                    name = _menuProxi.GetName();
                    var account = _accountFactory.Create(name);
                    _accountStorage.Add(account);
                    _menuProxi.CreateString(account.Id);
                    break;

                case InstanceType.Category:
                    name = _menuProxi.GetName();
                    var category = _categoryFactory.Create(name);
                    _categoryStorage.Add(category);
                    _menuProxi.CreateString(category.Id);
                    break;

                case InstanceType.Operation:
                    Guid from = _menuProxi.GetGuid("FROM");
                    Guid to = _menuProxi.GetGuid("TO");
                    Guid categoryId = _menuProxi.GetGuid("Categoty ID");
                    float amount = _menuProxi.GetFloat("Amount");
                    if (!_categoryStorage.Contains(categoryId) || !_accountStorage.Contains(from) || !_accountStorage.Contains(to))
                    {
                        _menuProxi.WrongOperation();
                    }
                    else
                    {
                        var operation = _operationFactory.Create(from, to, categoryId, amount);
                        _operationStorage.Add(operation);
                        _menuProxi.CreateString(operation.Id);
                    }
                    break;
            }
        }
        private void HandleUpdate()
        {
            InstanceType type = _menuProxi.GetTypeOfData();
            string name;
            Guid id;
            float balance;
            switch (type)
            {
                case InstanceType.BankAccount:
                    id = _menuProxi.GetGuid("id");
                    if (_accountStorage[id] == null)
                    {
                        _menuProxi.WrongGuid();
                        return;
                    }
                    name = _menuProxi.GetName();
                    balance = _menuProxi.GetFloat("balance");
                    _accountStorage[id].Name = name;
                    _accountStorage[id].Balance = balance;
                    break;

                case InstanceType.Category:
                    id = _menuProxi.GetGuid("id");
                    name = _menuProxi.GetName();
                    if (_categoryStorage[id] == null)
                    {
                        _menuProxi.WrongGuid();
                        return;
                    }
                    _categoryStorage[id].Name = name;
                    break;

                case InstanceType.Operation:
                    id = _menuProxi.GetGuid("id");
                    Guid from = _menuProxi.GetGuid("FROM");
                    Guid to = _menuProxi.GetGuid("TO");
                    Guid categoryId = _menuProxi.GetGuid("Categoty ID");
                    float amount = _menuProxi.GetFloat("Amount");
                    if (!_categoryStorage.Contains(categoryId) || !_accountStorage.Contains(from) || !_accountStorage.Contains(to) || _operationStorage[id] == null)
                    {
                        _menuProxi.WrongOperation();
                    }
                    else
                    {
                        _operationStorage[id].Date = DateTime.Now;
                        _operationStorage[id].Amount = amount;
                        _operationStorage[id].From = from;
                        _operationStorage[id].To = to;
                        _operationStorage[id].CategoryId = categoryId;
                    }
                    break;
            }

        }

        private void HandleImport()
        {
            InstanceType type = _menuProxi.GetTypeOfData();
            IFileHandler fileHandler = GetFileHandler();
            string filepath = _menuProxi.GetFilePath();

            try
            {
                switch (type)
                {
                    case InstanceType.BankAccount:
                        var accounts = fileHandler.Load<BankAccount>(filepath);
                        if (accounts != null)
                        {
                            foreach (var account in accounts)
                            {
                                _accountStorage.Add(account);
                            }
                        }
                        else
                        {
                            _menuProxi.FileErrorResponse();
                        }
                        break;

                    case InstanceType.Category:
                        var categories = fileHandler.Load<Category>(filepath);
                        if (categories != null)
                        {
                            foreach (var category in categories)
                            {
                                _categoryStorage.Add(category);
                            }
                        }
                        else
                        {
                            _menuProxi.FileErrorResponse();
                        }
                        break;

                    case InstanceType.Operation:
                        var operations = fileHandler.Load<Operation>(filepath);
                        if (operations != null)
                        {
                            foreach (var operation in operations)
                            {
                                _operationStorage.Add(operation);
                            }
                        }
                        else
                        {
                            _menuProxi.FileErrorResponse();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                _menuProxi.FileErrorResponse();
            }
        }

        private void HandleExport()
        {
            InstanceType type = _menuProxi.GetTypeOfData();
            IFileHandler fileHandler = GetFileHandler();
            string filepath = _menuProxi.GetFilePath();

            try
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
            catch (Exception ex)
            {
                _menuProxi.FileErrorResponse();
            }
        }

        private IFileHandler GetFileHandler()
        {
            FileType fileType = _menuProxi.GetFileType();
            return fileType switch
            {
                FileType.JSON => _jsonFileHandler,
                FileType.CSV => _csvFileHandler,
                FileType.YAML => _yamlFileHandler,
            };
        }

        public void Start()
        {
            while (Solution()) { }
        }
    }
}