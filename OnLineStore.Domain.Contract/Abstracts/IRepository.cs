using System.Threading.Tasks;
using System.Collections.Generic;

namespace OnLineStore.Domain.Contract.Abstracts
{
    public interface IRepository<T_Entity, U_PrimaryKey> where T_Entity : class
    {
        Task InsertAsync(T_Entity entity);
        Task UpdateAsync(T_Entity entity);
        Task DeleteAsync(U_PrimaryKey id);
        Task DeleteAsync(T_Entity entity);
        Task<List<T_Entity>> Select();
        Task<T_Entity> FindByIdAsync(U_PrimaryKey id);
        Task SaveChanges();
    }
}