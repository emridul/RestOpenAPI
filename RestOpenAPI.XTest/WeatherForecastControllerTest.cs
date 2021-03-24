using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RestOpenAPI.Controllers;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace RestOpenAPI.XTest
{
    public class WeatherForecastControllerTest
    {
        WeatherForecastController _controller;
        ILogger<WeatherForecastController> _logger;

        public WeatherForecastControllerTest()
        {
            var mock = new Mock<ILogger<WeatherForecastController>>();
            _logger = mock.Object;
            _controller = new WeatherForecastController(_logger);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsCollection()
        {
            var result = _controller.Get();
            int count = result.ToList().Count;
            Assert.Equal(5, count);
        }

        [Fact]
        public void Get_WhenCalled_With_Param_ReturnsCollection()
        {
            var result = _controller.Get(7);
            int count = result.ToList().Count;
            Assert.Equal(7, count);
        }
    }
}
