using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyOrder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IOptions<AppSettings> options;

        public HomeController(IOptions<AppSettings> options)
        {
            this.options = options;
        }
        [HttpGet]
        public AppSettings Index()
        {
            return options.Value;
        }
    }
}

