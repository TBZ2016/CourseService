using Application.DTOs;

namespace Application.Interfaces.IBusinessLogic
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleDTO>> GetAllModulesAsync();
        Task<ModuleDTO> GetModuleByIdAsync(int moduleId);
        Task CreateModuleAsync(ModuleDTO moduleDTO);
        Task UpdateModuleAsync(int moduleId, ModuleDTO moduleDTO);
        Task DeleteModuleAsync(int moduleId);
    }
}
