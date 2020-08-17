using LimKam.Domain.Resources.Course;

namespace LimKam.Domain.Mapper.Course
{

    public interface ICourseMapper
    {
        CourseResource MapToCourseResource(Domain.Models.Course course);
    }

}

