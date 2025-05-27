using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Factories
{
    public abstract class ICategoryFactory<ICategory> : IFactory
    {
        public abstract ICategory Create(string name);
    }
}
