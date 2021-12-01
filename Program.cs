using AdventOfCode.Days;
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

            (int nrOfIncreasingDepthReadings, int nrOfIncreasingDepthReadingsSlidingWindows) = Day1.Solve(readings);
            Console.WriteLine($"Day 1: 1st task : nrOfIncreasingDepthReadings: {nrOfIncreasingDepthReadings}");
            Console.WriteLine($"Day 1: 2nd task : nrOfIncreasingDepthReadingsSlidingWindows: {nrOfIncreasingDepthReadingsSlidingWindows}");

            Console.ReadLine();
        }

       
    }

   
}
