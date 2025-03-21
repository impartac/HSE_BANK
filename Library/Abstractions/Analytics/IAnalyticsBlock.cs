using Library.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Abstractions.Analytics
{
    public interface IAnalyticsBlock<T> where T : IUniqueId
    {
        Storage<T> Storage { get; }
        IAnalytics<T> Analytics { get; }
    }
}
