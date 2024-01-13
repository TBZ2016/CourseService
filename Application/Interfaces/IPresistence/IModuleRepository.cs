using Application.DTOs;

namespace Application.Interfaces.IPresistence
{
    public interface IModuleRepository
    {
        Task<IEnumerable<ModuleDTO>> GetAllModulesAsync();
        Task<ModuleDTO> GetModuleByIdAsync(int moduleId);
        Task CreateModuleAsync(ModuleDTO moduleDTO);
        Task UpdateModuleAsync(int moduleId, Module module);
        Task DeleteModuleAsync(int moduleId);
        Task AddModuleAsync(Module module);
    }
}
