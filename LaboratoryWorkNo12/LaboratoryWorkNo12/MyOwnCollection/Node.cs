using System;
using System.Collections.Generic;
using System.Linq;

namespace LaboratoryWorkNo12
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node<T> Last
        {
            get
            {
                if (Next == null)
                {
                    return this;
                }

                return Next.Last;
            }
        }

        public Node(T value)
        {
            Value = value;
        }
    }
}
