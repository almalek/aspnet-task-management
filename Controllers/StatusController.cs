using Microsoft.AspNetCore.Mvc;

namespace Codex
{
    public class StatusController : Controller
    {
        // GET: /<controller>/
        [HttpGet("/Status/{status}")]
        public IActionResult Index(int status)
        {
            return View(status);
        }
    }
}