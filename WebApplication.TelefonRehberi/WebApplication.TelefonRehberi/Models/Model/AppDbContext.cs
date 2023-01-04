using System.Data.Entity;
using WebApplication.TelefonRehberi.Models.Concrete;

namespace WebApplication.TelefonRehberi.Models.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rehber> Rehbers { get; set; }

       
    }
}