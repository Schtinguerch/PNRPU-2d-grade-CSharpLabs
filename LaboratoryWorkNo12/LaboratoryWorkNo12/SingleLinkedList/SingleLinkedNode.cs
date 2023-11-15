using Task_2_DynamicTypeIdentification;

namespace LaboratoryWorkNo12
{
    public class SingleLinkedNode
    {
        public TrainCar Value { get; set; }
        public SingleLinkedNode Next { get; set; }

        public SingleLinkedNode Last
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

        public SingleLinkedNode(TrainCar value)
        {
            Value = value;
        }
    }
}
