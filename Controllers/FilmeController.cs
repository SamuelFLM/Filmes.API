using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_Filmes.Models;

namespace WEBAPI_Filmes.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult ObterTodos(Filme filme)
        {
            return Ok(filme);
        }
    }
}