using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Models
{
    public abstract class IUniqueId
    {
        public Guid Id { get; set; }
    }
}
