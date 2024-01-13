using Application.DTOs;
using Application.Interfaces.IPresistence;
using AutoMapper;
using IGroupService = Application.Interfaces.IBusinessLogic.IGroupService;

namespace Application.BusinessLogic
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;


        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupDTO>> GetGroupsByModuleIdAsync(int moduleId)
        {
            var groups = await _groupRepository.GetGroupsByModuleIdAsync(moduleId);
            return _mapper.Map<IEnumerable<GroupDTO>>(groups);
        }

        public async Task<GroupDTO> GetGroupByIdAsync(int groupId)
        {
            var group = await _groupRepository.GetGroupByIdAsync(groupId);
            return _mapper.Map<GroupDTO>(group);
        }

        public async Task AssignGroupToModuleAsync(int moduleId, GroupDTO groupDTO)
        {
            var group = _mapper.Map<Domain.Entities.Group>(groupDTO);
            group.ModuleId = moduleId;
            await _groupRepository.AddGroupAsync(group);
        }

        public async Task UpdateGroupAsync(int groupId, GroupDTO groupDTO)
        {
            var existingGroup = await _groupRepository.GetGroupByIdAsync(groupId);
            if (existingGroup == null)
            {
                // Handle not found scenario
                return;
            }

            _mapper.Map(groupDTO, existingGroup);
            await _groupRepository.UpdateGroupAsync(existingGroup);
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            await _groupRepository.DeleteGroupAsync(groupId);
        }
    }
}
