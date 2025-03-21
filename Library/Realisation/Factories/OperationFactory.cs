using Library.Abstractions.Factories;
using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.Factories
{
    public class OperationFactory : IOperationFactory<Operation>
    {
        public OperationFactory() { }
        public Operation Create(Guid id, BankAccount from, BankAccount to, Category category, float amount)
        {
            return new Operation(id, from.Id, to.Id, category.Id, amount);
        }
        public Operation Create(Guid id, Guid from, Guid to, Guid categoryId, float amount)
        {
            return new Operation(id, from, to, categoryId, amount);
        }
    }
}
