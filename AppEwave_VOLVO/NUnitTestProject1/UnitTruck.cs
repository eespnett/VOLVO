using Moq;
using NUnit.Framework;
using System;
using WebApplication1.Controllers;

namespace NUnitTestProject1
{
    public class UnitTruck
    {
        public HomeController _controller { get; set; }
        [SetUp]
        public void Setup()
        {
            _controller = new HomeController();
 
            var httpContext = new Mock<HomeController>();
        
        }

        [Test]
        public void Test1()
        {
            //Arrange
            _controller = new HomeController();

            var httpContext = new Mock<HomeController>();

            //Act

            // Assert
            Assert.Pass();
        }
    }
}