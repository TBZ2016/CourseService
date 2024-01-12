using Application.BusinessLogic;
using Application.DTOs;
using Application.Interfaces.IBusinessLogic;
using Application.Interfaces.IInfrastructure.IAzureServices;
using Application.Interfaces.IPresistence;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Moq;
using Presistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
