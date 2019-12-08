using Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _2019.Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "3,8,1001,8,10,8,105,1,0,0,21,42,67,88,105,114,195,276,357,438,99999,3,9,101,4,9,9,102,3,9,9,1001,9,2,9,102,4,9,9,4,9,99,3,9,1001,9,4,9,102,4,9,9,101,2,9,9,1002,9,5,9,1001,9,2,9,4,9,99,3,9,1001,9,4,9,1002,9,4,9,101,2,9,9,1002,9,2,9,4,9,99,3,9,101,4,9,9,102,3,9,9,1001,9,5,9,4,9,99,3,9,102,5,9,9,4,9,99,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,99,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,1,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,1001,9,1,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,99".Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToIntArray();
            //input = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5".Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToIntArray();

            var best = int.MinValue;
            var bestP = Enumerable.Empty<int>();
            foreach (var p in Combinatorics.Permutations(5, 6, 7, 8, 9))
            {
                var thisP = p.ToArray();
                var inputs = new ConcurrentQueue<int>[5];
                for (int i = 0; i < inputs.Length; ++i)
                {
                    inputs[i] = new ConcurrentQueue<int>();
                    inputs[i].Enqueue(thisP[i]);
                }
                inputs[0].Enqueue(0);

                var machines = new Computer[5];

                for (int i = 0; i < machines.Length; ++i)
                {
                    machines[i] = new Computer(i, input, inputs[i], inputs[(i + 1) % inputs.Length]);
                }

                var threads = new Thread[5];
                for (int i = 0; i < threads.Length; ++i)
                {
                    threads[i] = new Thread(new ThreadStart(machines[i].Run));
                    threads[i].Start();
                }

                while (!machines[4].IsHalted)
                {
                    Thread.Sleep(50);
                }

                if (machines[4].LastOutput > best)
                {
                    bestP = new List<int>(p);
                    best = machines[4].LastOutput;
                    IO.WriteLine($"new best: {best} @ {string.Join(",", bestP)}");
                }
            }

            IO.WriteLine($"best: {best} @ {string.Join(",", bestP)}");
        }
    }
}
