using Library.Abstractions.Models;
using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Factories
{
    public abstract class IAccountFactory<IBankAccount> : IFactory
    {
        public abstract IBankAccount Create(string name);
    }
}
