using Microsoft.EntityFrameworkCore;

namespace Core.Domain.Entities.DB
{
    public class ITravelAgency_DbContext : DbContext
    {
        public ITravelAgency_DbContext(DbContextOptions<ITravelAgency_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Core.Domain.Entities.Client> Client { get; set; } = default!;
    }
}
