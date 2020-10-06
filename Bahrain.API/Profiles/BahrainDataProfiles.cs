using AutoMapper;
using Bahrain.API.Models;
using Bahrain.API.DTOs;

namespace Bahrain.API.Profiles
{

    public class BahrainDataProfiles : Profile
    {

        public BahrainDataProfiles()
        {
            
            // Source -> target

            // ATControllers
            //GETTING
            CreateMap<ATController, ATControllerReadDTO>();

            //POSTING
            CreateMap<ATControllerCreateDTO, ATController>();

            // PUTTING
            CreateMap<ATControllerUpdateDTO, ATController>();

            //PATCHING
            CreateMap<ATController, ATControllerUpdateDTO>();
            
            // Staff
            // GETTING
            CreateMap<StaffMember, StaffReadDto>();
            CreateMap<StaffMember, StaffReadAdminDto>();

        }

    }

}