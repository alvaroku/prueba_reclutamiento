using Microsoft.EntityFrameworkCore;

namespace TestApi.Models.DB
{
    public class HumanDBContext : DbContext
    {
        public HumanDBContext(DbContextOptions<HumanDBContext> options) : base(options)
        {
        }

        public DbSet<Human> Humans { get; set; }
    }
}