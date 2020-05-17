using Microsoft.EntityFrameworkCore;
using dotnet_rpg.Model;

namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        public DbSet<Character> Characters {get;set;}
        public DbSet<User> Users {get;set;}
    }
}