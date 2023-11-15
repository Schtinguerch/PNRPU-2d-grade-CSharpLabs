using System;

namespace Task_3_Interfaces
{
    public interface IExecutable : IComparable, ICloneable
    {
        void ExecuteInflation(double percentage);
    }
}
