using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Application.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> source, int indexCount = 0)
        {
            return source.Select((item, index) => (item, index + indexCount));
        }
    }
}
