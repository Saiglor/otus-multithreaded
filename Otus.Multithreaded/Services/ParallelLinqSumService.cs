using System.Collections.Generic;
using System.Linq;
using Otus.Multithreaded.Abstractions;

namespace Otus.Multithreaded.Services
{
    public class ParallelLinqSumService : ISumService
    {
        public int GetSum(IEnumerable<int> items)
        {
            return items.AsParallel().Sum();
        }
    }
}