using Domain.Entities;

namespace Presistence.Repositories
{
    public interface ICourseRepository
    {
        Task<CourseDTO> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task CreateCourseAsync(CourseDTO courseEntity);
        Task<IEnumerable<ModuleDTO>> GetModulesByCourseIdAsync(int courseId);
        Task UpdateCourseAsync(CourseDTO courseEntity);
        Task DeleteCourseAsync(CourseDTO courseEntity);
    }
}