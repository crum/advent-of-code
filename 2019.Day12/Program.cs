using System;
using System.Collections.Generic;
using System.Text;
using Shared;

namespace _2019.Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"<x=-15, y=1, z=4>
                          <x=1, y=-10, z=-8>
                          <x=-5, y=4, z=9>
                          <x=4, y=6, z=-2>";

            var velX = new int[4];
            var velY = new int[4];
            var velZ = new int[4];
            var posX = new[] { -15, 1, -5, 4 };
            var posY = new[] { 1, -10, 4, 6 };
            var posZ = new[] { 4, -8, 9, -2 };

            //posX = new[] { -1, 2, 4, 3 };
            //posY = new[] { 0, -10, -8, 5 };
            //posZ = new[] { 2, -7, 8, -1 };

            //posX = new[] { -8, 5, 2, 9 };
            //posY = new[] { -10, 5, -7, -8 };
            //posZ = new[] { 0, 10, 3, -3 };

            var startX = new int[4];
            var startY = new int[4];
            var startZ = new int[4];
            Array.Copy(posX, 0, startX, 0, startX.Length);
            Array.Copy(posY, 0, startY, 0, startY.Length);
            Array.Copy(posZ, 0, startZ, 0, startZ.Length);

            long cycleX = 0;
            long cycleY = 0;
            long cycleZ = 0;

            var seen = new HashSet<string>();

            long t = 0;

            for(t = 0; t < 1000; ++t)
            {
                for (var i = 0; i < velX.Length; ++i)
                {
                    for (var j = i + 1; j < velX.Length; ++j)
                    {
                        if (posX[i] > posX[j])
                        {
                            --velX[i];
                            ++velX[j];
                        }
                        else if (posX[i] < posX[j])
                        {
                            ++velX[i];
                            --velX[j];
                        }
                        if (posY[i] > posY[j])
                        {
                            --velY[i];
                            ++velY[j];
                        }
                        else if (posY[i] < posY[j])
                        {
                            ++velY[i];
                            --velY[j];
                        }
                        if (posZ[i] > posZ[j])
                        {
                            --velZ[i];
                            ++velZ[j];
                        }
                        else if (posZ[i] < posZ[j])
                        {
                            ++velZ[i];
                            --velZ[j];
                        }
                    }
                }

                for (var i = 0; i < velX.Length; ++i)
                {
                    posX[i] += velX[i];
                    posY[i] += velY[i];
                    posZ[i] += velZ[i];
                }
            }

            var energy = 0;
            for (var i = 0; i < velX.Length; ++i)
            {
                var p = Math.Abs(posX[i]) + Math.Abs(posY[i]) + Math.Abs(posZ[i]);
                var k = Math.Abs(velX[i]) + Math.Abs(velY[i]) + Math.Abs(velZ[i]);
                energy += (int)(p * k);
            }

            IO.WriteLine($"total energy {energy}");

            Array.Copy(startX, 0, posX, 0, posX.Length);
            Array.Copy(startY, 0, posY, 0, posY.Length);
            Array.Copy(startZ, 0, posZ, 0, posZ.Length);
            velX = new int[4];
            velY = new int[4];
            velZ = new int[4];

            t = 0;
            while (true)
            {
                ++t;

                for (var i = 0; i < velX.Length; ++i)
                {
                    for (var j = i + 1; j < velX.Length; ++j)
                    {
                        if (posX[i] > posX[j])
                        {
                            --velX[i];
                            ++velX[j];
                        }
                        else if (posX[i] < posX[j])
                        {
                            ++velX[i];
                            --velX[j];
                        }
                    }
                }

                for (var i = 0; i < velX.Length; ++i)
                {
                    posX[i] += velX[i];
                }

                var match = true;
                for (var i = 0; i < velX.Length && match; ++i)
                {
                    if (posX[i] != startX[i] || velX[i] != 0)
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    cycleX = t;
                    break;
                }
            }

            Array.Copy(startX, 0, posX, 0, posX.Length);
            Array.Copy(startY, 0, posY, 0, posY.Length);
            Array.Copy(startZ, 0, posZ, 0, posZ.Length);
            velX = new int[4];
            velY = new int[4];
            velZ = new int[4];

            t = 0;
            while (true)
            {
                ++t;

                for (var i = 0; i < velY.Length; ++i)
                {
                    for (var j = i + 1; j < velY.Length; ++j)
                    {
                        if (posY[i] > posY[j])
                        {
                            --velY[i];
                            ++velY[j];
                        }
                        else if (posY[i] < posY[j])
                        {
                            ++velY[i];
                            --velY[j];
                        }
                    }
                }

                for (var i = 0; i < velY.Length; ++i)
                {
                    posY[i] += velY[i];
                }

                var match = true;
                for (var i = 0; i < velY.Length && match; ++i)
                {
                    if (posY[i] != startY[i] || velY[i] != 0)
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    cycleY = t;
                    break;
                }
            }

            Array.Copy(startX, 0, posX, 0, posX.Length);
            Array.Copy(startY, 0, posY, 0, posY.Length);
            Array.Copy(startZ, 0, posZ, 0, posZ.Length);
            velX = new int[4];
            velY = new int[4];
            velZ = new int[4];

            t = 0;
            while (true)
            {
                ++t;

                for (var i = 0; i < velZ.Length; ++i)
                {
                    for (var j = i + 1; j < velZ.Length; ++j)
                    {
                        if (posZ[i] > posZ[j])
                        {
                            --velZ[i];
                            ++velZ[j];
                        }
                        else if (posZ[i] < posZ[j])
                        {
                            ++velZ[i];
                            --velZ[j];
                        }
                    }
                }

                for (var i = 0; i < velZ.Length; ++i)
                {
                    posZ[i] += velZ[i];
                }

                var match = true;
                for (var i = 0; i < velZ.Length && match; ++i)
                {
                    if (posZ[i] != startZ[i] || velZ[i] != 0)
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    cycleZ = t;
                    break;
                }
            }

            IO.WriteLine($"cycleX: {cycleX}, cycleY {cycleY}, cycleZ {cycleZ}: LCM {MoreMath.Lcm(cycleX, MoreMath.Lcm(cycleY, cycleZ))}");
        }
    }
}
