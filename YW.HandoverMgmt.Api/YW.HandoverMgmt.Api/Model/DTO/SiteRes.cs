using System.ComponentModel.DataAnnotations;

namespace YW.HandoverMgmt.Api.Model.DTO
{
    public class SiteRes
    {
        [Key]
        public string? SiteId { get; set; }
        public string? Name { get; set; } = "";
        public string? Address { get; set; } = "";
    }
}
