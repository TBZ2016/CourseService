using Application.Interfaces.IBusinessLogic;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KawaAssignment.Controllers
{

    public class ModuleController : ControllerBase
    {
        private readonly ILogger<ModuleController> _logger;
        private readonly IModuleService _moduleService;

        public ModuleController(ILogger<ModuleController> logger, IModuleService moduleService)
        {
            _logger = logger;
            _moduleService = moduleService;
        }

        #region POST

        [HttpPost(Name = "modules")]
        public async Task<ActionResult> CreateModule([FromBody] ModuleDTO moduleInfo)
        {
            try
            {
                if (moduleInfo != null)
                {
                    // Logic to handle the creation of a new module using moduleInfo
                    // Example implementation:
                    await _moduleService.CreateModuleAsync(moduleInfo);
                    // Return a response indicating success
                    return StatusCode(201, "Module created");
                }
                else
                {
                    // Handle invalid input or missing data
                    return BadRequest("Invalid input or missing data");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        #endregion

        #region GET

        [HttpGet(Name = "modules")]
        public async Task<ActionResult<IEnumerable<ModuleDTO>>> GetModules()
        {
            try
            {
                var modules = await _moduleService.GetAllModulesAsync();

                if (modules.Any())
                {
                    return Ok(modules);
                }
                else
                {
                    return NotFound("No modules found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("{moduleId}", Name = "getModuleById")]
        public async Task<ActionResult<ModuleDTO>> GetModuleById(int moduleId)
        {
            try
            {
                var module = await _moduleService.GetModuleByIdAsync(moduleId);

                if (module != null)
                {
                    return Ok(module);
                }
                else
                {
                    return NotFound("Module not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        #endregion

        #region PUT

        [HttpPut("{moduleId}", Name = "updateModule")]
        public async Task<ActionResult> UpdateModule(int moduleId, [FromBody] ModuleDTO updatedModuleInfo)
        {
            try
            {
                if (updatedModuleInfo != null)
                {
                    // Logic to handle the update of an existing module using updatedModuleInfo
                    // Example implementation:
                    await _moduleService.UpdateModuleAsync(moduleId, updatedModuleInfo);
                    // Return a response indicating success
                    return Ok("Module updated");
                }
                else
                {
                    // Handle invalid input or missing data
                    return BadRequest("Invalid input or missing data");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("{moduleId}", Name = "deleteModule")]
        public async Task<ActionResult> DeleteModule(int moduleId)
        {
            try
            {
                await _moduleService.DeleteModuleAsync(moduleId);


                return NotFound("Module not found");

            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the module.");
            }
        }

        #endregion
    }
}
