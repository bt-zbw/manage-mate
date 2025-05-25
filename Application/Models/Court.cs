namespace Application.Models {
    public class Court {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string? Name { get; set; }
        public List<Hall> Halls { get; set; }
        public Guid HallId { get; set; }
    }
}
