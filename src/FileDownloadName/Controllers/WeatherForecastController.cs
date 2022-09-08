using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace FileDownloadName.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5);
        }
    }
}