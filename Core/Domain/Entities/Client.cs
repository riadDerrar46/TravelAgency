namespace Core.Domain.Entities
{
    public class Client : BasicEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Second_PhoneNumber { get; set; }
        public string? Third_PhoneNumber { get; set; }
        public string Job { get; set; } = "None";
        public string IdCard_Number { get; set; } = "";
        public string? IdCard_ImgUrl { get; set; }
        public string Passport_Number { get; set; } = "";
        public string? Passport_ImgUrl { get; set; }

    }
}
