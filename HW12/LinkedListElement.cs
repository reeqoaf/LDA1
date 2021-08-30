using System;
using System.Collections.Generic;
using System.Text;

namespace HW12
{
    public class LinkedListElement<T> where T : class 
    {
        public T Value { get; set; }
        public LinkedListElement<T> Prev { get; set; }
        public LinkedListElement<T> Next { get; set; }


        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"PV: {Prev?.Value.ToString() ?? "Empty"}, V: {Value}, NV: {Next?.Value.ToString() ?? "Empty"}";
        }
    }
}
