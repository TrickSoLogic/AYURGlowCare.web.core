namespace AYURGlowCare.web.core.Models
{
    public class order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
