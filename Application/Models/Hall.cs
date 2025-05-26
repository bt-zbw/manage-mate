namespace Application.Models {
    public class Hall {
        public Guid Id { get; set; }
        public Address Address { get; set; }
        public List<Court> Courts { get; set; }
    }
}
