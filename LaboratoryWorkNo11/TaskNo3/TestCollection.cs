using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task_2_DynamicTypeIdentification;
using LaboratoryWorkNo11.Menu;

using static System.Console;
using UKit.Console;

namespace TaskNo3
{
    public class TestCollection
    {
        public readonly Stack<string> TestStack = new Stack<string>();
        public readonly Stack<TrainCar> TestCarStack = new Stack<TrainCar>();

        public readonly SortedDictionary<string, TrainCar> TestDictionary = new SortedDictionary<string, TrainCar>();
        public readonly SortedDictionary<TrainCar, TrainCar> TestCarDictionary = new SortedDictionary<TrainCar,TrainCar>();

        public void AddRandomItems(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddRandomItem();
            }
        }

        public void AddRandomItem()
        {
            var randomCar = TrainCarCreator.NewRandomCar();
            var carString = randomCar.ToString();

            TestStack.Push(carString);
            TestCarStack.Push(randomCar);

            TestDictionary.Add(carString, randomCar);
            TestCarDictionary.Add(randomCar.BaseCar(), randomCar);
        }

        public void AddUserInputItem()
        {
            var newCar = TrainCarCreator.NewUserCar();
            var carString = newCar.ToString();

            TestStack.Push(carString);
            TestCarStack.Push(newCar);

            TestDictionary.Add(carString, newCar);
            TestCarDictionary.Add(newCar.BaseCar(), newCar);
        }

        public void DeleteItems(int count)
        {
            if (count > TestStack.Count)
            {
                WriteLine(
                    "Товарищ, в коллекции нет столько элементов!!!\n" +
                    "Не буду ничего удалять!!!");

                return;
            }

            for (int i = 0; i < count; i++)
            {
                DeleteLastItem();
            }
        }

        public bool DeleteLastItem()
        {
            if (TestStack.Count == 0)
            {
                WriteLine("Ошибка: коллекция пуста");
                return false;
            }

            TestStack.Pop();
            TestCarStack.Pop();

            TestDictionary.Remove(TestDictionary.Last().Key);
            TestCarDictionary.Remove(TestCarDictionary.Last().Key);

            return true;
        }
    }
}
