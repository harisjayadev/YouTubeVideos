using AutoMapper;
using FrameworkVsLibrary.Models;

namespace FrameworkVsLibrary.ViewModel
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerType { get; set; }
        public string Address { get; set; }
    }

    public class CustomerDetailProfile : Profile
    {
        public CustomerDetailProfile()
        {
            CreateMap<Customer, CustomerDetail>()
                .ForMember(vm => vm.Id, m => m.MapFrom(x => x.Id))
                .ForMember(vm => vm.Name, m => m.MapFrom(x => x.Name))
                .ForMember(vm => vm.CustomerType, m => m.MapFrom(x => x.CusomterType.ToString()))
                //.ForMember(vm => vm.Address, m => m.Ignore())
                .AfterMap((src, dest, context) => context.Mapper.Map(src.Address, dest));


            CreateMap<Address, CustomerDetail>()
                .ForMember(vm => vm.Address, m => m.MapFrom(x => string.Concat(x.AddressLine1, x.AddressLine2, x.City, x.State)));
        }
    }

}
