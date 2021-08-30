using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T4i_WebAPI.Data;

namespace T4i_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevController : ControllerBase
    {   
        private readonly IRepository _repo;
        public DevController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
       public async Task <IActionResult> Get()
        {
            try
            {   
                var result = await _repo.GetAllDevsAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }
           [HttpGet("{idDev}")]
        public async Task <IActionResult> GetByIdDev(int IdDev)
        {
            try
            {   
                var result = await _repo.GetDevAsyncById(IdDev, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }
    }
}