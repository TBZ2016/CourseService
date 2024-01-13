using Application.Interfaces.IPresistence;
using Domain.Entities;
using MongoDB.Bson;
using Presistence.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class CourseRepository : BaseRepository<CourseDTO>, ICourseRepository
    {
        public CourseRepository(BaseDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int courseId)
        {
            return await GetSingleAsync(x => x.Id = courseId);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            return await GetAllAsync();
        }

        public async Task CreateCourseAsync(CourseDTO courseEntity)
        {
            await AddAsync(courseEntity);
        }


        public async Task UpdateCourseAsync(CourseDTO courseEntity)
        {
            await UpdateAsync(courseEntity);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await DeleteAsync(courseId);
        }
    }
}
