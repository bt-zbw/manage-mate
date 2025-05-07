using System;

namespace Application.Models {
    public class Callendar {
        public Guid Id { get; set; }
        public Hall Hall { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Dictionary<System.DayOfWeek, Timeslot> StandardOpeningHours { get; set; }
        public List<Timeslot> SpecialOpeningHours { get; set; }
    }
}
