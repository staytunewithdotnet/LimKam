using AutoMapper;
using LimKam.Domain.Resources.Course;

namespace LimKam.Domain.Mapper.Course
{
    public class CourseMapper : ICourseMapper
    {
        private readonly IMapper _mapper;
        public CourseMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Models.Course, CourseResource>()
                        .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dst => dst.CourseId, opt => opt.MapFrom(src => src.CourseId))
                        .ForMember(dst => dst.CourseName, opt => opt.MapFrom(src => src.CourseName))
                        .ForMember(dst => dst.CourseCode, opt => opt.MapFrom(src => src.CourseCode))
                        .ForMember(dst => dst.EntryUserId, opt => opt.MapFrom(src => src.EntryUserId))
                        .ForMember(dst => dst.UpdateUserId, opt => opt.MapFrom(src => src.UpdateUserId))
                        .ForMember(dst => dst.UpdateDate, opt => opt.MapFrom(src => src.UpdateDate));
                //.ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
                //.ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                //.ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email));
            });

            _mapper = config.CreateMapper();
        }

        public CourseResource MapToCourseResource(LimKam.Domain.Models.Course course)
        {
            return _mapper.Map<LimKam.Domain.Models.Course, CourseResource>(course);
        }
    }
}

