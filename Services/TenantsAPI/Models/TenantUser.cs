namespace TenantsAPI.Models
{
    public class TenantUser
    {
        public long Id { get; set; }
        public string? UserId { get; set; }
        public long TenantId { get; set; }
    }
}
