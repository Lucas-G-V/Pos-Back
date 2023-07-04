using AutoMapper;
using MarmitariaReal.Domain.Entities;
using MarmitariaReal.Domain.Interfaces.Services;
using MarmitariaReal.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MarmitariaReal.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitasService _receitasService;

        public ReceitasController(IReceitasService receitasService, IMapper mapper)
        {
            _receitasService = receitasService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReceitaViewModel>> ObterPorId(Guid id)
        {
            var receita= await _receitasService.GetById(id);

            if (receita == null) return NotFound();

            return receita;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ReceitaViewModel>>> ObterTodos()
        {
            var receita = await _receitasService.GetAll();

            if (receita == null) return NotFound();

            return Ok(receita);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Insert([FromForm] ReceitaViewModel receita)
        {
          return Ok(await _receitasService.Insert(receita));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<int>> Update(Guid id, [FromForm] ReceitaEditViewModel receita)
        {
            var result = await _receitasService.GetById(id);
            if(result == null || receita.ReceitaId != id) return NotFound();
            return Ok(await _receitasService.Update(receita));

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<int>> Delete(Guid id)
        {
            var result = await _receitasService.GetById(id);
            if (result == null) return NotFound();
            return Ok(await _receitasService.Delete(id));
        }
    }
}
