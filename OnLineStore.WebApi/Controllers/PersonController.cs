using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using OnlineStore.Application.Dtos;
using OnlineStore.Application.Abstracts;

namespace OnLineStore.WebApi.Controllers
{

    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonAppService _personAppService;

        #region [- ctor -]
        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }
        #endregion

        #region [- GetPersonAsync() -]
        [Route("wapi/v1/1")]
        public async Task<PersonDto> GetPersonAsync(Guid id)
        {
            return await _personAppService.GetAsync(id);
        }
        #endregion

        #region [- GetPersonListAsync -]
        [Route("wapi/v1/2")]
        public async Task<List<PersonDto>> GetPersonListAsync()
        {
            return await _personAppService.GetListAsync();
        }
        #endregion

        #region [- CreatePersonAsync -]
        [Route("wapi/v1/3")]
        [HttpPost]
        public async Task<PersonDto> CreatePersonAsync(CreatePersonDto input)
        {
            return await _personAppService.CreateAsync(input);
        }
        #endregion

        #region [- UpdatePersonAsync -]
        [Route("wapi/v1/4")]
        [HttpPut]
        public async Task UpdatePersonAsync(Guid id, UpdatePersonDto input)
        {
            await _personAppService.UpdateAsync(id, input);
        }
        #endregion

        #region [- DeletePersonAsync -]
        [Route("wapi/v1/5")]
        [HttpDelete]
        public async Task DeletePersonAsync(Guid id)
        {
            await _personAppService.DeleteAsync(id);
        }
        #endregion
    }
}