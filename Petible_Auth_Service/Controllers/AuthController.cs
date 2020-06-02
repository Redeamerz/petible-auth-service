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
using Petible_Auth_Service.ExternalAuthProviders;

namespace Petible_Auth_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // public object TokenGen { get; private set; }

        [HttpPost]
        public IActionResult GetToken([FromBody] LoginData data)
        {
            Firebaseauthclass fire = new Firebaseauthclass();
            if (data.email == null)
            {
                return BadRequest();
            }
            string token = fire.GetJWTToken(data);
            LoginInfo stuff = JsonConvert.DeserializeObject<LoginInfo>(token);
            return Ok(stuff);
        }
    }
}
