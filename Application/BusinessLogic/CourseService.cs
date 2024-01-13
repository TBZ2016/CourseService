using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Application.Interfaces.IPresistence;
using AutoMapper;

namespace Application.BusinessLogic
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(IMapper @object, ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper;
        }

        //public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        //{
        //    var courses = await _courseRepository.GetAllAsync();
        //    return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        //}

        public async Task<CourseDTO> GetCourseByIdAsync(int courseId)
        {
            var course = await _courseRepository.GetCourseByIdAsync(courseId);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByModuleIdAsync(int moduleId)
        {
            var courses = await _courseRepository.GetCoursesByModuleIdAsync(moduleId);
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task CreateCourseAsync(CourseDTO courseDTO)
        {
            var course = _mapper.Map<Domain.Entities.Course>(courseDTO);
            await _courseRepository.AddCourseAsync(course);
        }

        public async Task UpdateCourseAsync(int courseId, CourseDTO courseDTO)
        {
            var existingCourse = await _courseRepository.GetCourseByIdAsync(courseId);
            if (existingCourse == null)
            {
                // Handle not found scenario
                return;
            }

            _mapper.Map(courseDTO, existingCourse);
            await _courseRepository.UpdateCourseAsync(existingCourse);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _courseRepository.DeleteCourseAsync(courseId);
        }
    }
}



