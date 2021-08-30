using System;
using System.Collections.Generic;
using System.Text;

namespace HW12
{
    public class ListEnumerator<T> : IEnumerator where T : class
    {
        public LinkedList<T> List { get; set; }

        private int position = -1;
        public ListEnumerator(LinkedList<T> list)
        {
            List = list;
        }
        public object Current
        {
            get
            {
                if (position == -1 || position >= List.Count)
                {
                    throw new InvalidOperationException();
                }
                return List[position];
            }
        }

        public bool MoveNext()
        {
            if(position < List.Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
