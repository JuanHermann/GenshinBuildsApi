using Microsoft.EntityFrameworkCore;
using GenshinBuildsApi.Models;

namespace APIDesafio.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> optionsBuilder) : base(optionsBuilder)
        { }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Caracter> Caracters { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Build> Builds { get; set; }

        public DbSet<User> Users { get; set; }


    }
}