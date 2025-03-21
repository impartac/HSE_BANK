using Library.Abstractions.Factories;
using Library.Abstractions.Models;
using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.Factories
{
    public class AccountFactory : IAccountFactory<BankAccount>
    {

        public override BankAccount Create(string name)
        {
            return new BankAccount(name);
        }
    }
}
