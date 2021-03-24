using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RestOpenAPI.Controllers;
using System.Linq;

namespace RestOpenAPI.NTest
{
    [TestFixture]
    public class WeatherForecastControllerTest
    {
        WeatherForecastController _controller;
        ILogger<WeatherForecastController> _logger;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<ILogger<WeatherForecastController>>();
            _logger = mock.Object;
            _controller = new WeatherForecastController(_logger);
        }

        [Test]
        public void Get_WhenCalled_ReturnsCollection()
        {
            var result = _controller.Get();
            int count = result.ToList().Count;
            Assert.AreEqual(5, count);
        }

        [Test]
        public void Get_WhenCalled_With_Param_ReturnsCollection()
        {
            var result = _controller.Get(7);
            int count = result.ToList().Count;
            Assert.AreEqual(7, count);
        }
    }
}