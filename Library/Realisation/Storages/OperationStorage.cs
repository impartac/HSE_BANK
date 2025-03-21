using Library.Abstractions;
using Library.Abstractions.Models;
using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.Storages
{
    [Serializable]
    public class OperationStorage<T> : Storage<T> where T : IOperation
    {
        public OperationStorage() : base() { }
        public OperationStorage(IEnumerable<T> list) : base(list) { }
    }
}
