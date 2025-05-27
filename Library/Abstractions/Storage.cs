using Library.Abstractions.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Abstractions
{
    [Serializable]
    public class Storage<T> : List<T> where T : IUniqueId
    {
        public Storage() : base() { }

        public Storage(IEnumerable<T> list) : base(list) { }
        public T this[Guid id]
        {
            get
            {
                var item = this.FirstOrDefault(x => x.Id == id);
                return item;
            }
            set
            {
                var index = this.FirstOrDefault(x => x.Id == id);
                if (index == null) 
                {
                    return;
                }
                index = value;
            }
        }

        public new void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (this.Any(x => x.Id == item.Id))
            {
                throw new InvalidOperationException($"Элемент с ID {item.Id} уже существует.");
            }

            base.Add(item);
        }
        public bool Remove(Guid id)
        {
            var item = this.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return base.Remove(item);
            }
            return false;
        }

        public bool Contains(Guid id)
        {
            return this.Any(x => x.Id == id);
        }
    }
}
