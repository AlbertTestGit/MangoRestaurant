using Mango.Services.CouponAPI.Models.Dto;
using Mango.Services.CouponAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers;

[ApiController]
[Route("api/coupon")]
public class CouponAPIController : ControllerBase
{
    private readonly ICouponRepository _couponRepository;
    protected ResponseDto _response;

    public CouponAPIController(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
        _response = new ResponseDto();
    }
    
    [HttpGet("{code}")]
    public async Task<object> GetDiscountForCode(string code)
    {
        try
        {
            var coupon = await _couponRepository.GetCouponByCode(code);
            _response.Result = coupon;
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.ToString() };
        }

        return _response;
    }
}