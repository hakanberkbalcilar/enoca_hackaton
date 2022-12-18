using AutoMapper;
using HackatonApi.Core.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.ProductOperations.Queries.GetProducts;

public class GetProductsQuery
{
    private IApplicationDbContext _context;
    private IMapper _mapper;


    public GetProductsQuery(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetProductsViewModel> Handle()
    {
        var productList = _context.Products.OrderBy(x => x.Name);

        var vm = _mapper.Map<List<GetProductsViewModel>>(productList);

        return vm;
    }
}