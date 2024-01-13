using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Application.Interfaces.IPresistence;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AssignmentService.UnitTests
{
    public class CourseServiceTests
    {
        private Mock<IMapper> _mockMapper;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<ICourseRepository> _mockCourseRepository;
        private ICourseService _CourseService;
        private ModuleDTO ModuleDto;
        private Mock<IFormFile> fileMock;

        [SetUp]
        public void Setup()
        {
            _mockMapper = new Mock<IMapper>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockCourseRepository = new Mock<ICourseRepository>();

            //_CourseService = new Application.BusinessLogic.CourseService(
            //    _mockMapper.Object,
            //    _mockConfiguration.Object,
            //    _mockCourseRepository.Object);




        }





    }
}
