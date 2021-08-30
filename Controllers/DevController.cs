using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T4i_WebAPI.Data;
using T4i_WebAPI.model;

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
        public async Task<IActionResult> Get()
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
        public async Task<IActionResult> GetByIdDev(int IdDev)
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
        [HttpGet("byprojeto/{projetoId}")]
        public async Task<IActionResult> GetByProjetoId(int projetoId)
        {
            try
            {
                var result = await _repo.GetDevsAsyncByProjetoId(projetoId, false);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> post(Dev model)
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
       
        [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, Dev model)
        {
            try
            {
                var dev = await _repo.GetDevAsyncById(id, false);
                if (dev == null) return NotFound("Projeto não encontrado");
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
            return BadRequest("nu sei");
        }

        [HttpDelete("{idDev}")]
        public async Task<IActionResult> delete(int IdDev)
        {
            try
            {
                var dev = await _repo.GetDevAsyncById(IdDev, false);
                if (dev == null) return NotFound();

                _repo.Delete(dev);
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