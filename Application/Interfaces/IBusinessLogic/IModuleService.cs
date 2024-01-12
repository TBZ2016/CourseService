using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IBusinessLogic
{
    public interface IModuleService
    {
        Task<ModuleDTO> GetModuleByIdAsync(int moduleId);
        Task<IEnumerable<ModuleDTO>> GetAllModulesAsync();
        Task CreateModuleAsync(ModuleDTO moduleDto);
        Task<IEnumerable<CourseDTO>> GetCoursesByModuleIdAsync(int moduleId);
        Task UpdateModuleAsync(int moduleId, ModuleDTO moduleDto);
        Task DeleteModuleAsync(int moduleId);
        Task<IEnumerable<GroupDTO>> GetGroupsByModuleIdAsync(int moduleId);
        Task AssignGroupToModuleAsync(int moduleId, GroupDTO groupDto);
    }
}
