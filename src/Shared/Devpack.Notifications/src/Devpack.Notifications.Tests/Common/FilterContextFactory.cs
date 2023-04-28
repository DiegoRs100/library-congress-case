using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace Devpack.Notifications.Tests.Common
{
    public static class FilterContextFactory
    {
        public static ActionExecutingContext CreateContext()
        {
            var actionContext = new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor());
            return new ActionExecutingContext(actionContext, new List<IFilterMetadata>(), new Dictionary<string, object>(), "fake-controller");
        }
    }
}