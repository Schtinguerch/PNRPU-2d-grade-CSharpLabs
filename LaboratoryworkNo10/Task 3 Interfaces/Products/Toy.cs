namespace Task_3_Interfaces
{
    public class Toy : Product
    {
        public override object Clone()
        {
            var cloneSticker = new Sticker(_sticker.Name, _sticker.RecommendedCost);
            return new Toy(cloneSticker, Id, Name, Cost, ManufactureMaterial);
        }

        protected readonly string _manufactureMaterial;

        public string ManufactureMaterial => _manufactureMaterial;

        public Toy(Sticker sticker, string productId, string name, double cost, string manufactureMaterial) : 
            base(sticker, productId, name, cost)
        {
            _manufactureMaterial = manufactureMaterial;
        }

        public override string ToString() => Info();
        public override string Info() => BaseInfo();

        public new string BaseInfo() =>
            $"Игрушка: Id = {Id}; Название = {Name}; Стоимость = {Cost}$; " +
            $"Материал изготовления = {ManufactureMaterial};";
    }
}
