using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_2_DynamicTypeIdentification;

namespace LaboratoryWorkNo12
{
    public class BinaryTreeNode
    {
        public BinaryTreeNode LeftNode { get; set; }
        public BinaryTreeNode RightNode { get; set; }

        public TrainCar Value { get; set; }
        public BinaryTreeNode MinValueNode
        {
            get
            {
                if (LeftNode == null)
                {
                    return this;
                }

                return LeftNode.MinValueNode;
            }
        }

        public BinaryTreeNode(TrainCar value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var otherTree = obj as BinaryTreeNode;
            if (otherTree == null)
            {
                return false;
            }

            return
                Value == otherTree.Value &&
                LeftNode == otherTree.LeftNode &&
                RightNode == otherTree.RightNode;
        }
    }
}
