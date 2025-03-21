using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Analytics
{
    public interface IAnalyticsFacade
    {
        public IEnumerable<string> Execute<Acc, Cat, Op>(IEnumerable<Acc> accounts, IEnumerable<Cat> categories, IEnumerable<Op> operations)
            where Cat : ICategory
            where Acc : IBankAccount
            where Op : IOperation;
    }
}
