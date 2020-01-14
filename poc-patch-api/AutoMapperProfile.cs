using AutoMapper;
using poc_patch_api.Models;
using poc_patch_api.Persistence.Entities;

namespace poc_patch_api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ConnectionStringModel, ConnectionString>().ReverseMap();
            CreateMap<PatchRequestModel, SampleEntity>().ReverseMap();
        }
    }
}
