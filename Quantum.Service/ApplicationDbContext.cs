using Microsoft.EntityFrameworkCore;
using Quantum.Service.Model;

namespace Quantum.Service
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
    }
}