using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_2_DynamicTypeIdentification;

namespace LaboratoryWorkNo12
{
    public class DoubleLinkedListNode
    {
        public DoubleLinkedListNode Previous { get; set; }
        public DoubleLinkedListNode Next { get; set; }

        public TrainCar Value { get; set; }

        public DoubleLinkedListNode Last
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

        public DoubleLinkedListNode First
        {
            get
            {
                if (Previous == null)
                {
                    return this;
                }

                return Previous.First;
            }
        }

        public DoubleLinkedListNode(TrainCar value)
        {
            Value = value;
        }
    }
}
