using AutoMapper;
using DataAccess.DTO.ChatDTOs;
using DataAccess.DTO.UserDTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<ChatMessage, ChatMessageDTO>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User!.Username))
                .ForMember(d => d.ChatBoxId, o => o.MapFrom(s => s.ChatBoxId));
        }
    }
}
