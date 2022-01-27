using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Otus.Multithreaded.Abstractions;

namespace Otus.Multithreaded.Services
{
    public class ParallelSumService : ISumService
    {
        private CountdownEvent _event;

        private int _countThread = 4;
        private int _sum;

        public int GetSum(IEnumerable<int> items)
        {
            _event = new CountdownEvent(_countThread);

            for (var i = 0; i < _countThread; i++)
            {
                var state = items.Where((_, index) => index % _countThread == i).ToList();
                ThreadPool.QueueUserWorkItem(CallBack, state);
            }

            _event.Wait();

            return _sum;
        }

        private void CallBack(object obj)
        {
            var data = (List<int>) obj;

            var sumService = new SumService();

            _sum += sumService.GetSum(data);

            _event.Signal();
        }
    }
}