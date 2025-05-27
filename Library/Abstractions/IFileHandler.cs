using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Library.Abstractions;
using Library.Abstractions.Models;

namespace Library.Abstractions
{
    public abstract class IFileHandler
    {

        public abstract void Save<T>(IEnumerable<T> obj, string savePath) where T : IUniqueId;
        public abstract IEnumerable<T> Load<T>(string loadPAth) where T : IUniqueId;

        public IFileHandler() { }
    }
}
