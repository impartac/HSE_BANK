using Library.Abstractions;
using Library.Abstractions.Models;
using Library.Realisation.Models;
using Library.Realisation.Storages;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation
{
    public class Processor : IProcess
    {
        public void Execute(AccountStorage<BankAccount> accounts, OperationStorage<Operation> operations) 
        {
            foreach (var operation in operations)
            {
                if (accounts[operation.From] == null || accounts[operation.To] == null)
                    continue;
                else
                {
                    accounts[operation.From].Balance -= operation.Amount;
                    accounts[operation.To].Balance += operation.Amount;
                    operation.IsProcessed = true;
                }
            }
        }
    }
}
