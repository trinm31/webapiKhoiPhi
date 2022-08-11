using Microsoft.EntityFrameworkCore;
using WepApiKhoiPhi.Models;

namespace WepApiKhoiPhi.DbContext
{
    public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}