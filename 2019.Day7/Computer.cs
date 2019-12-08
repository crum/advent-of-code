using Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace _2019.Day7
{
    internal class Computer
    {
        internal delegate void MachineHalted();

        private int[] memory;
        private int i;
        private ConcurrentQueue<int> input;
        private ConcurrentQueue<int> output;
        private MachineHalted machineHalted;
        internal bool IsHalted { get; private set; }
        internal int LastOutput { get; private set; }
        internal int Id { get; private set; }
        Random r;

        internal Computer(int id, IEnumerable<int> initialMemory, ConcurrentQueue<int> inputQ, ConcurrentQueue<int> outputQ, MachineHalted machineHalted = null)
        {
            this.memory = new int[initialMemory.Count()];
            Array.Copy(initialMemory.ToArray(), 0, this.memory, 0, this.memory.Length);
            this.input = inputQ;
            this.output = outputQ;
            this.machineHalted = machineHalted;
            this.Id = id;
            r = new Random();
        }

        internal void Run()
        {
            for (var i = 0; i < memory.Length; ++i)
            {
                if (memory[i] % 100 == 1)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    int arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode2 == 0)
                    {
                        arg2 = memory[memory[i + 2]];
                    }
                    else if (argMode2 == 1)
                    {
                        arg2 = memory[i + 2];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }

                    memory[memory[i + 3]] = arg1 + arg2;
                    i = i + 3;
                }
                else if (memory[i] % 100 == 2)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    int arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode2 == 0)
                    {
                        arg2 = memory[memory[i + 2]];
                    }
                    else if (argMode2 == 1)
                    {
                        arg2 = memory[i + 2];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    memory[memory[i + 3]] = arg1 * arg2;
                    i = i + 3;
                }
                else if (memory[i] % 100 == 3)
                {
                    while (input.IsEmpty)
                    {
                        Thread.Sleep(r.Next(10, 30));
                    }
                    Debug.Assert(input.TryDequeue(out var item));
                    memory[memory[i + 1]] = item;
                    i = i + 1;
                }
                else if (memory[i] % 100 == 4)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    int arg1;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    output.Enqueue(arg1);
                    LastOutput = arg1;
                    i = i + 1;
                }
                else if (memory[i] % 100 == 5)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    int arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode2 == 0)
                    {
                        arg2 = memory[memory[i + 2]];
                    }
                    else if (argMode2 == 1)
                    {
                        arg2 = memory[i + 2];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (arg1 != 0)
                    {
                        i = arg2 - 1;
                    }
                    else
                    {
                        i = i + 2;
                    }
                }
                else if (memory[i] % 100 == 6)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    int arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode2 == 0)
                    {
                        arg2 = memory[memory[i + 2]];
                    }
                    else if (argMode2 == 1)
                    {
                        arg2 = memory[i + 2];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (arg1 == 0)
                    {
                        i = arg2 - 1;
                    }
                    else
                    {
                        i = i + 2;
                    }
                }
                else if (memory[i] % 100 == 7)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    int arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode2 == 0)
                    {
                        arg2 = memory[memory[i + 2]];
                    }
                    else if (argMode2 == 1)
                    {
                        arg2 = memory[i + 2];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (arg1 < arg2)
                    {
                        memory[memory[i + 3]] = 1;
                    }
                    else
                    {
                        memory[memory[i + 3]] = 0;
                    }
                    i = i + 3;
                }
                else if (memory[i] % 100 == 8)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    int arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode2 == 0)
                    {
                        arg2 = memory[memory[i + 2]];
                    }
                    else if (argMode2 == 1)
                    {
                        arg2 = memory[i + 2];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (arg1 == arg2)
                    {
                        memory[memory[i + 3]] = 1;
                    }
                    else
                    {
                        memory[memory[i + 3]] = 0;
                    }
                    i = i + 3;
                }
                else if (memory[i] == 99)
                {
                    IsHalted = true;
                    if (machineHalted != null)
                    {
                        machineHalted();
                    }
                    return;
                }
                else
                {
                    throw new Exception("you done screwde up");
                }
            }
        }
    }
}
