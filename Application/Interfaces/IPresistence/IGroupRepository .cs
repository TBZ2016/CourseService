using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.IPresistence
{
    public interface IGroupRepository
    {
        Task<GroupDTO> GetGroupByIdAsync(int groupId);
        Task<IEnumerable<GroupDTO>> GetGroupsByModuleIdAsync(int moduleId);
        Task AddGroupAsync(Group group);
        Task UpdateGroupAsync(GroupDTO group);
        Task DeleteGroupAsync(int groupId);
    }
}
