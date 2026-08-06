
namespace CleanArchitecture.Domain.Models
{
    public class Product
    {
        #region Properties
        public long IdProduct { get; set; }
        public long IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistrationDate { get; set; }
        #endregion

        #region Navigation Properties
        public Category Category { get; set; }
        #endregion
    }
}