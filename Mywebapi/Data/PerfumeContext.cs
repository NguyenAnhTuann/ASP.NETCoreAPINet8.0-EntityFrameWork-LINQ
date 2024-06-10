using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace Mywebapi.Data
{
    public class PerfumeContext : DbContext
    {
        public PerfumeContext(DbContextOptions<PerfumeContext> otp): base (otp)
        {

        }

        #region DbSet
        public DbSet<Perfume>? SANPHAMs { get; set; }
        #endregion 

    }
}
