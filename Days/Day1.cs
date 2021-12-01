using AdventOfCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day1
    {
        public static (int,int) Solve(List<int> readings)
        {
            return (Sonar(readings), SonarSlidingWindows(readings));
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

            foreach (List<int> currentWindow in readings.MakeSlidingGroupsOf(3))
            {
                if (currentWindow.Count == 3)
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
