using Microsoft.EntityFrameworkCore;

namespace GuestiaCodingTask.Data
{
    public class GuestiaContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestGroup> GuestGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=GuestiaDB;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=master;Initial Catalog=master;Persist Security Info=False;User Id=sa;Password=Guestia123!;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;");
        }
    }
}
