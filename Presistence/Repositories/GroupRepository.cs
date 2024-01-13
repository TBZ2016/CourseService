using Application.DTOs;
using Application.Interfaces.IPresistence;
using Domain.Entities;
using MongoDB.Driver;
using Presistence;
using Presistence.BaseRepositories;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    private readonly IMongoCollection<Group> _collection;

    public GroupRepository(BaseDBContext dbContext) : base(dbContext)
    {
        _collection = dbContext.Database.GetCollection<Group>(typeof(Group).Name);
    }

    public async Task<GroupDTO> GetGroupByIdAsync(int groupId)
    {
        var filter = Builders<Group>.Filter.Eq("Id", groupId);
        var group = await _collection.Find(filter).FirstOrDefaultAsync();
        return MapToDTO(group);
    }

    public async Task<IEnumerable<GroupDTO>> GetGroupsByModuleIdAsync(int moduleId)
    {
        var filter = Builders<Group>.Filter.Eq("ModuleId", moduleId);
        var groups = await _collection.Find(filter).ToListAsync();
        return groups.Select(MapToDTO);
    }

    public async Task AddGroupAsync(Group group)
    {
        await AddAsync(group);
    }

    public async Task UpdateGroupAsync(GroupDTO group)
    {
        var filter = Builders<Group>.Filter.Eq("Id", group.GroupId);
        var updatedGroup = MapToEntity(group);
        await _collection.ReplaceOneAsync(filter, updatedGroup);
    }

    public async Task DeleteGroupAsync(int groupId)
    {
        var filter = Builders<Group>.Filter.Eq("Id", groupId);
        await _collection.DeleteOneAsync(filter);
    }

    private object GetIdValue(Group group)
    {
        var property = typeof(Group).GetProperty("Id");
        return property?.GetValue(group);
    }

    private GroupDTO MapToDTO(Group group)
    {
        // Implement the mapping logic from Group to GroupDTO
        // Assuming GroupDTO has similar properties to Group
        return new GroupDTO
        {
            GroupId = group.GroupId,
            // Map other properties as needed
        };
    }

    private Group MapToEntity(GroupDTO groupDTO)
    {
        // Implement the mapping logic from GroupDTO to Group
        // Assuming GroupDTO has similar properties to Group
        return new Group
        {
            GroupId = groupDTO.GroupId,
            // Map other properties as needed
        };
    }
}
