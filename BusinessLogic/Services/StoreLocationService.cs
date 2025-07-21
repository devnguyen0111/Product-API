using AutoMapper;
using BusinessLogic.IServices;
using DataAccess.Constant;
using DataAccess.DTO.LocationDTOs;
using DataAccess.Entities;
using DataAccess.CustomException;
using DataAccess.IRepositories;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services
{
    public class StoreLocationService : IStoreLocationService
    {
        private readonly IUOW _unitOfWork;
        private readonly IMapper _mapper;

        public StoreLocationService(IUOW unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoreLocation>> GetAllAsync()
        {
            var repo = _unitOfWork.GetRepository<StoreLocation>();
            var locations = repo.Entities;  

            if (!locations.Any())
            {
                throw new ErrorException(
                    StatusCodes.Status404NotFound,
                    ResponseCodeConstants.NOT_FOUND,
                    "No store locations found.");
            }

            return await Task.FromResult(locations);
        }
    }
}
