namespace Task_3_Interfaces
{
    public class Sticker
    {
        public string Name { get; set; }
        public double RecommendedCost { get; set; }

        public Sticker(string name, double recommendedCost)
        {
            Name = name;
            RecommendedCost = recommendedCost;
        }
    }
}
