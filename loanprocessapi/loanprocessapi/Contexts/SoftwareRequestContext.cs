using loanprocessapi.Models;
using Microsoft.EntityFrameworkCore;

namespace loanprocessapi.Contexts
{
    public class SoftwareRequestContext:DbContext
    {
        public SoftwareRequestContext(DbContextOptions<SoftwareRequestContext> options)
          : base(options)
        {

            this.Database.EnsureCreated();
        }

        public DbSet<SoftwareRequest> swrequests { get; set; }
    }
}
