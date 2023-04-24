using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Domain.Aggregates;

namespace OnlineStore.EntityFrameworkCore.Services
{
    public class PersonRepository :
        Frameworks.Base.BaseRepository<OnlineStoreDbContext, Person, Guid>,
        Domain.Repositories.IPersonRepository
    {
        #region [- ctor -]
        public PersonRepository(OnlineStoreDbContext dbContext) : base(dbContext)
        {

        }
        #endregion

        #region [- FindByNameAsync(string name) -]
        public async Task<Person> FindByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.FirstName == name);
        }
        #endregion
    }
}