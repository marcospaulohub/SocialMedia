using Microsoft.AspNetCore.Mvc;
using SocialMedia.App.Models.Contas;
using SocialMedia.App.Services.Contas;

namespace SocialMedia.API.Controllers
{
    [Route("api/contas")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost]
        public IActionResult Cadastro(CreateContaInputModel model)
        {
            var result = _contaService.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data}, model);
        }

        [HttpGet("PorId/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _contaService.GetById(id);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("PorEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var result = _contaService.GetByEmail(email);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UpdateContaInputModel model)
        {
            var result = _contaService.Update(id, model);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _contaService.Delete(id);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return NoContent();
        }

        [HttpPut("MudarSenha/{email}")]
        public IActionResult MudarSenha(string email, UpdateSenhaContaInputModel model)
        {
            var result = _contaService.MudarSenha(email, model);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("Login")]
        public IActionResult Login(string email, string senha)
        {
            var result = _contaService.Login(email, senha);

            if (!result.IsSuccess)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

    }
}
