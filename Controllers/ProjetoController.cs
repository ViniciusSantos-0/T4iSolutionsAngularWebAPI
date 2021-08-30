using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T4i_WebAPI.Data;

namespace T4i_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly IRepository _repo;
        public ProjetoController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            try
            {   
                var result = await _repo.GetAllProjetosAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }
         [HttpGet("{projetoId}")]
        public async Task <IActionResult> GetByProjetoId(int projetoId)
        {
            try
            {   
                var result = await _repo.GetProjetoAsyncById(projetoId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }
    }
}