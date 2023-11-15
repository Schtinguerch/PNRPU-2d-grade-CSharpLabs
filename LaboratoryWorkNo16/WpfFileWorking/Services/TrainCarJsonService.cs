using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using Task_2_DynamicTypeIdentification;

namespace WpfFileWorking.Services
{
    public class TrainCarJsonService
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto
        };

        public void SerializeToFile(List<TrainCar> cars, string path)
        {
            var seriazedJson = JsonConvert.SerializeObject(cars, Settings);
            using (var writer = new StreamWriter(path, append: false))
            {
                writer.Write(seriazedJson);
            }
        }

        public List<TrainCar> DeserializedFromFile(string path)
        {
            var cars = new List<TrainCar>();
            using (var reader = new StreamReader(path))
            {
                var json = reader.ReadToEnd();
                cars = JsonConvert.DeserializeObject<List<TrainCar>>(json, Settings);
            }

            return cars;
        }
    }
}