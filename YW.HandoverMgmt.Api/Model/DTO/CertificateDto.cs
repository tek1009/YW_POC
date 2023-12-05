using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YW.HandoverMgmt.Api.Model.DTO
{
    public class CertificateDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
        public string? Type { get; set; } = string.Empty;
        public string? Mode { get; set; } = string.Empty;
        public string? Site { get; set; } = string.Empty;
        public string? Handover_Reference { get; set; } = string.Empty;
        public string? Authorized_Person { get; set; } = string.Empty;
        public string? Contractor { get; set; } = string.Empty;
        public string? Contractor_Representative { get; set; }
        public string? Site_Location { get; set; } = string.Empty;
        public string? Equipments { get; set; } = string.Empty;
        public string? Access_Arrangements { get; set; } = string.Empty;
        public string? Work_Description { get; set; } = string.Empty;
        public string? Commence_Date { get; set; } = string.Empty;
        public string? Completion_Date { get; set; } = string.Empty;
        public string? IsInspectionUnderTaken { get; set; } = string.Empty;
        public string? IsStartOnSiteLetter { get; set; } = string.Empty;
        public string? IsHealthNSaftey { get; set; } = string.Empty;
        public string? Handover_Name { get; set; } = string.Empty;
        public string? Takeover_Name { get; set; } = string.Empty;
        public string? Handover_Date { get; set; } = string.Empty;
        public string? Handover_Comment { get; set; }= "";
        public string? Handback_Name { get; set; } = string.Empty;
        public string? Takeback_Name { get; set; } = string.Empty;
        public string? Handback_Date { get; set; } = string.Empty;
        public string? Handback_Comment { get; set; } = string.Empty;
        public string? CreatedOn { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = string.Empty;
        public string? UpdatedOn { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; } = string.Empty;
        public string? IsActive { get; set; } = string.Empty;
    }
}
