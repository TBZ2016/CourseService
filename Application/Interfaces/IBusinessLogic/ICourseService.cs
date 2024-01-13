using Application.DTOs;

namespace Application.Interfaces.IBusinessLogic
{
    public interface ICourseService
    {
        //Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseDTO>> GetCoursesByModuleIdAsync(int moduleId);
        Task CreateCourseAsync(CourseDTO courseDTO);
        Task UpdateCourseAsync(int courseId, CourseDTO courseDTO);
        Task DeleteCourseAsync(int courseId);
    }
}
