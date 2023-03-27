using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public SingleLinkedList<T> Head { get; set; }



        public void AddFirst(T item)
        {
            if (Head == null)
            {
                Head = new SingleLinkedList<T>(item);
                return;
            }

            var current = new SingleLinkedList<T>(item);

            current.Next = Head;
            Head = current;
        }

        public void AddLast(T item)
        {
            if (Head == null)
            {
                Head = new SingleLinkedList<T>(item);
                return;
            }

            var current = Head;

            while(current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new SingleLinkedList<T>(item);
        }


        public void AddBefore(T node , T item)
        {
            if (Head == null)
            {
                Head = new SingleLinkedList<T>(item);
            }

            var current = Head;
            var previous = current;

            var newItem= new SingleLinkedList<T>(item);

            while (current != null)
            {
                if(current.Value.Equals(node))
                {
                    previous.Next = newItem;
                    newItem.Next = current;
                    return;
                }
                previous = current;
                current = current.Next;

            }
            throw new Exception($"'{node}' doesn't exist in list!");

            

        }
        
        
        //public void AddFirst(T item)
        //{
        //    if (Head == null)
        //    {
        //        Head = new SingleLinkedList<T>(item);
        //        return;
        //    }

        //    var current = new SingleLinkedList<T>(item);
        //    current.Next = Head;
        //    Head = current;

        //}

        //public void AddLast(T item)
        //{
        //    if(Head == null)
        //    {
        //        Head = new SingleLinkedList<T>(item); return;
        //    }

        //    var current = Head;


        //    while(current.Next != null)
        //    {
        //        current = current.Next;
        //    }
        //    current.Next = new SingleLinkedList<T>(item);
        //}


        //public void AddBefore(T value , T item)
        //{
        //    var test_variable = Head;
        //    var previous = Head;

        //    while (!test_variable.Value.Equals(value))
        //    {
        //        previous = test_variable;
        //        test_variable = test_variable.Next;
        //    }
        //    previous.Next=new SingleLinkedList<T>(item);
        //    var current = previous.Next;
        //    current.Next = test_variable;


        //}

    }
}
