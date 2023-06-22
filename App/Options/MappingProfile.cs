using AntDesign;
using AutoMapper;
using DataProvider.Entities;
using VendingMachine.Models;

namespace VendingMachine.Options
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdminItemViewModel, AdminItemViewModel>();

            CreateMap<AdminItemViewModel, CatalogBrand>()
                .ForMember(d => d.CatalogItems, _ => _.MapFrom(s => new List<CatalogItem>(new CatalogItem[s.Count])));

            CreateMap<CatalogBrand, AdminItemViewModel>()
                .ForMember(d => d.Count, _ => _.MapFrom(s => s.CatalogItems.Count()));

            CreateMap<CatalogItemViewModel, CatalogItem>();

            CreateMap<CatalogItem, CatalogItemViewModel>();

            CreateMap<CoinType, CoinTypeViewModel>();

            CreateMap<CoinTypeViewModel, CoinType>();
        }
    }
}
