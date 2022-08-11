using AutoMapper;
using WepApiKhoiPhi.Dtos;
using WepApiKhoiPhi.Dtos.UserDtos;
using WepApiKhoiPhi.Models;

namespace WepApiKhoiPhi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // bookupsertrequest to book
                config.CreateMap<BookUpSertRequest, Book>().ReverseMap();
                // mapping user
                config.CreateMap<User, AuthenticateResponse>();
                config.CreateMap<RegisterRequest, User>();
                config.CreateMap<UpdateRequest, User>()
                    .ForAllMembers(x => x.Condition(
                        (src, dest, prop) =>
                        {
                            // ignore null & empty string properties
                            if (prop == null) return false;
                            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                            return true;
                        }
                    ));
            });
            return mappingConfig;
        }
            
    }
}