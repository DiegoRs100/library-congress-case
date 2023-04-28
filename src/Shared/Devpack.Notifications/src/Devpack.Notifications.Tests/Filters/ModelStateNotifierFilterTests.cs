using Devpack.Notifications.Filters;
using Devpack.Notifications.Notifier;
using Devpack.Notifications.Tests.Common;
using Moq;
using System;
using System.Net;
using Xunit;

namespace Devpack.Notifications.Tests.Filters
{
    public class ModelStateNotifierFilterTests
    {
        private readonly Mock<INotifier> _notifierMock;

        public ModelStateNotifierFilterTests()
        {
            _notifierMock = new Mock<INotifier>();
        }

        [Fact (DisplayName = "Deve finalizar o filter sem qualquer ação quando a modelstate for nula.")]
        [Trait("Category", "Filters")]
        public void OnActionExecuting_WhenModelStateValid()
        {
            var actionExecutingContext = FilterContextFactory.CreateContext();
            var modelStateActionFilter = new ModelStateNotifierFilter(_notifierMock.Object);

            modelStateActionFilter.OnActionExecuting(actionExecutingContext);

            _notifierMock.Verify(m => m.Notify(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<HttpStatusCode>()), Times.Never);
        }

        [Fact(DisplayName = "Deve notificar erros da modelstate quando a mesma for inválida.")]
        [Trait("Category", "Filters")]
        public void OnActionExecuting_WhenModelStateInvalid()
        {
            // Arrange
            var key1 = Guid.NewGuid().ToString();
            var key2 = Guid.NewGuid().ToString();
            var error1 = Guid.NewGuid().ToString();
            var error2 = Guid.NewGuid().ToString();
            var error3 = Guid.NewGuid().ToString();

            var actionExecutingContext = FilterContextFactory.CreateContext();
            var modelStateActionFilter = new ModelStateNotifierFilter(_notifierMock.Object);

            actionExecutingContext.ModelState.AddModelError(key1, error1);
            actionExecutingContext.ModelState.AddModelError(key1, error2);
            actionExecutingContext.ModelState.AddModelError(key2, error3);

            // Act
            modelStateActionFilter.OnActionExecuting(actionExecutingContext);

            // Asserts
            _notifierMock.Verify(m => m.Notify("ModelStateValidation", key1, error1, HttpStatusCode.BadRequest), Times.Once);
            _notifierMock.Verify(m => m.Notify("ModelStateValidation", key1, error2, HttpStatusCode.BadRequest), Times.Once);
            _notifierMock.Verify(m => m.Notify("ModelStateValidation", key2, error3, HttpStatusCode.BadRequest), Times.Once);
        }
    }
}