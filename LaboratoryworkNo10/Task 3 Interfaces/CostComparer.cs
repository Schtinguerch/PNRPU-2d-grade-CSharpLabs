using System.Collections.Generic;

namespace Task_3_Interfaces
{
    public class CostComparer : IComparer<IExecutable>
    {
        public int Compare(IExecutable x, IExecutable y)
        {
            var xCost = (x as Product).Cost;
            var yCost = (y as Product).Cost;

            if (xCost > yCost)
                return 1;

            if (xCost < yCost)
                return -1;

            return 0;
        }
    }
}
