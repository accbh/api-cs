using Bahrain.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bahrain.API.Data
{

    public class BahrainDataContext : DbContext
    {
        public BahrainDataContext(DbContextOptions<BahrainDataContext> opt) : base(opt)
        {
        }

        public DbSet<ATController> ATControllers { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
    }

}