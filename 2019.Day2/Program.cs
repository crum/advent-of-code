﻿using System;
using Shared;

namespace _2019.Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,5,19,23,2,9,23,27,1,27,5,31,2,31,13,35,1,35,9,39,1,39,10,43,2,43,9,47,1,47,5,51,2,13,51,55,1,9,55,59,1,5,59,63,2,6,63,67,1,5,67,71,1,6,71,75,2,9,75,79,1,79,13,83,1,83,13,87,1,87,5,91,1,6,91,95,2,95,13,99,2,13,99,103,1,5,103,107,1,107,10,111,1,111,13,115,1,10,115,119,1,9,119,123,2,6,123,127,1,5,127,131,2,6,131,135,1,135,2,139,1,139,9,0,99,2,14,0,0".Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToIntArray();
            var golden = new int[input.Length];
            Array.Copy(input, golden, input.Length);

            for (var noun = 0; noun < 100; ++noun)
            {
                for (var verb = 0; verb < 100; ++verb)
                {
                    Array.Copy(golden, input, golden.Length);
                    input[1] = noun;
                    input[2] = verb;
                    for (var i = 0; i < input.Length; ++i)
                    {
                        if (input[i] == 1)
                        {
                            input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]];
                            i = i + 3;
                        }
                        else if (input[i] == 2)
                        {
                            input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]];
                            i = i + 3;
                        }
                        else if (input[i] == 99)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("you done screwde up");
                        }
                    }
                    if (input[0] == 19690720)
                    {
                        IO.WriteLine($"noun: {noun}");
                        IO.WriteLine($"verb: {verb}");
                    }
                }
            }

            IO.WriteLine($"0: {input[0]}");
        }
    }
}
