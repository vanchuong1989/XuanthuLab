using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//TichHopEntityFramwork.Models.MyBlogContext
namespace TichHopEntityFramwork.Models
{
    public class MyBlogContext:IdentityDbContext<AppUser>
    {
        public MyBlogContext( DbContextOptions options) : base(options)//=>gọi phương thưc khởi tạo cơ sở của DBContext
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Process to remove AspNet Prefix
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        public DbSet<Article> articles { get; set; }
    }
}
