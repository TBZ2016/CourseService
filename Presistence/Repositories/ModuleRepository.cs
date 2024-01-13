using Domain.Entities;
using MongoDB.Driver;
using Presistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class ModuleRepository : BaseRepositories.BaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Module> GetModuleByIdAsync(int moduleId)
        {
            return await _dbSet.FindAsync(moduleId);
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddModuleAsync(Module module)
        {
            await AddAsync(module);
        }

        public async Task UpdateModuleAsync(Module module)
        {
            await UpdateAsync(module);
        }

        public async Task DeleteModuleAsync(int moduleId)
        {
            var module = await GetModuleByIdAsync(moduleId);
            if (module != null)
            {
                await DeleteAsync(module);
            }
        }
    }
}
