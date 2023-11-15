using LaboratoryWorkNo12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_DynamicTypeIdentification;

namespace LaboratoryWorkNo14
{
    public static class MyExtensions
    {
        public static IEnumerable<TrainCar> GetKitchens(this MyOwnLinkedList<TrainCar> targetList)
        {
            var kitchens = targetList.Where(c => c is KitchenCar);
            return kitchens;
        }

        public static double AverageLength(this MyOwnLinkedList<TrainCar> targetList)
        {
            var averageLength = targetList.Average(c => c.Length);
            return averageLength;
        }

        public static IEnumerable<TrainCar> Sorted(this MyOwnLinkedList<TrainCar> targetList)
        {
            var sorted = targetList.OrderBy(c => c);
            return sorted;
        }

        public static IEnumerable<TrainCar> SortedQueryLanguage(this MyOwnLinkedList<TrainCar> targetList)
        {
            var sorted = from car in targetList orderby car select car; 
            return sorted;
        }
    }
}
