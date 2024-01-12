using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IPresistence
{
    public interface IModuleRepository : IBaseRepository<ModuleDTO>
    {
        Task<ModuleDTO> GetModuleByIdAsync(int moduleId);
        Task<IEnumerable<ModuleDTO>> GetAllModulesAsync();
        Task CreateModuleAsync(ModuleDTO moduleEntity);
        Task<IEnumerable<CourseDTO>> GetCoursesByModuleIdAsync(int moduleId);
        Task UpdateModuleAsync(ModuleDTO moduleEntity);
        Task DeleteModuleAsync(ModuleDTO moduleEntity);
    }
}
