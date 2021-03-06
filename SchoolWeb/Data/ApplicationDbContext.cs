using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.Models;

namespace SchoolWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<EgeResult> EgeResults { get; set; }
        public DbSet<OgeResult> OgeResults { get; set; }
        public DbSet<Staff> SchoolStaff { get; set; }
        public DbSet<Administration> SchoolAdministration { get; set; }
        public DbSet<SettingOption> Settings { get; set; }
        public DbSet<PhotoModel> Photoes { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
    }
}
