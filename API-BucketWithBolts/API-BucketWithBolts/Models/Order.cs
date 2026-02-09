namespace Api_Topito.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Vendor_id { get; set; }
        public int Resourse_id { get; set; }
        public int Customer_id { get; set; }
        public int Status { get; set; } = 1;
    }
}
