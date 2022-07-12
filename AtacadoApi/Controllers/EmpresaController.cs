using Atacado.EF.Database;
using Atacado.Envelope.RH;
using Atacado.Poco.RH;
using Atacado.Service.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/rh/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {/// <summary>
    /// 
    /// </summary>
        private EmpresaService servico;
        /// <summary>
        /// 
        /// </summary>
        public EmpresaController(AtacadoContext contexto) : base()
        {
            this.servico = new EmpresaService(contexto);
        }
        /// <summary>
        /// Busca pela empresa por todos os registros, filtrando onde inicia(skip) e a quantidade(take)
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take"> Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<EmpresaEnvelopeJSON>> GetAll(int skip, int take)
        {
            try
            {
                List<EmpresaEnvelopeJSON> lista = this.servico.Listar(skip, take);
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

            //return this.servico.Listar(skip, take);
        }
        /// <summary>
        /// Realiza busca pela chave de registro(id).
        /// </summary>
        /// <param name="id">Chave de registro</param>
        /// <returns></returns>

        [HttpGet("{id:int}")]
        public ActionResult<EmpresaEnvelopeJSON> Get(int id)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Selecionar(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
            //return this.servico.Selecionar(id);
        }
        /// <summary>
        /// CRiar um registro no recurso.
        /// </summary>
        /// <param name="poco"> Registro que será criado.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<EmpresaEnvelopeJSON> Post([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Criar(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Atauliza um registro no recurso.
        /// </summary>
        /// <param name="poco">Registro alterado</param>
        /// <returns>Retorna registro alterado.</returns>
        [HttpPut]
        public ActionResult<EmpresaEnvelopeJSON> Put([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Atualizar(poco);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
            //return this.servico.Atualizar(poco);
        }
        /// <summary>
        /// Registro que deseja excluir.
        /// </summary>
        /// <param name="poco">Registro para excluir.</param>
        /// <returns>Retornas o registro excluido.</returns>
        [HttpDelete]
        public ActionResult<EmpresaEnvelopeJSON> Delete([FromBody] EmpresaPoco poco)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Excluir(poco); ;
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
            
        }
        /// <summary>
        /// Exclui o registro pelo Codigo(id).
        /// </summary>
        /// <param name="id">Exclui o codigo desejado.</param>
        /// <returns>Item excluido.</returns>
        [HttpDelete("{id:int}")]
        public ActionResult<EmpresaEnvelopeJSON> Delete(int id)
        {
            try
            {
                EmpresaEnvelopeJSON envelope = this.servico.Excluir(id);
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
            
        }
    }
}
