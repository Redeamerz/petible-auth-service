using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Petible_Auth_Service.Logic;
using Petible_Auth_Service.Models;

namespace Petible_Auth_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
       
        public AuthController(ILogger<AuthController> logger)
        {
           
        }

        public object TokenGen { get; private set; }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] JsonElement data)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            UserData user = JsonConvert.DeserializeObject<UserData>(json);
            IActionResult response = Unauthorized();
            if (user.username == "test2" && user.password == "test2")
            {
                string token = TokenGeneration.GenerateToken(user.username);
                response = Ok(new { token = token });
            }
            return response;
        }
    }
}
