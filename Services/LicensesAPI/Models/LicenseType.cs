namespace LicensesAPI.Models
{
    public class LicenseType : LicenseTypeDto
    {
        public bool IsOfferActive { get; set; }
    }

    public class LicenseTypeDto : LicenseTypePostDto
    {
        public long Id { get; set; }
        public int Subscriptions { get; set; }
    }

    public class LicenseTypePostDto
    {
        public string? Name { get; set; }
        public int ValidMonths { get; set; }
        public int PriceMonth { get; set; }
    }
}
