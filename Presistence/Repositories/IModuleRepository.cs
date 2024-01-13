using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public interface IModuleRepository : IBaseRepository<Module>
    {
        Task<Module> GetModuleByIdAsync(int moduleId);
        Task<IEnumerable<Module>> GetAllModulesAsync();
        Task AddModuleAsync(Module module);
        Task UpdateModuleAsync(Module module);
        Task DeleteModuleAsync(int moduleId);
    }
}
