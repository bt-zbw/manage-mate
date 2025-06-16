namespace Application.Models {
    public class Reservation {
        public Guid Id { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Court> Courts { get; set; }
        public List<User> Users { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private DateTime _from = DateTime.Now;
        private DateTime _to = DateTime.Now.AddHours(1);

        public DateTime From
        {
            get => _from;
            set
            {
                _from = value.ToUniversalTime();
            }
        }

        public DateTime To
        {
            get => _to;
            set
            {
                if (value < _from)
                    throw new ArgumentException("To darf nicht vor From liegen.");
                _to = value.ToUniversalTime();
            }
        }
        public string AccessCode { get; set; }
    }
}