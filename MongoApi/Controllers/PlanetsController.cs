using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDataLibrary.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PlanetsController : Controller
    {
        private readonly IMongoDataService _mongoDataService;

        public PlanetsController(IMongoDataService mongoDataService)
        {
            _mongoDataService = mongoDataService;
        }

        /// <summary>
        /// Planets found in Mongo DB sample collection
        /// </summary>
        /// <returns>Array of Planet objects</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var planets = _mongoDataService.GetPlanets();
            return Ok(planets);
        }
    }
}

