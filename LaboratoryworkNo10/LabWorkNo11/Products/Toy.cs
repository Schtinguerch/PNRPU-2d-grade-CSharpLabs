namespace Task_1_ClassHierarchy
{
    public class Toy : Product
    {
        protected readonly string _manufactureMaterial;

        public string ManufactureMaterial => _manufactureMaterial;

        public Toy(string productId, string name, int cost, string manufactureMaterial) : 
            base(productId, name, cost)
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
