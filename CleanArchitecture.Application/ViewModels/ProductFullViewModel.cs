namespace CleanArchitecture.Application.ViewModels
{
    public class ProductFullViewModel
    {
        public long IdProduct { get; set; }
        public long IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
