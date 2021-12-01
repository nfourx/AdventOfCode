using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> MakeSlidingGroupsOf<T>(this IEnumerable<T> source, int count)
        {
            var grouping = new List<T>();

            for (int i = 0; i <= source.Count(); i++)
            {
                var chunk = source.Skip(i).Take(count);
                if (chunk.Count() >= count) grouping.AddRange(chunk);
                yield return grouping;
                grouping = new List<T>();                
            }
        }
    }
}
