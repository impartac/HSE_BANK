using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Models
{
    public abstract class IBankAccount : IUniqueId, INamed
    {
        public float Balance { get; set; }
        public string Name { get; set; }
        public IBankAccount() { }
    }
}
