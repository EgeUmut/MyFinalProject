using AutoMapper;
using Entities.Concrete;
using Entities.WiewModel.Entities.WiewModel;

namespace DataAccess.AutoMapper
{
      public class SubProductProfile : Profile
    {
        public SubProductProfile()
        {
            CreateMap<SubProduct, SubProductViewModel>()
                .ForMember(p => p.ProductName, o => o.MapFrom(s => s.Name));

        }
    }
}
