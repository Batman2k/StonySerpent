namespace StonySerpent.Core.Models
{
    public class CartProduct
    {
        public CartProduct()
        {
            
        }

        public CartProduct(int productId, double price)
        {
            Price = price;
            ProductId = productId;
            Amount = 1;
        }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        
    }
}