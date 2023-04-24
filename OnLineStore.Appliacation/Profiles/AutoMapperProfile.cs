using AutoMapper;
using OnLineStore.Domain.Aggregates;

namespace OnlineStore.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        #region [- ctor -]
        public AutoMapperProfile()
        {
            #region [- PersonFlow(Schema) -]
            CreateMap<Person, Dtos.PersonDto>().ReverseMap();
            #endregion
        }
        #endregion
    }
}