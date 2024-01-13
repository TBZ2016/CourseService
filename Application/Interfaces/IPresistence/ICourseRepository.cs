using Domain.Entities;

namespace Application.Interfaces.IPresistence
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<Course>> GetCoursesByModuleIdAsync(int moduleId);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);

    }
}

