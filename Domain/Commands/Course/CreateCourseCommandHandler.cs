using LimKam.Domain.Mapper.Course;
using LimKam.Domain.Repositories;
using LimKam.Domain.Repositories.Course;
using LimKam.Domain.Resources.Course;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimKam.Domain.Commands.Course
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseResource>
    {

        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICourseMapper courseMapper;

        public CreateCourseCommandHandler(ICourseRepository _courseRepository, IUnitOfWork _unitOfWork, ICourseMapper _courseMapper)
        {
            unitOfWork = _unitOfWork;
            courseRepository = _courseRepository;
            courseMapper = _courseMapper;
        }

        public async Task<CourseResource> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseMaster = new LimKam.Domain.Models.Course
            {
                CourseName = request.CourseName,
                CourseCode = request.CourseCode,
                EntryUserId = request.EntryUserId,
                EntryDate = System.DateTime.Now,
                UpdateUserId = request.EntryUserId,
                UpdateDate = System.DateTime.Now
            };

            await courseRepository.AddAsync(courseMaster);
            await unitOfWork.CompleteAsync();

            return courseMapper.MapToCourseResource(  courseMaster);
        }
    }
}