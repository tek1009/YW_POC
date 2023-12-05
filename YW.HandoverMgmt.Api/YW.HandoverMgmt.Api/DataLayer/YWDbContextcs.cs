using Microsoft.EntityFrameworkCore;
using YW.HandoverMgmt.Api.Model.DTO;

namespace YW.HandoverMgmt.Api.DataLayer
{
    public class YWDbContextcs: DbContext
    {
        public YWDbContextcs(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<CertificateDto> Certificates { get; set; }
        public DbSet<SiteRes> Sites { get; set; }
        public DbSet<UserRes> Contacts { get; set; }
    }
}
