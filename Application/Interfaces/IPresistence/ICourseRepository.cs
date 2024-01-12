using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPresistence
{
    public interface ICourseRepository : IBaseRepository<CourseDTO>
    {
        Task<CourseDTO> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task CreateCourseAsync(CourseDTO courseEntity);
        Task<IEnumerable<ModuleDTO>> GetModulesByCourseIdAsync(int courseId);
        Task UpdateCourseAsync(CourseDTO courseEntity);
        Task DeleteCourseAsync(CourseDTO courseEntity);
    }
}
