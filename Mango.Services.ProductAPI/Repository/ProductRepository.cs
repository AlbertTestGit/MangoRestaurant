using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        List<Product> productList = await _dbContext.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }

    public async Task<ProductDto> GetProductById(int productId)
    {
        Product product = await _dbContext.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }
}