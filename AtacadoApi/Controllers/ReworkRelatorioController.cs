using Atacado.Service.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReworkRelatorioController : ControllerBase
    {
        private RelatorioService servico;

        public ReworkRelatorioController() : base()
        {
            this.servico = new RelatorioService();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCat"></param>
        /// <returns></returns>

        [HttpGet("Categoria/PorID/{IdCat:int}")]
        public ActionResult<List<RelatorioPoco>> GetRelatorioPorCategoriaID(int IdCat)
        {
            try
            {
                List<RelatorioPoco> resposta = this.servico.CategoriaPorID(IdCat);
                return Ok(resposta);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdSub"></param>
        /// <returns></returns>

        [HttpGet("Subcategoria/PorID/{IdSub:int}")]
        public ActionResult<List<RelatorioPoco>> GetRelatorioPorSubcategoriaID(int IdSub)
        {
            try
            {
                List<RelatorioPoco> resposta = this.servico.SubcategoriaPorID(IdSub);
                return Ok(resposta);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("Produto/PorID/{IdProd:int}")]
        public ActionResult<List<RelatorioPoco>> GetRelatorioPorProdutoID(int IdProd)
        {
            try
            {
                List<RelatorioPoco> resposta = this.servico.ProdutoPorID(IdProd);
                return Ok(resposta);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }
        }

    }   }   
