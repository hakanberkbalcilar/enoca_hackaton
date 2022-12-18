using AutoMapper;
using HackatonApi.Core.Extensions;
using HackatonApi.Domain.Entities;
using HackatonApi.Features.CompanyOperations.Commands.CreateCompany;
using HackatonApi.Features.CompanyOperations.Queries.GetCompanies;
using HackatonApi.Features.OrderOperations.Commands.CreateOrder;
using HackatonApi.Features.ProductOperations.Commands.CreateProduct;
using HackatonApi.Features.ProductOperations.Queries.GetProducts;
using HackatonApi.Features.UserOperations.Commands.CreateUser;

namespace HackatonApi.Core.Common;

public class MappingProfile : Profile{

    public MappingProfile(){
        // Company
        CreateMap<CreateCompanyModel, Company>()
            .ForMember(x => x.OrderStart, opt => opt
                .MapFrom(src => src.OrderStart.ToTimeSpan()))
            .ForMember(x => x.OrderEnd, opt => opt
                .MapFrom(src => src.OrderEnd.ToTimeSpan()));
        
        CreateMap<Company, GetCompaniesViewModel>()
            .ForMember(x => x.OrderStart, opt => opt
                .MapFrom(src => src.OrderStart.ToTime()))
            .ForMember(x => x.OrderEnd, opt => opt
                .MapFrom(src => src.OrderEnd.ToTime()));


        // Product
        CreateMap<CreateProductModel, Product>();
        
        CreateMap<Product, GetProductsViewModel>();

        // Order
        CreateMap<CreateOrderModel, Order>();

        // User
        CreateMap<CreateUserModel, User>();
    }

}