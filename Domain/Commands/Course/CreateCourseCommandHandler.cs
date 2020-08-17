using LimKam.Domain.Repositories;
using LimKam.Domain.Repositories.Course;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LimKam.Domain.Commands.Course
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Models.Course>
    {

        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateCourseCommandHandler(ICourseRepository _courseRepository, IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            courseRepository = _courseRepository;
        }

        public async Task<LimKam.Domain.Models.Course> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var courseMaster = new LimKam.Domain.Models.Course
            {
                CourseId = request.CourseId,
                CourseName = request.CourseName,
                CourseCode = request.CourseCode,
                EntryUserId = request.EntryUserId,
                EntryDate = request.EntryDate,
                UpdateUserId = request.UpdateUserId,
                UpdateDate = request.UpdateDate
            };

            await courseRepository.AddAsync(courseMaster);
            await unitOfWork.CompleteAsync();

            return courseMaster;
        }
    }
}