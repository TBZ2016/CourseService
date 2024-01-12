using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public interface IModuleRepository
    {
        Task<ModuleDTO> GetModuleByIdAsync(int moduleId);
        Task<IEnumerable<ModuleDTO>> GetAllModulesAsync();
        Task CreateModuleAsync(ModuleDTO moduleEntity);
        Task<IEnumerable<CourseDTO>> GetCoursesByModuleIdAsync(int moduleId);
        Task UpdateModuleAsync(ModuleDTO moduleEntity);
        Task DeleteModuleAsync(ModuleDTO moduleEntity);
    }
}
