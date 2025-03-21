using Library.Abstractions.Models;
using Library.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Realisation.Models;

namespace Library.Realisation.Storages
{
    [Serializable]
    public class CategoryStorage<T> : Storage<T> where T : ICategory
    {
        public CategoryStorage() : base() { }

        public CategoryStorage(IEnumerable<T> list) : base(list) { }
    }
}
