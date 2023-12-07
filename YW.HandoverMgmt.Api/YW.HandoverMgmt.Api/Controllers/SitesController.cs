using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YW.HandoverMgmt.Api.DataLayer;
using YW.HandoverMgmt.Api.Model.Entity;
using YW.HandoverMgmt.Api.Model.DTO;

namespace YW.HandoverMgmt.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        private readonly YWDbContextcs _dbContext;
        public SitesController(YWDbContextcs dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("sites")]
        public async Task<List<SiteReq>> GetAllSites()
        {
            List<SiteReq> siteList=new List<SiteReq>();
          var allSites = _dbContext.Sites.Select(x => new { x.SiteId, x.Name, x.Address });
          foreach (var site in allSites)
            {
                SiteReq siteReq = new SiteReq();
                siteReq.SiteId = site.SiteId;
                siteReq.Name = site.Name;
                siteReq.Address = site.Address;
                siteList.Add(siteReq);
            }
          return siteList;
        }
        [HttpGet("sites/{id}")]
        public async Task<SiteRes>? GetSiteById(string id)
        {
            var result = await _dbContext.Sites.FirstOrDefaultAsync(x=>x.SiteId==id);
            if (result != null) 
            {
                return result;
            }
            return null;
             
        }
        [HttpGet("equipments")]
        public async Task<List<EquipmentDto>>? GetAllEquipments()
        {
            List<EquipmentDto> listOfEquips = new List<EquipmentDto>();
            var result=_dbContext.Equipments.Select(x=> new {x.Id,x.Name,x.Description});
            foreach (var item in result)
            {
                EquipmentDto equipment = new EquipmentDto();
                equipment.Id = item.Id;
                equipment.Name = item.Name;
                equipment.Description = item.Description;
                listOfEquips.Add(equipment);
            }
            return listOfEquips;
        }
    }
}
