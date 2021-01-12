using HR_Helpdesk.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_Helpdesk.DBContexts
{
    public class HR_HelpdeskDbContext : DbContext
    {
        public HR_HelpdeskDbContext(DbContextOptions<HR_HelpdeskDbContext> options)
            : base(options)
        {
        }

        public DbSet<HR_HelpdeskModel> HR_Helpdesk { get; set; }
    }
}