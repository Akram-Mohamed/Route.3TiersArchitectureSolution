using AutoMapper;
using Route._3TiersArchitecture.DAL.Models_Services_;
using Route._3TiersArchitecture.PL.Models;

namespace Route._3TiersArchitecture.PL.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            //CreateMap<EmployeeViewModel, Employee>()
            //.ForMember(d => d.Name, o => o.MapFrom(s => s.EmpName));

            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<EmployeeResponseViewModel, Employee>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();

        }


    }
}
