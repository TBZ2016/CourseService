using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Application.Interfaces.IPresistence;
using AutoMapper;
using Domain.Entities;
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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private IMapper object1;
        private IConfiguration object2;
        private ICourseRepository object3;

        public CourseService(IMapper @object, ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public CourseService(IMapper object1, IConfiguration object2, ICourseRepository object3)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.object3 = object3;
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int courseId)
        {
            var courseEntity = await _courseRepository.GetCourseByIdAsync(courseId);
            return _mapper.Map<CourseDTO>(courseEntity);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courseEntities = await _courseRepository.GetAllCoursesAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(courseEntities);
        }

        public async Task CreateCourseAsync(CourseDTO courseDto)
        {
            var courseEntity = _mapper.Map<CourseDTO>(courseDto);
            await _courseRepository.CreateCourseAsync(courseEntity);
        }

        public async Task<IEnumerable<ModuleDTO>> GetModulesByCourseIdAsync(int courseId)
        {
            var modules = await _courseRepository.GetModulesByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<ModuleDTO>>(modules);
        }

        public async Task UpdateCourseAsync(int courseId, CourseDTO courseDto)
        {
            var existingCourse = await _courseRepository.GetCourseByIdAsync(courseId);
            if (existingCourse == null)
            {
                // Handle course not found
                throw new NotFoundException($"Course with ID {courseId} not found");
            }

            // Update existingCourse with values from courseDto
            _mapper.Map(courseDto, existingCourse);

            await _courseRepository.UpdateCourseAsync(existingCourse);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var existingCourse = await _courseRepository.GetCourseByIdAsync(courseId);
            if (existingCourse == null)
            {
                // Handle course not found
                throw new NotFoundException($"Course with ID {courseId} not found");
            }

            await _courseRepository.DeleteCourseAsync(existingCourse);
        }
    }
}

