using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<Group> GetGroupByIdAsync(int groupId);
        Task<IEnumerable<Group>> GetGroupsByModuleIdAsync(int moduleId);
        Task AddGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int groupId);
    }
}
