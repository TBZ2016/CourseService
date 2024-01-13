using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Application.Interfaces.IPresistence;
using AutoMapper;


namespace Application.BusinessLogic
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public ModuleService(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository ?? throw new ArgumentNullException(nameof(moduleRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ModuleDTO>> GetAllModulesAsync()
        {
            var modules = await _moduleRepository.GetAllModulesAsync();
            return _mapper.Map<IEnumerable<ModuleDTO>>(modules);
        }

        public async Task<ModuleDTO> GetModuleByIdAsync(int moduleId)
        {
            var module = await _moduleRepository.GetModuleByIdAsync(moduleId);
            return _mapper.Map<ModuleDTO>(module);
        }
        public async Task CreateModuleAsync(ModuleDTO moduleDTO)
        {
            if (moduleDTO == null)
            {
                throw new ArgumentNullException(nameof(moduleDTO), "ModuleDTO cannot be null");
            }

            // Check for required properties
            if (string.IsNullOrEmpty(moduleDTO.ModuleName))
            {
                throw new ArgumentException("ModuleName cannot be null or empty", nameof(moduleDTO.ModuleName));
            }

            if (moduleDTO.StartDate == default)
            {
                throw new ArgumentException("StartDate is required", nameof(moduleDTO.StartDate));
            }

            if (moduleDTO.EndDate == default)
            {
                throw new ArgumentException("EndDate is required", nameof(moduleDTO.EndDate));
            }



            var module = _mapper.Map<Module>(moduleDTO);
            await _moduleRepository.AddModuleAsync(module);
        }

        public async Task UpdateModuleAsync(int moduleId, ModuleDTO moduleDTO)
        {
            var existingModule = await _moduleRepository.GetModuleByIdAsync(moduleId);
            if (existingModule == null)
            {
                // Handle not found scenario
                return;
            }

            var module = _mapper.Map<Module>(moduleDTO);
            await _moduleRepository.UpdateModuleAsync(moduleId, module);
        }

        public async Task DeleteModuleAsync(int moduleId)
        {
            await _moduleRepository.DeleteModuleAsync(moduleId);
        }
    }
}
