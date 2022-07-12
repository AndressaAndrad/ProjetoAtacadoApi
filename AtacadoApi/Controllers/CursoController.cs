using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private CursoService servico;
        public CursoController(AtacadoContext contexto) : base()
        {
            this.servico = new CursoService(contexto);
        }
        [HttpGet("{skip:int}/{take:int}")]
        public List<CursoPoco> GetAll(int skip, int take)
        {
            return this.servico.Listar(skip, take);
        }

        [HttpGet("{id:int}")]
        public CursoPoco GetByID(int id)
        {
            return this.servico.Selecionar(id);
        }
        [HttpPost]
        public CursoPoco Post([FromBody] CursoPoco poco)
        {
            return this.servico.Criar(poco);
        }
        [HttpPut]
        public CursoPoco Put([FromBody] CursoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }
        [HttpDelete]
        public CursoPoco Delete([FromBody] CursoPoco poco)
        {
            return this.servico.Excluir(poco);
        }
        [HttpDelete("{id:int}")]
        public CursoPoco Delete(int id)
        {
            return this.servico.Excluir(id);
        }
    }
}
