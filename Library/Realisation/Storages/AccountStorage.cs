using Library.Abstractions;
using Library.Abstractions.Models;
using Library.Realisation.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.Storages
{
    [Serializable]
    public class AccountStorage<T> : Storage<T> where T : IBankAccount
    {
        public AccountStorage() : base() { }

        public AccountStorage(IEnumerable<T> list) : base(list) { }

    }
}
