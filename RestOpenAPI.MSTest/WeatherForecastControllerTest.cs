using Machine.Specifications;
using Microsoft.Extensions.Logging;
using Moq;
using RestOpenAPI.Controllers;
using System;
using System.Linq;

namespace RestOpenAPI.MSTest
{
    [Subject(typeof(WeatherForecastController))]
    public class When_Get_method_is_called
    {
        static int count;

        static WeatherForecastController Subject;
        static ILogger<WeatherForecastController> _logger;

        Establish context = () =>
        {
            var mock = new Mock<ILogger<WeatherForecastController>>();
            _logger = mock.Object;
            Subject = new WeatherForecastController(_logger);
        };

        Because of = () => count = Subject.Get().Count();

        Machine.Specifications.It returns_all_records = () => count.Equals(10);
    }

    [Subject(typeof(WeatherForecastController))]
    public class When_Get_method_is_called_with_parameter
    {
        static int count;

        static WeatherForecastController Subject;
        static ILogger<WeatherForecastController> _logger;

        Establish context = () =>
        {
            var mock = new Mock<ILogger<WeatherForecastController>>();
            _logger = mock.Object;
            Subject = new WeatherForecastController(_logger);
        };

        Because of = () => count = Subject.Get(7).Count();

        Machine.Specifications.It returns_filtered_records = () => count.Equals(7);
    }
}
