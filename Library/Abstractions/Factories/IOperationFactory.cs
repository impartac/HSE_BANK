using Library.Abstractions.Models;
using Library.Realisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Abstractions.Factories
{
    public abstract class IOperationFactory<IOperation> : IFactory
    {
        [JsonIgnore]
        public bool IsProcessed { get; set; }
    }
}
