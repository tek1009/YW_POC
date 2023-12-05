using System.ComponentModel.DataAnnotations;

namespace YW.HandoverMgmt.Api.Model.Entity
{
    public class SiteReq
    {
        [Key]
        public string? SiteId { get; set; }
        public string? Name { get; set; } = "";
        public string? Address { get; set; } = "";
    }
}
