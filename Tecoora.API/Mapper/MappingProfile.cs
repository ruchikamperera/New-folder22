using AutoMapper;
using Tecoora.API.Models;
using Tecoora.Models;

namespace Tecoora.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserRequestDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<Company, CompanyDto>();
            CreateMap<StudentPointForm, StudentPointFormDto>();
            CreateMap<StudentPointFormDto, StudentPointForm>();
            CreateMap<AppointmentDto, Appointment>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentRequestDto, Appointment>();
            CreateMap<TimeSlotDto, TimeSlot>();
            CreateMap<TimeSlot,TimeSlotDto>();
            CreateMap<Criteria, CriteriaDto>();
            CreateMap<CriteriaDto, Criteria>();
            CreateMap<EmailDto, Email>().ReverseMap();
            CreateMap<LawyerRequestedFile, LawyerRequestedFileDto>().ReverseMap();
            CreateMap<LawyerRequestedFile, FileRequestDto>().ReverseMap();
            CreateMap<UserFileDetail, FileRequestDto>().ReverseMap();
            CreateMap<UserFileDetail, UserFileDetailDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();

        }
    }
}
