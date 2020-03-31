using System;

namespace NinjaCore2.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }       
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
