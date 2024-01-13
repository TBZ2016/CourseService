using Application.DTOs.Mapping;
using Domain.Entities;

namespace Application.DTOs
{
    public class GroupDTO : Group, IMapFrom<Group>
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int ModuleId { get; set; }
    }
}
