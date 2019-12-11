using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2019.Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"###..#########.#####.
                          .####.#####..####.#.#
                          .###.#.#.#####.##..##
                          ##.####.#.###########
                          ###...#.####.#.#.####
                          #.##..###.########...
                          #.#######.##.#######.
                          .#..#.#..###...####.#
                          #######.##.##.###..##
                          #.#......#....#.#.#..
                          ######.###.#.#.##...#
                          ####.#...#.#######.#.
                          .######.#####.#######
                          ##.##.##.#####.##.#.#
                          ###.#######..##.#....
                          ###.##.##..##.#####.#
                          ##.########.#.#.#####
                          .##....##..###.#...#.
                          #..#.####.######..###
                          ..#.####.############
                          ..##...###..#########";

            //input = @".#..#
            //          .....
            //          #####
            //          ....#
            //          ...##";

            //input = @"......#.#.
            //          #..#.#....
            //          ..#######.
            //          .#.#.###..
            //          .#..#.....
            //          ..#....#.#
            //          #..#....#.
            //          .##.#..###
            //          ##...#..#.
            //          .#....####";

            //input = @"#.#...#.#.
            //          .###....#.
            //          .#....#...
            //          ##.#.#.#.#
            //          ....#.#.#.
            //          .##..###.#
            //          ..#...##..
            //          ..##....##
            //          ......#...
            //          .####.###.
            //          ";

            //input = @".#..#..###
            //          ####.###.#
            //          ....###.#.
            //          ..###.##.#
            //          ##.##.#.#.
            //          ....###..#
            //          ..#.#..#.#
            //          #..#.#.###
            //          .##...##.#
            //          .....#.#..";

            //input = @".#..##.###...#######
            //          ##.############..##.
            //          .#.######.########.#
            //          .###.#######.####.#.
            //          #####.##.#.##.###.##
            //          ..#####..#.#########
            //          ####################
            //          #.####....###.#.#.##
            //          ##.#################
            //          #####.##.###..####..
            //          ..######..##.#######
            //          ####.##.####...##..#
            //          .#####..#.######.###
            //          ##...#.##########...
            //          #.##########.#######
            //          .####.#.###.###.#.##
            //          ....##.##.###..#####
            //          .#.#.###########.###
            //          #.#.#.#####.####.###
            //          ###.##.####.##.#..##";

            var split = input.Split(new[] { ' ', '\r', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var rows = split.Length;
            var cols = split[0].Length;
            var grid = new bool[rows, cols];
            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    grid[y, x] = (split[y][x] == '#');
                }
            }

            PrintGrid(grid, rows, cols);

            var best = int.MinValue;
            var bestX = -1;
            var bestY = -1;

            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    if (grid[y, x])
                    {
                        var count = 0;

                        for (int yy = 0; yy < rows; ++yy)
                        {
                            for (int xx = 0; xx < cols; ++xx)
                            {
                                if (yy == y && xx == x)
                                {
                                    continue;
                                }
                                if (grid[yy, xx] && ViewIsClear(grid, rows, cols, x, y, xx, yy))
                                {
                                    ++count;
                                }
                            }
                        }

                        if (count > best)
                        {
                            best = count;
                            bestX = x;
                            bestY = y;
                        }
                    }
                }
            }

            IO.WriteLine($"best: {best} @ {bestX},{bestY}");

            var angles = new double[rows, cols];

            for (int y = bestY - 1; y >= 0; --y)
            {
                angles[y, bestX] = 0;
            }
            for (int y = bestY + 1; y < rows; ++y)
            {
                angles[y, bestX] = Math.PI;
            }
            for (int x = bestX + 1; x < cols; ++x)
            {
                angles[bestY, x] = Math.PI / 2;
            }
            for (int x = bestX - 1; x >= 0; --x)
            {
                angles[bestY, x] = (3 * Math.PI) / 2;
            }

            angles[bestY, bestX] = 0;

            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    if (x == bestX || y == bestY)
                    {
                        continue;
                    }
                    // upper right
                    if (x > bestX && y < bestY)
                    {
                        angles[y, x] = Math.Atan(((double)(x - bestX) / (double)(bestY - y)));
                    }
                    // lower right
                    else if (x > bestX && y > bestY)
                    {
                        angles[y, x] = Math.PI / 2 + Math.Atan(((double)(y - bestY) / (double)(x - bestX)));
                    }
                    // lower left
                    else if (x < bestX && y > bestY)
                    {
                        angles[y, x] = Math.PI + Math.Atan(((double)(bestY - y) / (double)(bestX - x)));
                    }
                    // upper left
                    else if (x < bestX && y < bestY)
                    {
                        angles[y, x] = (3 * Math.PI / 2) + Math.Atan(((double)(bestY - y) / (double)(bestX - x)));
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            var goldenGrid = new bool[rows, cols];
            Array.Copy(grid, 0, goldenGrid, 0, goldenGrid.Length);
            grid[bestY, bestX] = false;
            var vaped = 0;
            int lowestX = -1, lowestY = -1;
            var lastAngle = -1.0;
            while (vaped < 200)
            {
                if (lastAngle >= Math.PI * 2)
                {
                    lastAngle = 0;
                }
                var blocked = GetBlockedAndDeadList(grid, rows, cols, bestX, bestY);
                (lowestX, lowestY) = GetLowest(angles, rows, cols, blocked, lastAngle);
                if (lowestX == -1 || lowestY == -1)
                {
                    lastAngle = -1;
                    (lowestX, lowestY) = GetLowest(angles, rows, cols, blocked, lastAngle);
                }
                grid[lowestY, lowestX] = false;
                lastAngle = angles[lowestY, lowestX];
                ++vaped;
                //PrintGrid(grid, rows, cols, bestX, bestY);
                IO.WriteLine($"{vaped}: vaped {lowestX},{lowestY}@{angles[lowestY, lowestX]}");
            }

            Array.Copy(goldenGrid, 0, grid, 0, grid.Length);
            vaped = 0;
            var lastVaped = double.MinValue;
            while (vaped < 200)
            {
                var ordered = new List<Tuple<double, int, int>>();
                for (var y = 0; y < rows; ++y)
                {
                    for (var x = 0; x < cols; ++x)
                    {
                        if (x != bestX || y != bestY)
                        {
                            if (grid[y, x] && angles[y, x] > lastVaped && ViewIsClear(grid, rows, cols, bestX, bestY, x, y))
                            {
                                ordered.Add(Tuple.Create(angles[y, x], x, y));
                            }
                        }
                    }
                }

                if (!ordered.Any())
                {
                    lastVaped = double.MinValue;
                    for (var y = 0; y < rows; ++y)
                    {
                        for (var x = 0; x < cols; ++x)
                        {
                            if (x != bestX || y != bestY)
                            {
                                if (grid[y, x] && angles[y, x] > lastVaped && ViewIsClear(grid, rows, cols, bestX, bestY, x, y))
                                {
                                    ordered.Add(Tuple.Create(angles[y, x], x, y));
                                }
                            }
                        }
                    }
                }

                ordered.Sort((t, u) => t.Item1.CompareTo(u.Item1));
                grid[ordered.First().Item3, ordered.First().Item2] = false;
                ++vaped;
                IO.WriteLine($"{vaped}: vaped {ordered.First().Item2},{ordered.First().Item3}@{ordered.First().Item1}");
                lastVaped = ordered.First().Item1;
                ordered.RemoveAt(0);
                //PrintGrid(grid, rows, cols, bestX, bestY);
            }

            IO.WriteLine($"number 200: {lowestX},{lowestY} ({lowestX * 100 + lowestY})");

            Array.Copy(goldenGrid, 0, grid, 0, grid.Length);

            var pos = new List<Tuple<Fraction, int, int>>();
            for (var y = 0; y < rows; ++y)
            {
                for (var x = 0; x < cols; ++x)
                {
                    if (grid[y, x])
                    {
                        pos.Add(Tuple.Create(new Fraction(y - bestY, x - bestX), x, y));
                    }
                }
            }
        }

        private static IEnumerable<Tuple<int, int>> GetBlockedAndDeadList(bool[,] grid, int rows, int cols, int stationX, int stationY)
        {
            var ret = new HashSet<Tuple<int, int>>();
            ret.Add(Tuple.Create(stationX, stationY));
            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    if (!grid[y, x] || !ViewIsClear(grid, rows, cols, stationX, stationY, x, y))
                    {
                        ret.Add(Tuple.Create(x, y));
                    }
                }
            }
            return ret;
        }

        private static (int, int) GetLowest(double[,] grid, int rows, int cols, IEnumerable<Tuple<int, int>> blacklist, double greaterThan)
        {
            var best = double.MaxValue;
            var bestX = -1;
            var bestY = -1;
            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    if (grid[y, x] <= greaterThan || blacklist.Contains(Tuple.Create(x, y)))
                    {
                        continue;
                    }
                    if (grid[y, x] < best)
                    {
                        best = grid[y, x];
                        bestX = x;
                        bestY = y;
                    }
                }
            }

            return (bestX, bestY);
        }

        private static void PrintGrid(bool[,] grid, int rows, int cols)
        {
            for (int y = 0; y < rows; ++y)
            {
                var row = new StringBuilder();
                for (int x = 0; x < cols; ++x)
                {
                    if (grid[y, x])
                    {
                        row.Append('#');
                    }
                    else
                    {
                        row.Append('.');
                    }
                }
                IO.WriteLine(row.ToString());
            }
        }

        private static void PrintGrid(bool[,] grid, int rows, int cols, int stationX, int stationY)
        {
            for (int y = 0; y < rows; ++y)
            {
                var row = new StringBuilder();
                for (int x = 0; x < cols; ++x)
                {
                    if (x == stationX && y == stationY)
                    {
                        row.Append('X');
                    }
                    else if (grid[y, x])
                    {
                        row.Append('#');
                    }
                    else
                    {
                        row.Append('.');
                    }
                }
                IO.WriteLine(row.ToString());
            }
        }

        private static void PrintGrid(double[,] grid, int rows, int cols)
        {
            for (int y = 0; y < rows; ++y)
            {
                var row = new StringBuilder();
                var first = true;
                for (int x = 0; x < cols; ++x)
                {
                    if (!first)
                    {
                        row.Append(",");
                    }
                    row.Append(grid[y, x].ToString("0.000"));
                    first = false;
                }
                IO.WriteLine(row.ToString());
            }
        }

        private static bool ViewIsClear(bool[,] grid, int rows, int cols, int x, int y, int xx, int yy)
        {
            var slope = new Fraction((int)Math.Abs(y - yy), (int)Math.Abs(x - xx)).Reduce();
            var dirX = xx > x ? 1 : -1;
            var dirY = yy > y ? 1 : -1;
            var blocked = false;
            for (int myX = x, myY = y; myX < cols && myX >= 0 && myY < rows && myY >= 0 && !blocked; myX += dirX * slope.Denominator, myY += dirY * slope.Numerator)
            {
                if (myX == x && myY == y)
                {
                    continue;
                }
                if (myX == xx && myY == yy)
                {
                    return !blocked;
                }
                blocked = blocked || grid[myY, myX];
            }

            return !blocked;
        }
    }
}
