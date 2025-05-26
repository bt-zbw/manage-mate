namespace Application.Models {
    public class Reservation {
        public Guid Id { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Court> Courts { get; set; }
        public List<User> Users { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private DateTime _from;
        private DateTime _to;

        public DateTime From
        {
            get => _from;
            set
            {
                if (value.Minute != 0 || value.Second != 0 || value.Millisecond != 0)
                    throw new ArgumentException("Die Zeit muss im Stundenschritt angegeben werden (z. B. 10:00, 11:00).");
                _from = value;
            }
        }

        public DateTime To
        {
            get => _to;
            set
            {
                if (value.Minute != 0 || value.Second != 0 || value.Millisecond != 0)
                    throw new ArgumentException("Die Zeit muss im Stundenschritt angegeben werden (z. B. 10:00, 11:00).");
                if (value < _from)
                    throw new ArgumentException("To darf nicht vor From liegen.");
                _to = value;
            }
        }
        public string AccessCode { get; set; }
    }
}
