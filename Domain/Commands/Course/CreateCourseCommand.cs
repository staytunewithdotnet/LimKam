using LimKam.Domain.Resources.Course;
using MediatR;
using System;

namespace LimKam.Domain.Commands.Course
{
    public class CreateCourseCommand : IRequest<CourseResource>
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int EntryUserId { get; set; }   

        public CreateCourseCommand( string courseName, string courseCode, int entryUserId)
        {
            CourseName = courseName;
            CourseCode = courseCode;
            EntryUserId = entryUserId;
        }
    }
}