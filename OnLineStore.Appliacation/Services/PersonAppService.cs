using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineStore.Application.Dtos;
using OnlineStore.Domain.Factories;
using OnLineStore.Domain.Aggregates;
using OnlineStore.Domain.Repositories;
using OnlineStore.Application.Abstracts;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineStore.Application.Services
{
    [ScopedService]
    public class PersonAppService : IPersonAppService
    {
        #region [- Fields -]
        private readonly IPersonRepository _personRepository;
        private readonly PersonFactoryService _personFactory;
        private readonly IMapper _mapper;
        #endregion

        #region [- ctor -]
        public PersonAppService(IPersonRepository personRepository, PersonFactoryService personFactory, IMapper mapper)
        {
            _personRepository = personRepository;
            _personFactory = personFactory;
            _mapper = mapper;
        }
        #endregion

        #region [- GetAsync(Guid id) -]
        public async Task<PersonDto> GetAsync(Guid id)
        {
            var person = await _personRepository.FindByIdAsync(id);
            return _mapper.Map<Dtos.PersonDto>(person);
        }
        #endregion

        #region [- GetListAsync() -]
        public async Task<List<PersonDto>> GetListAsync()
        {
            var persons = await _personRepository.Select();
            return _mapper.Map<List<PersonDto>>(persons);
        }
        #endregion

        #region [- CreateAsync(CreatePersonDto input) -]
        public async Task<PersonDto> CreateAsync(CreatePersonDto input)
        {
            var person = await _personFactory.CreateAsync(input.FirstName, input.LastName);
            await _personRepository.InsertAsync(person);
            return _mapper.Map<Person, PersonDto>(person);
        }
        #endregion

        #region [- UpdateAsync(Guid id, UpdatePersonDto input) -]
        public async Task UpdateAsync(Guid id, UpdatePersonDto input)
        {
            var person = await _personRepository.FindByIdAsync(id);
            if (person != null)
            {
                person.FirstName = input.FirstName;
                person.LastName = input.LastName;
                await _personRepository.UpdateAsync(person);
            }
        }
        #endregion

        #region [- DeleteAsync(Guid id) -]
        public async Task DeleteAsync(Guid id)
        {
            await _personRepository.DeleteAsync(id);
        }
        #endregion
    }
}