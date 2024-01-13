using Domain.Entities;
using Domain.Interface;

namespace Presistence.Repositories
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<Course> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<Course>> GetCoursesByModuleIdAsync(int moduleId);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);
    }
}