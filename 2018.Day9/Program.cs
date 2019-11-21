using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "400 players; last marble is worth 71864 points";
            var numPlayers = 400; var lastPoints = 71864; var shouldBeScore = 437654;

            //testing
            //numPlayers = 9; lastPoints = 25; shouldBeScore = 32;
            //numPlayers = 10; lastPoints = 1618; shouldBeScore = 8317;
            //numPlayers = 13; lastPoints = 7999; shouldBeScore = 146373;
            //numPlayers = 17; lastPoints = 1104; shouldBeScore = 2764;
            //numPlayers = 21; lastPoints = 6111; shouldBeScore = 54718;
            //numPlayers = 30; lastPoints = 5807; shouldBeScore = 37305;
            lastPoints *= 100;

            var marbles = new Deque<int>();
            var scores = new long[numPlayers];
            marbles.Enqueue(0);
            for (var m = 1; m <= lastPoints; ++m)
            {
                if (m % 23 == 0)
                {
                    marbles.Rotate(7);
                    scores[m % numPlayers] += (m + marbles.Pop());
                    marbles.Rotate(-1);
                }
                else
                {
                    marbles.Rotate(-1);
                    marbles.Push(m);
                }
            }

            var highScore = scores.Max();
            var highScorePlayer = Array.IndexOf(scores, highScore) + 1;

            IO.WriteLine($"got score {highScore}, should be {shouldBeScore}");
        }
    }
}
