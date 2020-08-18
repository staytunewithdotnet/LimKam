using LimKam.Domain.Commands.Course;
using LimKam.Domain.Resources;
using LimKam.Domain.Resources.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LimKam.Web.Controllers
{
    
    public class CourseController : Controller
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }





        public IActionResult Create(CourseResource courseMasterResource)
        {
            return View(courseMasterResource);
        }

        #region API Requests
        /// <summary>
        /// Creates a new user in the API.
        /// </summary>
        /// <param name="resource">Updated user data.</param>
        /// <returns>Response for the request.</returns>
        /// <response code="201">Returns the newly created user data.</response>
        /// <response code="400">Return data containing information about why has the request failed.</response>
        [Route("api/courses")]
        [Produces("application/json")]
        [HttpPost]
        [ProducesResponseType(typeof(CourseResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] CourseResource resource)
        {
            var course = await _mediator.Send(new CreateCourseCommand(resource.CourseName,resource.CourseName,1));
            return Created($"/api/courses/{course.Id}", course);
        }
        #endregion



    }
}
