namespace SolomikovPod.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
