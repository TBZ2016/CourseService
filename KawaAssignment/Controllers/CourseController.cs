using Application.BusinessLogic.ValidationHelper;
using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Security.Claims;

namespace KawaAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        #region POST

        [HttpPost(Name = "courses")]
        public async Task<ActionResult> CreateCourse([FromBody] CourseDTO courseInfo)
        {
            try
            {
                if (courseInfo != null)
                {
                    // Logic to handle the creation of a new course using courseInfo
                    // Example implementation:
                    await _courseService.CreateCourseAsync(courseInfo);
                    // Return a response indicating success
                    return StatusCode(201, "Course created");
                }
                else
                {
                    // Handle invalid input or missing data
                    return BadRequest("Invalid input or missing data");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        #endregion

        #region GET

        [HttpGet(Name = "courses")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCoursesAsync();

                if (courses.Any())
                {
                    return Ok(courses);
                }
                else
                {
                    return NotFound("No courses found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("{courseId}", Name = "getCourseById")]
        public async Task<ActionResult<CourseDTO>> GetCourseById(int courseId)
        {
            try
            {
                var course = await _courseService.GetCourseByIdAsync(courseId);

                if (course != null)
                {
                    return Ok(course);
                }
                else
                {
                    return NotFound("Course not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        #endregion

        #region PUT

        [HttpPut("{courseId}", Name = "updateCourse")]
        public async Task<ActionResult> UpdateCourse(int courseId, [FromBody] CourseDTO updatedCourseInfo)
        {
            try
            {
                if (updatedCourseInfo != null)
                {

                    await _courseService.UpdateCourseAsync(courseId, updatedCourseInfo);

                    return Ok("Course updated");
                }
                else
                {
                    // Handle invalid input or missing data
                    return BadRequest("Invalid input or missing data");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("{courseId}", Name = "deleteCourse")]
        public async Task<ActionResult> DeleteCourse(int courseId)
        {
            try
            {
                await _courseService.DeleteCourseAsync(courseId);


                return Ok("Course deleted");

            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }

        #endregion
    }
}