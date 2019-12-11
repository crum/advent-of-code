using Shared;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _2019.Day11
{
    class Program
    {
        enum Dir
        {
            North,
            East,
            South,
            West,
        }

        static long[] input;
        static int[,] field;
        static int outputCount;
        static int curX;
        static int curY;
        static Dir curDir = Dir.North;

        static void Main(string[] args)
        {
            var shortInput = "3,8,1005,8,291,1106,0,11,0,0,0,104,1,104,0,3,8,1002,8,-1,10,101,1,10,10,4,10,108,0,8,10,4,10,1002,8,1,28,1,1003,20,10,2,1103,19,10,3,8,1002,8,-1,10,1001,10,1,10,4,10,1008,8,0,10,4,10,1001,8,0,59,1,1004,3,10,3,8,102,-1,8,10,1001,10,1,10,4,10,108,0,8,10,4,10,1001,8,0,84,1006,0,3,1,1102,12,10,3,8,1002,8,-1,10,101,1,10,10,4,10,1008,8,1,10,4,10,101,0,8,114,3,8,1002,8,-1,10,101,1,10,10,4,10,108,1,8,10,4,10,101,0,8,135,3,8,1002,8,-1,10,1001,10,1,10,4,10,1008,8,0,10,4,10,102,1,8,158,2,9,9,10,2,2,10,10,3,8,1002,8,-1,10,1001,10,1,10,4,10,1008,8,1,10,4,10,101,0,8,188,1006,0,56,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,1,8,10,4,10,1001,8,0,212,1006,0,76,2,1005,8,10,3,8,102,-1,8,10,1001,10,1,10,4,10,108,1,8,10,4,10,1001,8,0,241,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,0,10,4,10,1002,8,1,264,1006,0,95,1,1001,12,10,101,1,9,9,1007,9,933,10,1005,10,15,99,109,613,104,0,104,1,21102,838484206484,1,1,21102,1,308,0,1106,0,412,21102,1,937267929116,1,21101,0,319,0,1105,1,412,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,21102,206312598619,1,1,21102,366,1,0,1105,1,412,21101,179410332867,0,1,21102,377,1,0,1105,1,412,3,10,104,0,104,0,3,10,104,0,104,0,21101,0,709580595968,1,21102,1,400,0,1106,0,412,21102,868389384552,1,1,21101,411,0,0,1106,0,412,99,109,2,21202,-1,1,1,21102,1,40,2,21102,1,443,3,21101,0,433,0,1106,0,476,109,-2,2105,1,0,0,1,0,0,1,109,2,3,10,204,-1,1001,438,439,454,4,0,1001,438,1,438,108,4,438,10,1006,10,470,1102,0,1,438,109,-2,2106,0,0,0,109,4,1202,-1,1,475,1207,-3,0,10,1006,10,493,21102,0,1,-3,21202,-3,1,1,21201,-2,0,2,21101,0,1,3,21102,1,512,0,1106,0,517,109,-4,2105,1,0,109,5,1207,-3,1,10,1006,10,540,2207,-4,-2,10,1006,10,540,22101,0,-4,-4,1106,0,608,21201,-4,0,1,21201,-3,-1,2,21202,-2,2,3,21101,0,559,0,1106,0,517,21201,1,0,-4,21102,1,1,-1,2207,-4,-2,10,1006,10,578,21101,0,0,-1,22202,-2,-1,-2,2107,0,-3,10,1006,10,600,21201,-1,0,1,21102,600,1,0,106,0,475,21202,-2,-1,-2,22201,-4,-2,-4,109,-5,2106,0,0".Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToLongArray();
            input = new long[shortInput.Length * 100];
            Array.Copy(shortInput, 0, input, 0, shortInput.Length);

            const int ROWS = 1000;
            const int COLS = 1000;
            field = new int[ROWS, COLS];
            for (var y = 0; y < ROWS; ++y)
            {
                for (var x = 0; x < COLS; ++x)
                {
                    field[y, x] = 2;
                }
            }

            curX = COLS / 2;
            curY = ROWS / 2;
            field[curY, curX] = 1;
            var computer = new Computer(1, input, FeedInput, HandleOutput);
            computer.Run();

            var count = 0;

            for (var y = 0; y < ROWS; ++y)
            {
                for (var x = 0; x < COLS; ++x)
                {
                    if (field[y, x] != 2)
                    {
                        ++count;
                    }
                }
            }

            IO.WriteLine($"painted {count} panels");

            var firstX = COLS - 1;
            var firstY = ROWS - 1;
            var lastX = 0;
            var lastY = 0;
            for (var y = 0; y < ROWS; ++y)
            {
                for (var x = 0; x < COLS; ++x)
                {
                    if (field[y, x] != 2)
                    {
                        if (x < firstX)
                        {
                            firstX = x;
                        }
                        if (y < firstY)
                        {
                            firstY = y;
                        }
                        if (x > lastX)
                        {
                            lastX = x;
                        }
                        if (y > lastY)
                        {
                            lastY = y;
                        }
                    }
                }
            }

            for (var y = firstY; y <= lastY; ++y)
            {
                var sb = new StringBuilder();
                for (var x = firstX; x <= lastX; ++x)
                {
                    if (field[y, x] == 2 || field[y, x] == 0)
                    {
                        sb.Append("  ");
                    }
                    else
                    {
                        sb.Append("██");
                    }
                }
                IO.WriteLine(sb.ToString());
            }

        }

        private static void HandleOutput(long item)
        {
            if (outputCount % 2 == 0)
            {
                field[curY, curX] = (int)item;
            }
            else
            {
                curDir = Turn(curDir, (int)item);
                Move(ref curX, ref curY, curDir);
            }
            ++outputCount;
        }

        private static long FeedInput()
        {
            return field[curY, curX] == 2 ? 0 : field[curY, curX];
        }

        private static void Move(ref int x, ref int y, Dir curDir)
        {
            if (curDir == Dir.North)
            {
                --y;
            }
            else if (curDir == Dir.East)
            {
                ++x;
            }
            else if (curDir == Dir.South)
            {
                ++y;
            }
            else if (curDir == Dir.West)
            {
                --x;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private static Dir Turn(Dir curDir, int change)
        {
            if (change == 0)
            {
                return (Dir)(((int)curDir + 3) % 4);
            }
            else if (change == 1)
            {
                return (Dir)(((int)curDir + 1) % 4);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
