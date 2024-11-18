namespace SolomikovPod.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }

        // Навигационное свойство для продукта
        public Product Product { get; set; }

        // Это свойство будет содержать название продукта
        public string ProductName => Product.Name;
    }

}
