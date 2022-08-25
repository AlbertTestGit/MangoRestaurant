using AutoMapper;
using Mango.Services.ShoppingCartAPI.DbContexts;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Repository;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CartRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CartDto> GetCartByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CartDto> CreateUpdateCart(CartDto cartDto)
    {
        Cart cart = _mapper.Map<Cart>(cartDto);

        var prodInDb =
            await _dbContext.Products.FirstOrDefaultAsync(u =>
                u.ProductId == cartDto.CartDetails.FirstOrDefault().ProductId);

        if (prodInDb == null)
        {
            _dbContext.Products.Add(cart.CartDetails.FirstOrDefault().Product);
            await _dbContext.SaveChangesAsync();
        }

        var cartHeaderFromDb = _dbContext.CartHeaders.FirstOrDefaultAsync(u =>
            u.UserId == cart.CartHeader.UserId);

        if (cartHeaderFromDb == null)
        {
            _dbContext.CartHeaders.Add(cart.CartHeader);
            await _dbContext.SaveChangesAsync();

            cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.CartHeaderId;
            cart.CartDetails.FirstOrDefault().Product = null;

            _dbContext.CartDetails.Add(cart.CartDetails.FirstOrDefault());

            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<bool> RemoveFromCart(int cartDetailsId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ClearCart(string userId)
    {
        throw new NotImplementedException();
    }
}