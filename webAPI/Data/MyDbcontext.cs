using Microsoft.EntityFrameworkCore;

namespace webAPI.Data
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions options): base(options) { }



        #region DbSet
        public DbSet<NuocHoa> NuocHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        #endregion
    }
}
