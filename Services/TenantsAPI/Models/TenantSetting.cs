namespace TenantsAPI.Models
{
    public class TenantSetting
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string ValueString { get; set; }
        public long ValueInt { get; set; }
        public bool ValueBool { get; set; }
        public DateTime ValueDateTime { get; set; }
    }
}
