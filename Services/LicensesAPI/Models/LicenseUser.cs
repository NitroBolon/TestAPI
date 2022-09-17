namespace LicensesAPI.Models
{
    public class LicenseUser
    {
        public long Id { get; set; }
        public long LicenseId { get; set; }
        public string? UserId { get; set; }
    }
}
