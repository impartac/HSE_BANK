using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Models
{
    public abstract class ICategory : IUniqueId, INamed
    {
        public string Name { get ; set; }
    }
}
