using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IBusinessLogic
{
    public interface ICourseService
    {
        Task<CourseDTO> GetCourseByIdAsync(int courseId);
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task CreateCourseAsync(CourseDTO courseDto);
        Task<IEnumerable<ModuleDTO>> GetModulesByCourseIdAsync(int courseId);
        Task UpdateCourseAsync(int courseId, CourseDTO courseDto);
        Task DeleteCourseAsync(int courseId);
    }
}
