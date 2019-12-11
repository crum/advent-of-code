using Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace _2019.Day11
{
    internal class Computer
    {
        internal delegate void MachineHalted();
        internal delegate long FeedInput();
        internal delegate void HandleOutput(long item);

        private long[] memory;
        private long i;
        private long relativeBase;
        private MachineHalted machineHalted;
        private FeedInput feedInput;
        private HandleOutput handleOutput;
        internal bool IsHalted { get; private set; }
        internal long LastOutput { get; private set; }
        internal long Id { get; private set; }
        Random r;

        internal Computer(long id, IEnumerable<long> initialMemory, FeedInput inFunc, HandleOutput outFunc, MachineHalted machineHalted = null)
        {
            this.memory = new long[initialMemory.Count()];
            Array.Copy(initialMemory.ToArray(), 0, this.memory, 0, this.memory.Length);
            this.feedInput = inFunc;
            this.handleOutput = outFunc;
            this.machineHalted = machineHalted;
            this.machineHalted = machineHalted;
            this.Id = id;
            r = new Random();
        }

        internal void Run()
        {
            for (long i = 0; i < memory.Length; ++i)
            {
                if (memory[i] % 100 == 1)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    var argMode3 = (memory[i] / 10000) % 10;
                    long arg1, arg2, arg3;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
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
                    else if (argMode2 == 2)
                    {
                        arg2 = memory[memory[i + 2] + relativeBase];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode3 == 0)
                    {
                        arg3 = memory[i + 3];
                    }
                    else if (argMode3 == 1)
                    {
                        throw new Exception("immediate not allowed for write params");
                    }
                    else if (argMode3 == 2)
                    {
                        arg3 = memory[i + 3] + relativeBase;
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }

                    memory[arg3] = arg1 + arg2;
                    i = i + 3;
                }
                else if (memory[i] % 100 == 2)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    var argMode3 = (memory[i] / 10000) % 10;
                    long arg1, arg2, arg3;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
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
                    else if (argMode2 == 2)
                    {
                        arg2 = memory[memory[i + 2] + relativeBase];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode3 == 0)
                    {
                        arg3 = memory[i + 3];
                    }
                    else if (argMode3 == 1)
                    {
                        throw new Exception("immediate not allowed for write params");
                    }
                    else if (argMode3 == 2)
                    {
                        arg3 = memory[i + 3] + relativeBase;
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    memory[arg3] = arg1 * arg2;
                    i = i + 3;
                }
                else if (memory[i] % 100 == 3)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    long arg1 = -1;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 1)
                    {
                        throw new Exception("invalid for write instrctions");
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[i + 1] + relativeBase;
                    }
                    memory[arg1] = feedInput();
                    i = i + 1;
                }
                else if (memory[i] % 100 == 4)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    long arg1;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    IO.WriteLine($"machine {Id} output {arg1}");
                    handleOutput(arg1);
                    LastOutput = arg1;
                    i = i + 1;
                }
                else if (memory[i] % 100 == 5)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    long arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
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
                    else if (argMode2 == 2)
                    {
                        arg2 = memory[memory[i + 2] + relativeBase];
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
                    long arg1, arg2;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
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
                    else if (argMode2 == 2)
                    {
                        arg2 = memory[memory[i + 2] + relativeBase];
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
                    var argMode3 = (memory[i] / 10000) % 10;
                    long arg1, arg2, arg3;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
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
                    else if (argMode2 == 2)
                    {
                        arg2 = memory[memory[i + 2] + relativeBase];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode3 == 0)
                    {
                        arg3 = memory[i + 3];
                    }
                    else if (argMode3 == 1)
                    {
                        throw new Exception("immediate not allowed for write params");
                    }
                    else if (argMode3 == 2)
                    {
                        arg3 = memory[i + 3] + relativeBase;
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (arg1 < arg2)
                    {
                        memory[arg3] = 1;
                    }
                    else
                    {
                        memory[arg3] = 0;
                    }
                    i = i + 3;
                }
                else if (memory[i] % 100 == 8)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    var argMode2 = (memory[i] / 1000) % 10;
                    var argMode3 = (memory[i] / 10000) % 10;
                    long arg1, arg2, arg3;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
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
                    else if (argMode2 == 2)
                    {
                        arg2 = memory[memory[i + 2] + relativeBase];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (argMode3 == 0)
                    {
                        arg3 = memory[i + 3];
                    }
                    else if (argMode3 == 1)
                    {
                        throw new Exception("immediate not allowed for write params");
                    }
                    else if (argMode3 == 2)
                    {
                        arg3 = memory[i + 3] + relativeBase;
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    if (arg1 == arg2)
                    {
                        memory[arg3] = 1;
                    }
                    else
                    {
                        memory[arg3] = 0;
                    }
                    i = i + 3;
                }
                else if (memory[i] % 100 == 9)
                {
                    var argMode1 = (memory[i] / 100) % 10;
                    long arg1;
                    if (argMode1 == 0)
                    {
                        arg1 = memory[memory[i + 1]];
                    }
                    else if (argMode1 == 1)
                    {
                        arg1 = memory[i + 1];
                    }
                    else if (argMode1 == 2)
                    {
                        arg1 = memory[memory[i + 1] + relativeBase];
                    }
                    else
                    {
                        throw new Exception("bad arg mode");
                    }
                    relativeBase += arg1;
                    i = i + 1;
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
