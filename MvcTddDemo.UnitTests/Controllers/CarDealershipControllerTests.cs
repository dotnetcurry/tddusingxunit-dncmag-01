using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Moq;
using MvcTddDemo.Controllers;
using MvcTddDemo.Models;
using Xunit;
using Xunit.Extensions;
using System.Web.Routing;
using System.Web;
using System.Collections.Specialized;

namespace MvcTddDemo.UnitTests
{
    public class CarDealershipControllerTests
    {
        private Mock<ICarDealershipRepository> repositoryStub;
        private CarDealershipController sut;

        public CarDealershipControllerTests()
        {
            repositoryStub = new Mock<ICarDealershipRepository>();
            sut = new CarDealershipController(repositoryStub.Object);
        }
        [Fact]
        public void List_WhenActionExecute_ReturnModelContainsListOfCars()
        {
            //Arrange
            repositoryStub.Setup(x => x.GetAllCars()).Returns
                (() => new List<Car> { new Car { } });
            //Act
            var result = sut.List() as ViewResult;
            //Assert
            Assert.True(((IEnumerable<Car>)result.Model).Any());
        }
        [Fact]
        public void List_WhenActionExecute_ReturnsViewNameList()
        {
            //Act
            var result = sut.List() as ViewResult;

            //Assert
            Assert.Equal<string>(result.ViewName, "List");
        }
    }
}
