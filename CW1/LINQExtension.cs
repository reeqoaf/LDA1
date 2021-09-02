using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CW1
{
    public static class LINQExtension
    {
        public static User Random(this IEnumerable<User>? source)
        {
            return source.Skip(new Random().Next(0, source.Count())).First();
        }
    }
}
