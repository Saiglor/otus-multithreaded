using System;
using System.Collections.Generic;

namespace Otus.Multithreaded.Services
{
    public static class GeneratorService
    {
        public static List<int> GenerateIntList(int count)
        {
            var rnd = new Random();
            var res = new List<int>();

            for (var i = 0; i < count; i++)
            {
                res.Add(rnd.Next(0, 100));
            }

            return res;
        }
    }
}