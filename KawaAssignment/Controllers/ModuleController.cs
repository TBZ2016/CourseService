using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace KawaAssignment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleDTO>>> GetAllModules()
        {
            var modules = await _moduleService.GetAllModulesAsync();
            return Ok(modules);
        }

        /// <summary>
        /// Gets a module by its identifier.
        /// </summary>
        /// <param name="moduleId">The identifier of the module.</param>
        /// <returns>Returns the module with the specified identifier.</returns>
        /// <response code="200">Returns the requested module.</response>
        /// <response code="404">If the module with the given identifier is not found.</response>
        [HttpGet("{moduleId}")]
        [ProducesResponseType(typeof(ModuleDTO), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetModuleById(int moduleId)
        {
            var module = await _moduleService.GetModuleByIdAsync(moduleId);

            if (module == null)
            {
                return NotFound(new { Error = "Module not found" });
            }

            return Ok(module);
        }

        /// <summary>
        /// Creates a new module.
        /// </summary>
        /// <param name="moduleDTO">The module data transfer object.</param>
        /// <returns>Returns the created module.</returns>
        /// <response code="201">Returns the newly created module.</response>
        /// <response code="400">If the moduleDTO is invalid or null.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ModuleDTO), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateModule([FromBody] ModuleDTO moduleDTO)
        {
            try
            {
                 await _moduleService.CreateModuleAsync(moduleDTO);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{moduleId}")]
        public async Task<IActionResult> UpdateModule(int moduleId, [FromBody] ModuleDTO moduleDTO)
        {
            await _moduleService.UpdateModuleAsync(moduleId, moduleDTO);
            return NoContent();
        }

        [HttpDelete("{moduleId}")]
        public async Task<IActionResult> DeleteModule(int moduleId)
        {
            await _moduleService.DeleteModuleAsync(moduleId);
            return NoContent();
        }
    }
}
