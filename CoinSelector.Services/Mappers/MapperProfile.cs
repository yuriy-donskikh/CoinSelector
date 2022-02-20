namespace CoinSelector.Services.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Entity.User, Model.User>()
            ;
        CreateMap<Entity.User, Model.UserInfo>()
            ;
        CreateMap<Entity.Price, Model.Price>()
            ;
        CreateMap<Model.User, Entity.User>()
            ;
        CreateMap<Model.Price, Entity.Price>()
            .ForMember(dst => dst.UserId, opt => opt.Ignore())
            ;
        CreateMap<Model.User, Model.UserInfo>()
            ;
    }
}
