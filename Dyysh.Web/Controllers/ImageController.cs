using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;

namespace Dyysh.Web.Controllers
{
    public class ImageController : Controller
    {
        [SecureImage]
        public IActionResult Index(string id)
        {
            return View();
        }
    }

    public class SecureImageAttribute : TypeFilterAttribute
    {
        public SecureImageAttribute() : base(typeof(SecureImageAttributeImplementation))
        {
        }

        private class SecureImageAttributeImplementation : IAsyncActionFilter
        {
            public SecureImageAttributeImplementation(IDistributedCache cache)
            {
                var a = "ebalo";
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                await next();
            }
        }
    }
}
