using LimKam.Domain.Resources.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    }
}
