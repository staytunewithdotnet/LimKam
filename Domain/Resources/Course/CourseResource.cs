using System;
using System.ComponentModel.DataAnnotations;

namespace LimKam.Domain.Resources.Course
{
    public class CourseResource
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int? EntryUserId { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}