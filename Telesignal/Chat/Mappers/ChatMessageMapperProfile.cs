using AutoMapper;
using DatabaseModel = Telesignal.Common.Database.EntityFramework.Model;

namespace Telesignal.Chat.Mappers;

public class ChatMessageMapperProfile : Profile
{
//    public ChatMessageMapperProfile() {
//        CreateMap<MessageWrapper, DatabaseModel.Message>()
//           .ForMember(dest => dest.Content,
//                      opt => opt.MapFrom(src => src.MessageContent.Value))
//           .ForMember(dest => dest.KeyMapJson,
//                      opt => opt.MapFrom(src => JsonSerializer.Serialize(src.MessageContent.KeyMap));
//    }
}
