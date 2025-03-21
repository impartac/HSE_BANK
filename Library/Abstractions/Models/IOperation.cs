using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Models
{

    public abstract class IOperation : IUniqueId, IHasDate
    {
        public DateTime Date { get; set; }

        public Guid From { get; set; }
        public Guid To { get; set; }
        public Guid CategoryId { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
    }
}
