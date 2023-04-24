using System;
using System.Threading.Tasks;
using OnLineStore.Domain.Aggregates;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineStore.Domain.Repositories
{
    [ScopedService]
    public interface IPersonRepository : OnLineStore.Domain.Contract.Abstracts.IRepository<Person, Guid>
    {
        // Other behaviors(tasks) that would be create for person entity and not exists in IRepository
        Task<Person> FindByNameAsync(string name);
    }
}