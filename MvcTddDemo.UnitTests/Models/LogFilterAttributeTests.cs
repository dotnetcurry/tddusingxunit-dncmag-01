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
    public class LogFilterTests
    {
        [Theory, InlineData("true"), InlineData("1"), InlineData("yes")]
        public void OnActionExecuting_ForValidQueryStringValues_VerifyLoggerServiceLogMethodCalledOnce(
            string queryStringValue)
        {
            //Arrange
            string queryStringKey = "log";
            var sut = new LogFilterAttribute();
            var httpContext = new Mock<HttpContextBase>();
            var httpRequestBaseStub = new Mock<HttpRequestBase>();
            httpRequestBaseStub.Setup(q =>
                q.QueryString).Returns(new NameValueCollection() 
                { { queryStringKey, queryStringValue } });
            httpContext.Setup(x => x.Request).Returns(httpRequestBaseStub.Object);
            var actionDescriptor = new Mock<ActionDescriptor>().Object;
            var controller = new FakeController();
            var controllerContext = new ControllerContext(
                httpContext.Object, new RouteData(), controller);
            var stubFilterContext = new ActionExecutingContext(
                controllerContext, actionDescriptor, new RouteValueDictionary());
            var loggerServiceMock = new Mock<ILoggerService>();
            sut.LoggerService = loggerServiceMock.Object;
            //Act
            sut.OnActionExecuting(stubFilterContext);
            //Assert
            loggerServiceMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once());
        }
        class FakeController : Controller
        { }
    }
}
