using AutoMapper;
using Route._3TiersArchitecture.DAL.Models_Services_;
using Route._3TiersArchitecture.PL.Models;

namespace Route._3TiersArchitecture.PL.Helppers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();

        }
    }
}
