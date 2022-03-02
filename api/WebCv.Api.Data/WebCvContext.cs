using Microsoft.EntityFrameworkCore;
using WebCv.Api.Data.Entities;

namespace WebCv.Api.Data
{
    public class WebCvContext : DbContext
    {
        public WebCvContext(DbContextOptions<WebCvContext> options) : base(options)
        {

        }

        public DbSet<PersonalInformation> PersonalInformation { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<ResumeLine> ResumeLines { get; set; }
        public DbSet<Project> Projects { get; set; }


        public void DetachAllEntites()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
