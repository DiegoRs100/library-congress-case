using Devpack.Notifications.Notifier;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Devpack.Notifications.Filters
{
    public class ModelStateNotifierFilter : IActionFilter
    {
        private readonly INotifier _notifier;

        public ModelStateNotifierFilter(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Not implemented.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState?.IsValid != false)
                return;

            foreach (var field in context.ModelState)
            {
                foreach (var error in field.Value.Errors)
                    _notifier.NotifyAsync("ModelStateValidation", field.Key, error.ErrorMessage, HttpStatusCode.BadRequest);
            }
        }
    }
}