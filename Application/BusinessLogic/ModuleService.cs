using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Application.Interfaces.IInfrastructure.IAzureServices;
using Application.Interfaces.IPresistence;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public ModuleService(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public async Task<ModuleDTO> GetModuleByIdAsync(int moduleId)
        {
            var moduleEntity = await _moduleRepository.GetModuleByIdAsync(moduleId);
            return _mapper.Map<ModuleDTO>(moduleEntity);
        }

        public async Task<IEnumerable<ModuleDTO>> GetAllModulesAsync()
        {
            var modulesEntities = await _moduleRepository.GetAllModulesAsync();
            return _mapper.Map<IEnumerable<ModuleDTO>>(modulesEntities);
        }

        public async Task CreateModuleAsync(ModuleDTO moduleDTO)
        {
            var moduleEntity = _mapper.Map<ModuleDTO>(moduleDTO);
            await _moduleRepository.CreateModuleAsync(moduleEntity);
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByModuleIdAsync(int moduleId)
        {
            var coursesEntities = await _moduleRepository.GetCoursesByModuleIdAsync(moduleId);
            return _mapper.Map<IEnumerable<CourseDTO>>(coursesEntities);
        }

        public async Task UpdateModuleAsync(ModuleDTO moduleDTO)
        {
            var moduleEntity = _mapper.Map<ModuleDTO>(moduleDTO);
            await _moduleRepository.UpdateModuleAsync(moduleEntity);
        }

        public async Task DeleteModuleAsync(int moduleId)
        {
            var moduleEntity = await _moduleRepository.GetModuleByIdAsync(moduleId);

            if (moduleEntity != null)
            {
                await _moduleRepository.DeleteModuleAsync(moduleEntity);
            }
            else
            {
                throw new NotFoundException($"Module with ID {moduleId} not found.");
            }
        }
    }
}
