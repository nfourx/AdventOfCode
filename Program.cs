using AdventOfCode.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string pathFromArgs = args[0];
            var pathExists = File.Exists(pathFromArgs);

            List<int> readings = File.ReadAllLines(pathFromArgs)
                .Where(x => int.TryParse(x, out var _))
                .Select(t => int.Parse(t.Trim())).ToList();

            List<int> depths = new List<int> { 1, 2, 3, 4,5,6};

            int nrOfIncreasingDepthReadings = Sonar(readings);
            int nrOfIncreasingDepthReadingsSlidingWindows = SonarSlidingWindows(readings);
            Console.WriteLine($"Day 1: 1st task : nrOfIncreasingDepthReadings: {nrOfIncreasingDepthReadings}");
            Console.WriteLine($"Day 1: 2nd task : nrOfIncreasingDepthReadingsSlidingWindows: {nrOfIncreasingDepthReadingsSlidingWindows}");

            Console.ReadLine();
        }

        private static int Sonar(List<int> readings)
        {
            int previousReading = -1;
            int nrOfIncreasingDepthReadings = 0;

            foreach (int currentReading in readings)
            {
                if (previousReading >= 0 && currentReading > previousReading)
                {
                    nrOfIncreasingDepthReadings++;
                }
                previousReading = currentReading;
            }
            return nrOfIncreasingDepthReadings;
        }

        private static int SonarSlidingWindows(List<int> readings)
        {
            int previousWindowSum = -1;
            int nrOfIncreasingDepthReadings = 0;
            var test = readings.MakeSlidingGroupsOf(3);

            foreach (List<int> currentWindow in readings.MakeSlidingGroupsOf(3))
            {
                if(currentWindow.Count == 3)
                {
                    int currentWindowSum = currentWindow.Sum(reading => reading);
                    if (previousWindowSum >= 0 && currentWindowSum > previousWindowSum)
                    {
                        nrOfIncreasingDepthReadings++;
                    }
                    previousWindowSum = currentWindowSum;
                }
            }

            return nrOfIncreasingDepthReadings;
        }
    }

   
}
