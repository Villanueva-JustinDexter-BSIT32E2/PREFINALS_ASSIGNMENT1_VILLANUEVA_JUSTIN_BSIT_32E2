using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var user = new
            {
                Name = "Kevin Nico C. Francisco",
                Section = "32E2",
                Course = "BSIT",
                FunFacts = new List<string>
                {
                    "I love coding.",
                    "I enjoy basketball.",
                    "My favorite player is 'Romblon James'.",
                    // Add more fun facts...
                }
            };

            return Ok(user);
        }

        [Authorize]
        [HttpGet("about/me")]
        public IActionResult AboutMe()
        {
            // This endpoint randomly generates things about the creator or the owner of the repository.
            var funFacts = new List<string>
            {
                "I love coding.",
                "I enjoy basketball.",
                "My favorite player is 'Romblon James'.",
                
            };
            var fact = funFacts[new Random().Next(funFacts.Count)];
            return Ok(fact);
        }

        [Authorize]
        [HttpGet("about")]
        public IActionResult About()
        {
            // This endpoint gives the name of the creator.
            var name = "Kevin Nico C. Francisco"; 
            return Ok(name);
        }

        [Authorize]
        [HttpPost("about")]
        public IActionResult About([FromBody] string name)
        {
            // This endpoint allows the user/caller of the API to POST Name, then it returns a "Hi <Name> from <Owner>"
            var owner = "Kevin Nico C. Francisco"; 
            return Ok($"Hi {name} from {owner}");
        }
    }
}
