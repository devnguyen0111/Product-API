using AutoMapper;
using DataAccess.DTO.CartDTOs;
using DataAccess.DTO.CartItemDTOs;
using DataAccess.Entities;

namespace BusinessLogic.MappingProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Cart, GetCartDTO>().ReverseMap();
            CreateMap<CartItem, GetCartItemDTO>();
            CreateMap<Cart, AddCartDTO>().ReverseMap();
            CreateMap<Cart, UpdateCartDTO>().ReverseMap();
        }

    }
}
