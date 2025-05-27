using Library.Abstractions.Factories;
using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.Factories
{
    public class CategoryFactory : ICategoryFactory<Category>
    {
        public CategoryFactory() { }
        public override  Category Create(string name) 
        {
            return new Category(name);
        }
    }
}
