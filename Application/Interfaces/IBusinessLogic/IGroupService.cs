using Application.DTOs;

namespace Application.Interfaces.IBusinessLogic
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetGroupsByModuleIdAsync(int moduleId);
        Task<GroupDTO> GetGroupByIdAsync(int groupId);
        Task AssignGroupToModuleAsync(int moduleId, GroupDTO groupDTO);
        Task UpdateGroupAsync(int groupId, GroupDTO groupDTO);
        Task DeleteGroupAsync(int groupId);
    }
}
