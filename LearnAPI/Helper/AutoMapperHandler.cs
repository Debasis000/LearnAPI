using AutoMapper;
using LearnAPI.Modal;
using LearnAPI.Repos.Models;

namespace LearnAPI.Helper
{
    public class AutoMapperHandler:Profile
    {
        public AutoMapperHandler() {
            CreateMap<TblCustomer, Customermodal>()
                .ForMember(dest => dest.Statusname,
               opt => opt.MapFrom(src => (src.IsActive ?? false) ? "Active" : "Inactive")).ReverseMap();

        }
    }
}
