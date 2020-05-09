using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingApp.Api.Models;
using TrainingApp.BLL.DTO;
using TrainingApp.DAL.Models;

namespace TrainingApp.Api.Util
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Sensor, SensorDTO>().ReverseMap();

            CreateMap<Training, TrainingDTO>().ReverseMap();

            CreateMap<Exercise, ExerciseDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<Kick, KickDTO>().ReverseMap();

            CreateMap<UserDTO, UserModel>().ReverseMap();

        }
    }
}
