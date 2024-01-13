using Application.DTOs.Mapping;
using Domain.Entities;

namespace Application.DTOs
{
    public class CourseDTO : Course, IMapFrom<Course>
    {
        public new int CourseId { get; set; }
        public new string? CourseName { get; set; }
        public new string? CourseDescription { get; set; }
        public new string? TeacherName { get; set; }
        public new DateTime StartDate { get; set; }
        public new DateTime EndDate { get; set; }
        public new int ModuleId { get; set; }


    }
}
