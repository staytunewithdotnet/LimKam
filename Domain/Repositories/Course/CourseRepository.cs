namespace LimKam.Domain.Repositories.Course
{
    public class CourseRepository : Repository<LimKam.Domain.Models.Course>, ICourseRepository
    {
        public CourseRepository(LimKam.Domain.Models.AppDBContext context) : base(context)
        {
        }
    }
}