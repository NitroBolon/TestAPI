namespace LicensesAPI.Models
{
    public class License
    {
        public long Id { get; set; }
        public long TenantId { get; set; }
        public DateTime StartDate { get; set; }
        public LicenseType? Type { get; set; }
    }
}
