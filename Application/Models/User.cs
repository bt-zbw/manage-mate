﻿namespace Application.Models {
    public class User {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
    }
}
