using System;
using System.Text;

namespace HW12
{
    public interface IEnumerable<out T>
    {
        IEnumerator GetEnumerator();
    }
}
