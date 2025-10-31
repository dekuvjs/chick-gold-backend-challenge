using Microsoft.AspNetCore.Mvc;
using WaterJugChallenge.Controllers;
using WaterJugChallenge.Models.RequestsModels;
using Xunit;

namespace WaterJugChallenge.Tests
{
    public class WaterJugControllerTests
    {
        private readonly WaterJugController _controller;

        public WaterJugControllerTests()
        {
            _controller = new WaterJugController();
        }

        [Fact]
        public void Calculate_ValidInput_ReturnsOkResult()
        {
            var request = new WaterJugRequest
            {
                XBucketCapacity = 4,
                YBucketCapacity = 3,
                ZAmountWanted = 2
            };

            var result = _controller.Calculate(request);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Calculate_ImpossibleSolution_Returns500()
        {
            var request = new WaterJugRequest
            {
                XBucketCapacity = 2,
                YBucketCapacity = 6,
                ZAmountWanted = 5
            };

            var result = _controller.Calculate(request);

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
        }

        [Fact]
        public void Calculate_ZeroCapacity_Returns500()
        {
            var request = new WaterJugRequest
            {
                XBucketCapacity = 0,
                YBucketCapacity = 3,
                ZAmountWanted = 2
            };

            var result = _controller.Calculate(request);

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
        }

        [Fact]
        public void Calculate_WantedAmountGreaterThanBuckets_Returns500()
        {
            var request = new WaterJugRequest
            {
                XBucketCapacity = 3,
                YBucketCapacity = 4,
                ZAmountWanted = 8
            };

            var result = _controller.Calculate(request);

            var statusResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusResult.StatusCode);
        }
    }
}