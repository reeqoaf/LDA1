using System;
using System.Text;

namespace HW12
{
    public interface IEnumerable<T> where T : class
    {
        IEnumerator<T> GetEnumerator();
    }
}
