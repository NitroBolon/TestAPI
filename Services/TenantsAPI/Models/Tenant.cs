namespace TenantsAPI.Models
{
    public class Tenant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public long LicenseId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<TenantSetting> Settings { get; set; }
    }
}
