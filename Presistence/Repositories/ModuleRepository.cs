using Application.DTOs;
using Application.Interfaces.IPresistence;
using MongoDB.Driver;
using Presistence;
using Presistence.BaseRepositories;

public class ModuleRepository : BaseRepository<Module>, IModuleRepository
{
    private readonly IMongoCollection<Module> _collection;

    public ModuleRepository(BaseDBContext dbContext) : base(dbContext)
    {
        _collection = dbContext.Database.GetCollection<Module>(typeof(Module).Name);
    }

    public async Task<ModuleDTO> GetModuleByIdAsync(int moduleId)
    {
        var filter = Builders<Module>.Filter.Eq("Id", moduleId);
        var module = await _collection.Find(filter).FirstOrDefaultAsync();
        return MapToDTO(module);
    }

    public async Task<IEnumerable<ModuleDTO>> GetAllModulesAsync()
    {
        var modules = await _collection.Find(_ => true).ToListAsync();
        return modules.Select(MapToDTO);
    }

    public async Task AddModuleAsync(Module module)
    {
        await AddAsync(module);
    }

    public async Task UpdateModuleAsync(ModuleDTO module)
    {
        var filter = Builders<Module>.Filter.Eq("Id", module.ModuleId);
        var updatedModule = MapToEntity(module);
        await _collection.ReplaceOneAsync(filter, updatedModule);
    }

    public async Task DeleteModuleAsync(int moduleId)
    {
        var filter = Builders<Module>.Filter.Eq("Id", moduleId);
        await _collection.DeleteOneAsync(filter);
    }

    private object GetIdValue(Module module)
    {
        var property = typeof(Module).GetProperty("Id");
        return property?.GetValue(module);
    }

    private ModuleDTO MapToDTO(Module module)
    {
        // Implement the mapping logic from Module to ModuleDTO
        // Assuming ModuleDTO has similar properties to Module
        return new ModuleDTO
        {
            ModuleId = module.ModuleId,
            // Map other properties as needed
        };
    }

    private Module MapToEntity(ModuleDTO moduleDTO)
    {
        // Implement the mapping logic from ModuleDTO to Module
        // Assuming ModuleDTO has similar properties to Module
        return new Module
        {
            ModuleId = moduleDTO.ModuleId,
            // Map other properties as needed
        };
    }

    public Task CreateModuleAsync(ModuleDTO moduleDTO)
    {
        throw new NotImplementedException();
    }

    public Task UpdateModuleAsync(int moduleId, Module module)
    {
        throw new NotImplementedException();
    }
}
