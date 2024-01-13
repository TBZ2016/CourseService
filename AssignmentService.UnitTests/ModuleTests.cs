using Application.BusinessLogic;
using Application.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AssignmentService.UnitTests
{
    public class ModuleTests
    {
        private Mock<IMapper> _mockMapper;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<ModuleRepository> _mockModuleRepository;
        private ModuleService _moduleService;
        private ModuleDTO moduleDto;
        private Mock<IFormFile> fileMock;

        [SetUp]
        public void Setup()
        {
            _mockMapper = new Mock<IMapper>();
            _mockConfiguration = new Mock<IConfiguration>();
        }


    }
}
