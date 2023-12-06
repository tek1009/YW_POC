using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YW.HandoverMgmt.Api.DataLayer;
using YW.HandoverMgmt.Api.Model.DTO;
using YW.HandoverMgmt.Api.Model.Entity;

namespace YW.HandoverMgmt.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class YWCertificateController : ControllerBase
    {
        private readonly YWDbContextcs _dbContext;
        public YWCertificateController(YWDbContextcs dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost("certificates")]
        public async Task<IActionResult> SaveCertificate([FromBody] CertificateReq certificateReq)
        {
            var cert = new CertificateDto()
            {
                //Section-1
                Type=certificateReq.Type,
                Mode=certificateReq.Mode,
                Site=certificateReq.Site,
                Handover_Reference=certificateReq.Handover_Reference,
                Authorized_Person=certificateReq.Authorized_Person,
                Contractor=certificateReq.Contractor,
                Contractor_Representative=certificateReq.Contractor_Representative,
                //Section-2
                Site_Location=certificateReq.Site_Location,
                Equipments=certificateReq.Equipments,
                Access_Arrangements=certificateReq.Access_Arrangements,
                Commence_Date=certificateReq.Commence_Date,
                Completion_Date=certificateReq.Completion_Date,
                Work_Description=certificateReq.Work_Description,
                IsInspectionUnderTaken=certificateReq.IsInspectionUnderTaken,
                IsStartOnSiteLetter=certificateReq.IsStartOnSiteLetter,
                IsHealthNSaftey=certificateReq.IsHealthNSaftey,
                //Handover
                Handover_Name=certificateReq.Handover_Name,
                Takeover_Name=certificateReq.Takeover_Name,
                Handover_Date=certificateReq.Handover_Date,
                Handover_Comment=certificateReq.Handover_Comment,
                //Handback
                Handback_Name=certificateReq.Handback_Name,
                Takeback_Name=certificateReq.Takeback_Name,
                Handback_Date=certificateReq.Handback_Date,
                Handback_Comment=certificateReq.Handback_Comment,
                IsActive="True",
                CreatedOn=DateTime.UtcNow.ToString(),
                CreatedBy=certificateReq.CreatedBy,
                UpdatedOn=certificateReq.UpdatedOn,
                UpdatedBy=certificateReq.UpdatedBy,
                Status="New"
            };
            cert.Id=Guid.NewGuid().ToString();
            await _dbContext.AddAsync(cert);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(SaveCertificate), new { id = cert.Id }, cert);
        }

        [HttpPut("certificates/{id}")]
        public async Task<IActionResult> ModifyCertificate(string id, CertificateReq editReq)
        {
            var isExistCertificate = await _dbContext.Certificates.FindAsync(id);
            if(isExistCertificate != null)
            {
                isExistCertificate.Mode=editReq.Mode;
                isExistCertificate.Site=editReq.Site;
                isExistCertificate.Site_Location=editReq.Site_Location;
                isExistCertificate.Commence_Date=editReq.Commence_Date;
                isExistCertificate.Completion_Date=editReq.Completion_Date;
                isExistCertificate.Work_Description=editReq.Work_Description;
                isExistCertificate.Access_Arrangements=editReq.Access_Arrangements;
                isExistCertificate.UpdatedBy=editReq.UpdatedBy;
                isExistCertificate.CreatedOn=editReq.CreatedOn;
                isExistCertificate.UpdatedOn=DateTime.UtcNow.ToString();
                isExistCertificate.IsActive="True";
                isExistCertificate.Equipments=editReq.Equipments;
                isExistCertificate.Handover_Reference=editReq.Handover_Reference;
                isExistCertificate.IsHealthNSaftey=editReq.IsHealthNSaftey;
                isExistCertificate.IsInspectionUnderTaken=editReq.IsInspectionUnderTaken;
                isExistCertificate.IsStartOnSiteLetter=editReq.IsStartOnSiteLetter;
                //Handover
                isExistCertificate.Handover_Name=editReq.Handover_Name;
                isExistCertificate.Takeover_Name=editReq.Takeover_Name;
                isExistCertificate.Handover_Date=editReq.Handover_Date;
                isExistCertificate.Handover_Comment=editReq.Handover_Comment;
                //Handback
                isExistCertificate.Handback_Name=editReq.Handback_Name;
                isExistCertificate.Handback_Date=editReq.Handback_Date;
                isExistCertificate.Takeback_Name=editReq.Takeback_Name;
                isExistCertificate.Handback_Comment=editReq.Handback_Comment;
                await _dbContext.SaveChangesAsync();
                return Ok(isExistCertificate);
            }
            return NotFound("Certificate is not available..Please provide the correct Certificate!");
        }

        [HttpGet("certificates")]
        public async Task<List<CertificateDto>> GetAllCertificates()
        {
            List<CertificateDto> certificates = new List<CertificateDto>();
            var resultCerts = _dbContext.Certificates.Select(x => new
            {
                x.Id,
                x.Type,
                x.Mode,
                x.Site_Location,
                x.Site,
                x.Contractor,
                x.Contractor_Representative,
                x.Commence_Date,
                x.Completion_Date,
                x.Authorized_Person,
                x.Work_Description,
                x.Access_Arrangements,
                x.CreatedOn,
                x.CreatedBy,
                x.Equipments,
                x.Handback_Date,x.Handback_Name,x.Takeback_Name,x.Handback_Comment,
                x.Handover_Comment, x.Handover_Name,x.Handover_Reference,x.Takeover_Name,x.Handover_Date,
                x.IsHealthNSaftey,
                x.IsInspectionUnderTaken,
                x.IsStartOnSiteLetter,
                x.IsActive, x.Status
            }).Where(x => x.IsActive=="True" || x.IsActive== "true").OrderByDescending(x=>x.CreatedOn);
            foreach (var cert in resultCerts) 
            {
                CertificateDto req = new CertificateDto();
                req.Id = cert.Id;
                req.Mode = cert.Mode;
                req.Type = cert.Type;
                req.Site = cert.Site;
                req.Contractor = cert.Contractor;
                req.Work_Description=cert.Work_Description;
                req.Authorized_Person = cert.Authorized_Person;
                req.Access_Arrangements = cert.Access_Arrangements;
                req.Commence_Date = cert.Commence_Date;
                req.Completion_Date = cert.Completion_Date;
                req.CreatedOn = cert.CreatedOn;
                req.CreatedBy = cert.CreatedBy;
                req.Handover_Name = cert.Handover_Name;
                req.Handover_Reference = cert.Handover_Reference;
                req.Handover_Comment=cert.Handover_Comment;
                req.Handback_Name = cert.Handback_Name;
                req.Handback_Date=cert.Handback_Date;
                req.Handover_Date=cert.Handover_Date;
                req.Handback_Comment=cert.Handback_Comment;
                req.Equipments = cert.Equipments;
                req.IsHealthNSaftey = cert.IsHealthNSaftey;
                req.IsInspectionUnderTaken = cert.IsInspectionUnderTaken;
                req.IsStartOnSiteLetter= cert.IsStartOnSiteLetter;
                req.IsActive = cert.IsActive;
                req.Status = cert.Status;
                certificates.Add(req);
            }
            return certificates;
           
        }
    }
}
