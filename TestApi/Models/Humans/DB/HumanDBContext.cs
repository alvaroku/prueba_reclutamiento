using Microsoft.EntityFrameworkCore;
using TestApi.Models.Humans;

namespace TestApi.Models.Humans.DB
{
    public class HumanDBContext : DbContext
    {
        public HumanDBContext(DbContextOptions<HumanDBContext> options) : base(options)
        {
        }

        public DbSet<Human> Humans { get; set; }
    }
}