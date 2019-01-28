using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Error() => View();
    }
}