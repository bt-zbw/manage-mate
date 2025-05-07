namespace Application.Models {
    public class Reservation {
        public Guid Id { get; set; }
        public string AccessCode { get; set; }
        public Hall Hall { get; set; }
        public Court Court { get; set; }
        public User CreatedBy { get; set; }
        public List<User> Users { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Timeslot Timeslot { get; set; }
    }
}
