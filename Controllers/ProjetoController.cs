using System;
using Microsoft.AspNetCore.Mvc;

namespace T4i_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
         [HttpGet]
        public IActionResult Get()
        {   
            try
        {
            return Ok("");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }
            
        }
    }
}