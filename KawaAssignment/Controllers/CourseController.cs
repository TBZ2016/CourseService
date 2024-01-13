using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace KawaAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CourseDTO>>> GetAllCourses()
        //{
        //    var courses = await _courseService.GetAllCoursesAsync();
        //    return Ok(courses);
        //}

        [HttpGet("{courseId}")]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int courseId)
        {
            var course = await _courseService.GetCourseByIdAsync(courseId);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpGet("module/{moduleId}")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesByModuleId(int moduleId)
        {
            var courses = await _courseService.GetCoursesByModuleIdAsync(moduleId);
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO courseDTO)
        {
            await _courseService.CreateCourseAsync(courseDTO);
            return CreatedAtAction(nameof(GetCourseById), new { courseId = courseDTO.CourseId }, courseDTO);
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] CourseDTO courseDTO)
        {
            await _courseService.UpdateCourseAsync(courseId, courseDTO);
            return NoContent();
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            await _courseService.DeleteCourseAsync(courseId);
            return NoContent();
        }
    }
}