using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnnonce.Models;
using ApiAnnonce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnnonce.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private ILogin _loginService;

        public AuthentificationController(ILogin loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public JsonResult Login([FromBody]Utilisateur utilisateur)
        {
            return new JsonResult(new { token = _loginService.Login(utilisateur) });
        }
    }
}