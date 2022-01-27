using System.Collections.Generic;
using Otus.Multithreaded.Abstractions;

namespace Otus.Multithreaded.Services
{
    public class SumService : ISumService
    {
        public int GetSum(IEnumerable<int> items)
        {
            var res = 0;

            foreach (var item in items)
            {
                res += item;
            }

            return res;
        }
    }
}