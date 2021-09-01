using System;
using System.Collections.Generic;
using System.Text;

namespace HW12
{
    public interface IEnumerator<T> where T : class
    {
        bool MoveNext();
        object Current { get; }
        void Reset();
    }
}
