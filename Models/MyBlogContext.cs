using Microsoft.EntityFrameworkCore;

namespace TichHopEntityFramwork.Models
{
    public class MyBlogContext:DbContext
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
        }

        public DbSet<Article> articles { get; set; }
    }
}
