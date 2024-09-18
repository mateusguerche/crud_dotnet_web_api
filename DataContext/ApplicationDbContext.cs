using Microsoft.EntityFrameworkCore;
using WebAPI_Projeto01.Models;

namespace WebAPI_Projeto01.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
    }
}
