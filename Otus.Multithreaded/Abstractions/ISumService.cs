using System.Collections.Generic;
using System.Threading.Tasks;

namespace Otus.Multithreaded.Abstractions
{
    public interface ISumService
    {
        int GetSum(List<int> items);
    }
}