using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

using Task_2_DynamicTypeIdentification;
using UKit.Console;

namespace LaboratoryWorkNo11.Menu
{
    public static class TrainCarCreator
    {
        private static readonly Random _random = new Random();

        delegate TrainCar GenerateCarMethod();
        private static GenerateCarMethod[] CarsGenerators = new GenerateCarMethod[]
        {
            NewRandomLocomotive,
            NewRandomKitchenCar,
            NewRandomEconomClass,
            NewRandomCompartmentalCar,
        };

        public static TrainCar NewRandomCar() =>
            CarsGenerators[_random.Next(CarsGenerators.Length)].Invoke();

        public static TrainCar NewUserCar() =>
            CarsGenerators[UConsole.ReadInt(
                "Выберите тип вагона:\n" +
                "0 - Локомотив\n" +
                "1 - Кухня\n" +
                "2 - Эконом-класс\n" +
                "3 - Купе\n > "
                , 0, 3)].Invoke();

        public static Locomotive NewUserInputLocomotive() =>
            new Locomotive(
                mass: UConsole.ReadInt("Масса: ", 1, 1000),
                length: UConsole.ReadInt("Длина: ", 1, 20),
                enginePower: UConsole.ReadInt("Мощность двигателя: ", 1, 5000),
                maxSpeed: UConsole.ReadInt("Макс. скорость: ", 10, 200));

        public static Locomotive NewRandomLocomotive() =>
            new Locomotive(
                mass: _random.Next(1, 1000000000),
                length: _random.Next(1, 1000000000),
                enginePower: _random.Next(10, 5000),
                maxSpeed: _random.Next(10, 200));

        public static KitchenCar NewUserKitchenCar() =>
            new KitchenCar(
                mass: UConsole.ReadInt("Масса: ", 1, 1000),
                length: UConsole.ReadInt("Длина: ", 1, 20),
                dishAssortiment: ReadList("Список блюд: ", "Блюдо"));

        public static KitchenCar NewRandomKitchenCar() =>
            new KitchenCar(
                mass: _random.Next(1, 1000000000),
                length: _random.Next(1, 1000000000),
                dishAssortiment: RandomList());

        public static EconomClass NewUserEconomClassCar() =>
            new EconomClass(
                mass: UConsole.ReadInt("Масса: ", 1, 1000),
                length: UConsole.ReadInt("Длина: ", 1, 20),
                passengerCapacity: UConsole.ReadInt("Вместимость (чел.): ", 10, 100),
                levelCount: UConsole.ReadInt("Кол-во ярусов: ", 1, 2));

        public static EconomClass NewRandomEconomClass() =>
            new EconomClass(
                mass: _random.Next(1, 1000000000),
                length: _random.Next(1, 1000000000),
                passengerCapacity: _random.Next(10, 100),
                levelCount: _random.Next(1, 3));

        public static CompartmentalCar NewUserCompartmentalClassCar() =>
            new CompartmentalCar(
                mass: UConsole.ReadInt("Масса: ", 1, 1000),
                length: UConsole.ReadInt("Длина: ", 1, 20),
                passengerCapacity: UConsole.ReadInt("Вместимость (чел.): ", 10, 100),
                includesSoundProofing: UConsole.ReadBool("Наличие звукоизоляции (да, нет): ", "да", "нет"));

        public static CompartmentalCar NewRandomCompartmentalCar() =>
            new CompartmentalCar(
                mass: _random.Next(1, 1000000000),
                length: _random.Next(1, 1000000000),
                passengerCapacity: _random.Next(10, 100),
                includesSoundProofing: true);

        private static List<string> ReadList(string message = "", string itemName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
                WriteLine(message);

            var list = new List<string>();
            WriteLine("Для завершения, введите 0:");

            int i = 0;

            while (true)
            {
                i++;

                Write($"{itemName} #{i}: ");
                var line = ReadLine();

                if (line.Trim() == "0") break;
                list.Add(line);
            }

            return list;
        }
    
        private static List<string> RandomList()
        {
            int count = _random.Next(3, 8);
            var list = new List<string>(count);

            for (int i = 0; i < count; i++)
                 list.Add(RandomString(_random.Next(3, 9)));

            return list;
        }

        public static string RandomString(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }
    }
}
