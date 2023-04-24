using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Domain.Contract.Abstracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineStore.EntityFrameworkCore.Frameworks.Base
{
    public class BaseRepository<K_DbContext, T_Entity, U_PrimaryKey> : IRepository<T_Entity, U_PrimaryKey>
                                                                          where T_Entity : class
                                                                          where K_DbContext : IdentityDbContext<IdentityUser>
    {
        #region [- ctor -]
        public BaseRepository(K_DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T_Entity>();
        }
        #endregion

        #region [- props -]
        public virtual K_DbContext DbContext { get; set; }
        public virtual DbSet<T_Entity> DbSet { get; set; }
        #endregion

        #region [- InsertAsync(T_Entity entity) -]
        public virtual async Task InsertAsync(T_Entity entity)
        {
            using (DbContext)
            {
                DbSet.Add(entity);
                await SaveChanges();
            }
        }
        #endregion

        #region [- UpdateAsync(T_Entity entity) -]
        public virtual async Task UpdateAsync(T_Entity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        #endregion

        #region [- DeleteAsync(U_PrimaryKey id) -]
        public virtual async Task DeleteAsync(U_PrimaryKey id)
        {
            var entityToDelete = DbSet.Find(id);
            DbSet.Remove(entityToDelete);
            await SaveChanges();
        }
        #endregion

        #region [- DeleteAsync(T_Entity entityToDelete) -]
        public virtual async Task DeleteAsync(T_Entity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            await SaveChanges();
        }
        #endregion

        #region [- Select() -]
        public virtual async Task<List<T_Entity>> Select()
        {
            var q = DbSet.AsNoTracking().ToListAsync();
            return await q;
        }
        #endregion

        #region [- FindByIdAsync(U_PrimaryKey id) -]
        public virtual async Task<T_Entity> FindByIdAsync(U_PrimaryKey id)
        {
            var q = DbSet.FindAsync(id);
            return await q;
        }
        #endregion

        #region [- SaveChanges() -]
        public async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }
        #endregion
    }
}