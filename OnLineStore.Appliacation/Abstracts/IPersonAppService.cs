using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineStore.Application.Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineStore.Application.Abstracts
{
    [ScopedService]
    public interface IPersonAppService
    {
        Task<PersonDto> GetAsync(Guid id);

        Task<List<PersonDto>> GetListAsync();

        Task<PersonDto> CreateAsync(CreatePersonDto input);

        Task UpdateAsync(Guid id, UpdatePersonDto input);

        Task DeleteAsync(Guid id);
    }
}