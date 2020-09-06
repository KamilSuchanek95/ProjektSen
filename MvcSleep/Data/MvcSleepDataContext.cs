using Microsoft.EntityFrameworkCore;
using MvcSleep.Models;
using MvcSleep.Data;

namespace MvcSleep.Data
{
    public class MvcSleepDataContext : DbContext
    {
        public MvcSleepDataContext (DbContextOptions<MvcSleepDataContext> options)
         : base(options)
        {
        }

        public DbSet<SleepDataModel> SleepData { get; set; }
    }
}