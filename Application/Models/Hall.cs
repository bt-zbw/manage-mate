namespace Application.Models {
    public class Hall
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid AddressId { get; set; } // Add this property
        public Address? Address { get; set; }
        //public List<Court> Courts { get; set; } = new();
    }

}
