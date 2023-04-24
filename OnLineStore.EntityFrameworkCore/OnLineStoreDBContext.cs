using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineStore.EntityFrameworkCore
{
    public class OnlineStoreDbContext : IdentityDbContext<IdentityUser>
    {
        #region [- ctor -]
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> contextOptions)
            : base(contextOptions)
        {

        }
        #endregion

        #region [- DbSets -]
        public DbSet<OnLineStore.Domain.Aggregates.Person> Person { get; set; }
        #endregion

        #region [- OnModelCreating(ModelBuilder modelBuilder) -]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}