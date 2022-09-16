namespace LicensesAPI.Models
{
    public class LicenseType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ValidMonths { get; set; }
        public int PriceMonth { get; set; }
        public int Subscriptions { get; set; }
    }
}
