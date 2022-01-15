
using AutoMapper;
using OrstedBusiness.Models;
using OrstedData.Entities;

namespace OrstedRestAPI.Configuration
{
    /// <summary>
    /// Auto mapper, mappings
    /// </summary>
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<EmployeeModel, Employee>().ReverseMap();
        }
    }
}