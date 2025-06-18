using AutoMapper;
using DataAccess.DTO.CartItemDTOs;
using DataAccess.Entities;

namespace BusinessLogic.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, GetCartItemDTO>().ReverseMap();
            CreateMap<CartItem, AddCartItemDTO>().ReverseMap();
            CreateMap<CartItem, UpdateCartItemDTO>().ReverseMap();
        }
    }
}
