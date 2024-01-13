using Application.Interfaces.IPresistence;
using Domain.Entities;
using MongoDB.Driver;
using Presistence;
using Presistence.BaseRepositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    private readonly IMongoCollection<Course> _collection;

    public CourseRepository(BaseDBContext dbContext) : base(dbContext)
    {
        _collection = dbContext.Database.GetCollection<Course>(typeof(Course).Name);
    }

    public async Task<Course> GetCourseByIdAsync(int courseId)
    {
        var filter = Builders<Course>.Filter.Eq("Id", courseId);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Course>> GetCoursesByModuleIdAsync(int moduleId)
    {
        var filter = Builders<Course>.Filter.Eq("ModuleId", moduleId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        await AddAsync(course);
    }

    public async Task UpdateCourseAsync(Course course)
    {
        var filter = Builders<Course>.Filter.Eq("Id", GetIdValue(course));
        await _collection.ReplaceOneAsync(filter, course);
    }

    public async Task DeleteCourseAsync(int courseId)
    {
        var filter = Builders<Course>.Filter.Eq("Id", courseId);
        await _collection.DeleteOneAsync(filter);
    }

    private object GetIdValue(Course course)
    {
        var property = typeof(Course).GetProperty("Id");
        return property.GetValue(course);
    }
}
