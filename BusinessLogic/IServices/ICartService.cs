using DataAccess.DTO.CartDTOs;
using DataAccess.PaginatedList;

namespace BusinessLogic.IServices
{
    public interface ICartService
    {
        Task<PaginatedList<GetCartDTO>> GetPaginatedCartsAsync(int pageIndex, int pageSize, int? idSearch, int? userIdSearch, string? statusSearch);
        Task<GetCartDTO> GetCartById(int id);
        Task CreateCart(AddCartDTO cartDTO);
        Task UpdateCart(int id, UpdateCartDTO cartDTO);
        Task DeleteCart(int id);
        Task SoftDeleteCart(int id);


    }
}
