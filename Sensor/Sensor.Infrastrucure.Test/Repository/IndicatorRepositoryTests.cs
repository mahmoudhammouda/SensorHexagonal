using NUnit.Framework;
using Moq;
using AutoMapper;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Repository;
using Sensor.Infrastructure.Repository.Model;
using Sensor.Infrastructure.Impl.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Sensor.Infrastrucure.Test.Repository
{
   [TestFixture]
    public class IndicatorRepositoryTests
    {
        private Mock<IGenericRepository<IndicatorEntity>> _mockGenericRepository;
        private Mock<IMapper> _mockMapper;
        private IndicatorRepository _repository;

        [SetUp]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<IndicatorEntity>>();
            _mockMapper = new Mock<IMapper>();
            _repository = new IndicatorRepository(_mockGenericRepository.Object, _mockMapper.Object);
        }

        [Test]
        public void GetAll_WhenCalled_ReturnsAllIndicators()
        {
            // Arrange
            var indicatorEntities = new List<IndicatorEntity> { };
            var indicators = new List<Indicator> { };
            _mockGenericRepository.Setup(r => r.GetAll()).Returns(indicatorEntities.AsQueryable());
            _mockMapper.Setup(m => m.Map<IEnumerable<Indicator>>(It.IsAny<IEnumerable<IndicatorEntity>>())).Returns(indicators);

            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.AreEqual(indicators.Count, result.Count());
        }
    }
}
