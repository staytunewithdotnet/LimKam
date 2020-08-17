using MediatR;
using System;

namespace LimKam.Domain.Commands.Course
{
    public class CreateCourseCommand : IRequest<LimKam.Domain.Models.Course>
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int? EntryUserId { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public CreateCourseCommand(int courseId, string courseName, string courseCode, int? entryUserId, DateTime? entryDate, int? updateUserId, DateTime? updateDate)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
            EntryUserId = entryUserId;
            EntryDate = entryDate;
            UpdateUserId = updateUserId;
            UpdateDate = updateDate;
        }
    }
}