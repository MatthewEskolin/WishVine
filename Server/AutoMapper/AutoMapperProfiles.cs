using WishVine.Server.DomainData;
using WishVine.Shared;

namespace WishVine.Server.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<WishListItem, WishListItemDTO>().ReverseMap();
            CreateMap<WishList, WishListDTO>().ReverseMap();
        }
    }
}
