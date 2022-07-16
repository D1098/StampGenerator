using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace LearningP.Controllers
{
    [Route("api/[controller].[action]")]
    [ApiController]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Test(string guid) => guid;

        [HttpGet]
        public Guid GetGuid() => Guid.NewGuid();

        [HttpGet]
        public string Test2(string guid)
        {
            StampInfo stamp = new StampInfo(guid);
            return stamp.ToString();
        }
    }
}
