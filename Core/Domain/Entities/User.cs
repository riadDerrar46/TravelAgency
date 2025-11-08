namespace Core.Domain.Entities
{
    public class User : BasicEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Second_PhoneNumber { get; set; }
        public string? Third_PhoneNumber { get; set; }
        public string IdCard_Number { get; set; } = "";
        public string Passport_Number { get; set; } = "";

    }
}
