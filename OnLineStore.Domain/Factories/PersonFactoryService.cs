using System.Threading.Tasks;
using OnLineStore.Domain.Aggregates;
using OnlineStore.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineStore.Domain.Factories
{
    [ScopedService]
    public class PersonFactoryService
    {
        private readonly IPersonRepository _personRepository;

        #region [- ctor -]
        public PersonFactoryService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region [- CreateAsync() -]
        public async Task<Person> CreateAsync(string firstName, string lastName)
        {
            var existingPerson = await _personRepository.FindByNameAsync(firstName);
            if (existingPerson == null)
            {
                return new Person(firstName, lastName);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}