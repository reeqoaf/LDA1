using System;

namespace HW12
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>("-1");
            for (int i = 0; i < 10; i++)
            {
                linkedList.Add(i.ToString());
            }

            //PrintLinkedList(linkedList);
            //Console.WriteLine(linkedList[0]);
            //Console.WriteLine(linkedList[10]);
            //PrintLinkedListReversed(linkedList);
            linkedList.Reverse();
            //PrintLinkedList(linkedList);
            foreach(var element in linkedList)
            {
                Console.WriteLine(element);
            }
        }

        static void PrintLinkedList<T>(LinkedList<T> list) where T : class
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void PrintLinkedListReversed<T>(LinkedList<T> list) where T : class
        {
            var current = list.Last();
            do
            {
                Console.WriteLine(current);
                current = current.Prev;
            }
            while (current != null);
        }
    }
}
