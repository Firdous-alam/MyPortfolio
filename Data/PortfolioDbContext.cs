using Microsoft.EntityFrameworkCore;
using Firdous_Portfolio.Models; 

namespace Firdous_Portfolio.Data
{
    public class PortfolioDbContext : DbContext  
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) 
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
