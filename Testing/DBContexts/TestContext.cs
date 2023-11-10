using Microsoft.EntityFrameworkCore;
using Testing.Models;

namespace Testing.DBContexts
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test2> Tests2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}