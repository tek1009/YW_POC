namespace YW.HandoverMgmt.Api.Model.Entity
{
    public class CertificateReq
    {
        public string? Type { get; set; }
        public string? Mode { get; set; }
        public string? Site { get; set; }
        public string? Handover_Reference { get; set; }
        public string? Authorized_Person { get; set; }
        public string? Contractor { get; set; }
        public string? Contractor_Representative { get; set; } = "";
        public string? Site_Location { get; set; }
        public string? Equipments { get; set; }
        public string? Access_Arrangements { get; set; }
        public string? Commence_Date { get; set; } = string.Empty;
        public string? Work_Description { get; set; }
        public string? Completion_Date { get; set; } = string.Empty;
        public string? IsInspectionUnderTaken { get; set; }
        public string? IsStartOnSiteLetter { get; set; }
        public string? IsHealthNSaftey { get; set; }
        public string? Handover_Name { get; set; } = "";
        public string? Takeover_Name { get; set; } = "";
        public string? Handover_Date { get; set; } = string.Empty;
        public string? Handover_Comment { get; set; } = "";
        public string? Handback_Name { get; set; } = "";
        public string? Takeback_Name { get; set; } = "";
        public string? Handback_Date { get; set; } = "";
        public string? Handback_Comment { get; set; } = "";
        public string? CreatedOn { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = "";
        public string? UpdatedOn { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; }
        public string? IsActive { get; set; }
        public string? Status { get; set; } = "";
    }
}
