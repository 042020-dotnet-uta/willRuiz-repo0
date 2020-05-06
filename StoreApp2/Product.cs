namespace StoreApp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; }
        public float Price { get; }

        public Product() { }
        public Product(string name)
        {
            Name = name;
        }
    }
}