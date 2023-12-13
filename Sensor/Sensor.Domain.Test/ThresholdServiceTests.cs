using Moq;
using Sensor.Domain.Impl.Services;
using Sensor.Domain.Model;
using Sensor.Infrastructure.Cache;
using Sensor.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensor.Domain.Test
{
    [TestFixture]
    public class ThresholdServiceTests
    {
        private Mock<IThresholdRepository> _mockRepository;
        private Mock<ICache> _mockCache;
        private ThresholdService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IThresholdRepository>();
            _mockCache = new Mock<ICache>();
            _service = new ThresholdService(_mockCache.Object, _mockRepository.Object);
        }

        [Test]
        public void AddThreshold_WithUniqueIndicatorAndSourceId_ShouldAddThreshold()
        {

            var threshold = new Threshold(1, 1, 1, 10, 20);
            _mockRepository.Setup(r => r.GetAll()).Returns(new List<Threshold>());


            _service.AddThreshold(threshold);


            _mockRepository.Verify(r => r.Add(threshold), Times.Once);
        }

        [Test]
        public void AddThreshold_WithExistingIndicatorAndSourceId_ThrowsInvalidOperationException()
        {

            var existingThreshold = new Threshold(1, 1, 1, 10, 20);
            var newThreshold = new Threshold(2, 1, 1, 15, 25);
            _mockRepository.Setup(r => r.GetAll()).Returns(new List<Threshold> { existingThreshold });

            Assert.Throws<InvalidOperationException>(() => _service.AddThreshold(newThreshold));
        }
    }
}
