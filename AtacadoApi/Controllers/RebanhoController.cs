using Atacado.Poco.Auxiliar;
using Atacado.Service.Auxiliar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/auxiliar/[controller]")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {
        private RebanhoService servico;
        public RebanhoController() : base()
        {
            this.servico = new RebanhoService();
        }
        /// <summary>
        ///  Realiza a busca por todos os registros, filtrando onde inicia(skip) e a quantidade(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns> Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<RebanhoPoco>> Get(int skip, int take)
        {
            try
            {
                List<RebanhoPoco> listaResposta = this.servico.Listar(skip, take);
                return Ok(listaResposta);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        /// <summary>
        /// Realiza a busca por todos os registro onde traz apenas um pelo Codigo(id).
        /// </summary>
        /// <param name="id">Busca por um codigo</param>
        /// <returns>Dados selecionado.</returns>
        [HttpGet("{id:int}")]
        public ActionResult<RebanhoPoco> Get(int id)
        {
            try
            {
                RebanhoPoco pocoResposta = this.servico.Selecionar(id);
                return Ok(pocoResposta);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        /// <summary>
        /// Realiza busca por todos os registros, filtrando por ano referencia(anoRef) e codigo do municipio(idMun) 
        /// </summary>
        /// <param name="anoRef">Comeca pesquisa pelo o ano da referencia.</param>
        /// <param name="idMun">Quantos registros serão retornados junto com o ano.</param>
        /// <returns>Colecão de Dados.</returns>
        [HttpGet("anoref/{anoRef:int}/idmun/{idMun:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorAnoRefIdMun( int anoRef, int idMun)
        {
            try
            {
               List<RebanhoPoco> lista = this.servico.FiltrarPorAnoRefIdMun(anoRef, idMun);
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message, statusCode : StatusCodes.Status500InternalServerError );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RebanhoPoco> Post([FromBody] RebanhoPoco poco)
        {
            try
            {
               RebanhoPoco pocoResposta =  this.servico.Criar(poco);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<RebanhoPoco> Put([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco pocoResposta = this.servico.Atualizar(poco);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>

        [HttpDelete]
        public ActionResult<RebanhoPoco> Delete([FromBody] RebanhoPoco poco)
        {
            try
            {
               RebanhoPoco pocoResposta = this.servico.Excluir(poco);
                return Ok(pocoResposta);
            }
            catch( Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public ActionResult<RebanhoPoco> DeletePorId(int id)
        {

            try
            {
                RebanhoPoco pocoResposta = this.servico.Excluir(id);
                return Ok(pocoResposta);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

            }
    }
}
