using Microsoft.EntityFrameworkCore;
using pratices_angular_CURD.Model;

namespace pratices_angular_CURD.Data
{
    public class studentDbContext:DbContext
    {
        public studentDbContext(DbContextOptions<studentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }

}
