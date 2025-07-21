using BusinessLogic.IServices;
using DataAccess.Constant;
using DataAccess.DTO.LocationDTOs;
using DataAccess.Entities;
using DataAccess.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Product_Sale_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreLocationController : ControllerBase
    {
        private readonly IStoreLocationService _storeLocationService;

        public StoreLocationController(IStoreLocationService storeLocationService)
        {
            _storeLocationService = storeLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var locations = await _storeLocationService.GetAllAsync();
            return Ok(new BaseResponseModel<IEnumerable<StoreLocation>>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS,
                data: locations,
                message: "Fetched store locations successfully."
            ));
        }
    }
}
