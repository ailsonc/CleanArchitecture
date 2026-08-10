namespace CleanArchitecture.Domain.Models
{
    public class Category
    {
        #region Properties
        public long IdCategory { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        #endregion

        #region Navigation Properties
        // A category has multiple products.
        public List<Product> Products { get; set; }
        #endregion
        public void Update(string description)
        {
            Description = description;
        }
    }
}
