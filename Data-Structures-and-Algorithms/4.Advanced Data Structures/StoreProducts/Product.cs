namespace StoreProducts
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return (int)((this.Price - other.Price) % int.MaxValue);
        }
    }
}
