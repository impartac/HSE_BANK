using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Analytics
{
    public interface IDifferenceCounter<T> where T : IUniqueId, IAnalyticsMethod<T>
    {
    }
}
