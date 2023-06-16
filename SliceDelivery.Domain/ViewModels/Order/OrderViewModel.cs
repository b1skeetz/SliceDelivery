namespace SliceDelivery.Domain.ViewModels.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        
        public string ProductName { get; set; }
        
        public string Description { get; set; }
        
        public string ProductType { get; set; }
        public double CurrentPrice { get; set; }
        
        public string Image { get; set; }
        
        public string Address { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string DateCreate { get; set; }
    }   
}