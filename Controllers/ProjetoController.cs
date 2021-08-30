using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T4i_WebAPI.Data;
using T4i_WebAPI.model;

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
        public async Task<IActionResult> Get()
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
        public async Task<IActionResult> GetByProjetoId(int projetoId)
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
        [HttpGet("works/{worksId}")]
        public async Task<IActionResult> GetByWorksId(int worksId)
        {
            try
            {
                var result = await _repo.GetProjetosAsyncByWorksId(worksId, false);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Projeto model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }
        [HttpPut("{projetoId}")]
        public async Task<IActionResult> Put(int projetoId, Projeto model)
        {
            try
            {
                var projeto = await _repo.GetProjetoAsyncById(projetoId, false);
                if (projeto == null) return NotFound("Projeto não encontrado");
                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }
         [HttpDelete("{projetoId}")]
        public async Task<IActionResult> delete(int projetoId)
        {
            try
            {
                var projeto = await _repo.GetProjetoAsyncById(projetoId, false);
                if (projeto == null) return NotFound();
                _repo.Delete(projeto);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }
    }
}