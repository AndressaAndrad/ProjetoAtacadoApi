using Atacado.EF.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

///POG (programa Orientado a Gambiarra)
///usar em ultimo caso.
///
namespace AtacadoApi.Controllers
{   
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        /// <summary>
        /// Busca um registro completo de rebanho pelo Código(idRebanho)
        /// </summary>
        /// <param name="idRebanho"> Chave de registro. </param>
        /// <returns>Retorna registro selecionado.</returns>
        [HttpGet ("fichacadastral/{idRebanho:int}") ]
        public ActionResult<object> Get(int idRebanho)

        {
            
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from rebs in contexto.Rebanhos
                    where rebs.IDRebanho == idRebanho
                    join muns in contexto.Municipios on rebs.IDMunicipio equals muns.CodigoIbge6
                    join ufs in contexto.UnidadesFederacaos on muns.SiglaUf equals ufs.SiglaUf
                    select new
                    {

                        IdRebanho = rebs.IDRebanho,
                        AnoReferencia = rebs.AnoRef,
                        IdMunicipio = rebs.IDMunicipio,
                        NomeMunicipio = muns.NomeMunicipio,
                        SiglaUF = ufs.SiglaUf,
                        NomeEstado = ufs.DescricaoUf,
                        IdTipoRebanho = rebs.IDTipoRebanho,
                        NomeRebanho = rebs.TipoRebanho,
                        Quantidade = rebs.Quantidade,
                        Situacao = rebs.Situacao

                    };
                return Ok(retorno);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }


            //Rebanho rebanho = contexto.Rebanhos.SingleOrDefault(reb => reb.IDRebanho == idRebanho);
            //if (rebanho != null)
            //{
            //    Municipio municipio = contexto.Municipios.SingleOrDefault(mun => mun.CodigoIbge6 == rebanho.IDMunicipio);
            //    if (municipio != null)
            //    {
            //        UnidadesFederacao estado = contexto.UnidadesFederacaos.SingleOrDefault(est => est.SiglaUf == municipio.SiglaUf);
            //        if (estado != null)
            //        {
            //            var retorno = new 
            //            {
            //                IdRebanho = rebanho.IDRebanho,
            //                AnoReferencia = rebanho.AnoRef,
            //                IdMunicipio = rebanho.IDMunicipio,
            //                NomeMunicipio = municipio.NomeMunicipio,
            //                SiglaUF = estado.SiglaUf,
            //                NomeEstado = estado.DescricaoUf,
            //                IdTipoRebanho = rebanho.IDTipoRebanho,
            //                NomeRebanho = rebanho.TipoRebanho,
            //                Quantidade = rebanho.Quantidade,
            //                Situacao = rebanho.Situacao

            //            };
            //            return Ok(retorno);
            //        }
            //        else
            //        {
            //            return Problem(" Estado não encontrado. ", statusCode: StatusCodes.Status400BadRequest);
            //        }

            //    }
            //    else
            //    {
            //        return Problem(" Munícipio não encontrado. ", statusCode: StatusCodes.Status400BadRequest);
            //    }

            //}
            //else
            //{
            //    return Problem(" Rebanho não encontrado. ", statusCode: StatusCodes.Status400BadRequest);
            //}

        }


        /// <summary>
        /// Realiza uma pesquisa filtrando Ano (anoRef) e Código(idMun) retornando uma lista do dados.
        /// </summary>
        /// <param name="anoRef">Ano que desaja buscar.</param>
        /// <param name="idMun">Codigo do IBGE.</param>
        /// <returns>Retorno da lista.</returns>
        /// 
        [HttpGet("Relatorio/{anoRef:int}/{idMun:int}")]

        public ActionResult<List<object>> GetPorAnoRefIdMun(int anoRef, int idMun)
        {
            //Lambida//
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from rebs in contexto.Rebanhos
                    where (rebs.AnoRef == anoRef) && (rebs.IDMunicipio == idMun)
                    join muns in contexto.Municipios on rebs.IDMunicipio equals muns.CodigoIbge6
                    join ufs in contexto.UnidadesFederacaos on muns.SiglaUf equals ufs.SiglaUf
                    select new
                    {

                        IdRebanho = rebs.IDRebanho,
                        AnoReferencia = rebs.AnoRef,
                        IdMunicipio = rebs.IDMunicipio,
                        NomeMunicipio = muns.NomeMunicipio,
                        SiglaUF = ufs.SiglaUf,
                        NomeEstado = ufs.DescricaoUf,
                        IdTipoRebanho = rebs.IDTipoRebanho,
                        NomeRebanho = rebs.TipoRebanho,
                        Quantidade = rebs.Quantidade,
                        Situacao = rebs.Situacao

                    };
                return Ok(retorno);

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }


        /// <summary>
        /// Realiza busca do relatorio por Codigo(IdCat).
        /// </summary>
        /// <param name="IdCat">Codigo de registro</param>
        /// <returns></returns>

        [HttpGet("Categoria/{IdCat:int}")]
        public ActionResult<List<object>> GetPorCategoria (int IdCat)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from cats in contexto.Categorias
                    where cats.IdCategoria == IdCat
                    join subs in contexto.Subcategorias on cats.IdCategoria equals subs.IdCategoria
                    join prots in contexto.Produtos on subs.IdSubcategoria equals prots.IdSubcategoria
                    select new
                    {
                        IdCategoria = cats.IdCategoria,
                        NomeCategoria = cats.DescricaoCategoria,
                        IdSubcategoria = subs.IdSubcategoria,
                        NomeSubcategoria = subs.DescricaoSubcategoria,
                        IdProduto = prots.IdProduto,
                        NomeProduto = prots.DescricaoProduto,
                        Situacao = prots.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Realiza busca do relatorio por Codigo(IdSub).
        /// </summary>
        /// <param name="IdSub">Codigo de registro</param>
        /// <returns>Lista de registro.</returns>

        [HttpGet("Subategoria/{IdSub:int}")]
        public ActionResult<List<object>> GetPorSubcategoria(int IdSub)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from subs in contexto.Subcategorias
                    where subs.IdSubcategoria == IdSub
                    join cats in contexto.Categorias on subs.IdCategoria equals cats.IdCategoria
                    join prots in contexto.Produtos on subs.IdSubcategoria equals prots.IdSubcategoria
                    
                    select new
                    {
                        IdCategoria = cats.IdCategoria,
                        NomeCategoria = cats.DescricaoCategoria,
                        IdSubcategoria = subs.IdSubcategoria,
                        NomeSubcategoria = subs.DescricaoSubcategoria,
                        IdProduto = prots.IdProduto,
                        NomeProduto = prots.DescricaoProduto,
                        Situacao = prots.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Realiza busca de um relatorio por Produto(IdProduto).
        /// </summary>
        /// <param name="IdProt">Codigo de registro</param>
        /// <returns></returns>
        [HttpGet("Produto/{IdProt:int}")]
        public ActionResult<List<object>> GetPorProduto(int IdProt)
        {
            AtacadoContext contexto = new AtacadoContext();
            try
            {
                var retorno =
                    from prots in contexto.Produtos
                    where prots.IdProduto == IdProt
                    join subs in contexto.Subcategorias on prots.IdSubcategoria equals subs.IdSubcategoria
                    join cats in contexto.Categorias on subs.IdCategoria equals cats.IdCategoria
                    

                    select new
                    {
                        IdCategoria = cats.IdCategoria,
                        NomeCategoria = cats.DescricaoCategoria,
                        IdSubcategoria = subs.IdSubcategoria,
                        NomeSubcategoria = subs.DescricaoSubcategoria,
                        IdProduto = prots.IdProduto,
                        NomeProduto = prots.DescricaoProduto,
                        Situacao = prots.Situacao
                    };
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status500InternalServerError);
            }

        }
    }
}
