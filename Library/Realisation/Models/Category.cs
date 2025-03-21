using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Realisation.Models
{
    public class Category : ICategory
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Category : {Name}";
        }

    }
}
