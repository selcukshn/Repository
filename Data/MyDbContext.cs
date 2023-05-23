using Microsoft.EntityFrameworkCore;
using Repository.Data.Entity;

namespace Repository.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder config)
        {
            if (!config.IsConfigured)
                config.UseSqlServer("server=SELCUK\\SQLEXPRESS;initial catalog=RepositoryTest;integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var users = new List<User>();
            for (int i = 0; i < 25; i++)
            {
                users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Name = new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyz", 20).Select(s => s[new Random().Next(s.Length)]).ToArray())
                });
            }
            builder.Entity<User>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(e => e.Name).IsRequired(false).HasMaxLength(50);
                e.HasData(users);
            });
        }

        public DbSet<User> Users { get; set; }
    }
}