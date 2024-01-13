using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace KawaCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("module/{moduleId}")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroupsByModuleId(int moduleId)
        {
            var groups = await _groupService.GetGroupsByModuleIdAsync(moduleId);
            return Ok(groups);
        }

        [HttpGet("{groupId}")]
        public async Task<ActionResult<GroupDTO>> GetGroupById(int groupId)
        {
            var group = await _groupService.GetGroupByIdAsync(groupId);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpPost("module/{moduleId}")]
        public async Task<IActionResult> AssignGroupToModule(int moduleId, [FromBody] GroupDTO groupDTO)
        {
            await _groupService.AssignGroupToModuleAsync(moduleId, groupDTO);
            return CreatedAtAction(nameof(GetGroupById), new { groupId = groupDTO.GroupId }, groupDTO);
        }

        [HttpPut("{groupId}")]
        public async Task<IActionResult> UpdateGroup(int groupId, [FromBody] GroupDTO groupDTO)
        {
            await _groupService.UpdateGroupAsync(groupId, groupDTO);
            return NoContent();
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            await _groupService.DeleteGroupAsync(groupId);
            return NoContent();
        }
    }
}
