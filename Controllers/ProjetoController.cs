using System;
using Microsoft.AspNetCore.Mvc;
using T4i_WebAPI.Data;

namespace T4i_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        public ProjetoController(IRepository repo)
        {
            repo = repo;
        }
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