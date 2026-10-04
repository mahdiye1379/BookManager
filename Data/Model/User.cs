namespace BookManager.Data.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAtUtc { get; set; }
        public DateTime? LastLoginAtUtc { get; set; }
    }
}
