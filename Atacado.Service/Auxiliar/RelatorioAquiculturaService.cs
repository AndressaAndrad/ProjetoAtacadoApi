
using Atacado.EF.Database;
using Atacado.Poco.Auxiliar;

namespace Atacado.Service.Auxiliar
{
    public class RelatorioAquiculturaService
    {
        private AtacadoContext contexto;

        public RelatorioAquiculturaService()
        {
            this.contexto = new AtacadoContext();   
        }

        public List<RelatorioAquiculturaPoco> AquiculturaPorIDeAno(int IdMun, int AnoRef)
        {
            var pesquisa =
                (from aqui in this.contexto.Aquiculturas
                 join tipoa in this.contexto.TipoAquiculturas on aqui.IdTipoAquicultura equals tipoa.IdTipoAquicultura
                 join muns in this.contexto.Municipios on aqui.IdMunicipio equals muns.CodigoIbge6
                 join uni in this.contexto.UnidadesFederacaos on muns.SiglaUf equals uni.SiglaUf
                 where ((aqui.IdMunicipio == IdMun) && (aqui.Ano == AnoRef) && (aqui.Producao != null))
                 select new RelatorioAquiculturaPoco
                 {
                     IdAquicultura = aqui.IdAquicultura,
                     Ano = aqui.Ano,
                     IdTipoAquicultura = aqui.IdTipoAquicultura,
                     DescricaoTipoAquicultura = tipoa.DescricaoTipoAquicultura,
                     Producao = aqui.Producao,
                     ValorProducao = aqui.ValorProducao,
                     ProporcaoValorProducao = aqui.ProporcaoValorProducao,
                     Moeda = aqui.Moeda,
                     IdMunicipio = aqui.IdMunicipio,
                     nomemunicipio = muns.NomeMunicipio,
                     siglauf = muns.SiglaUf,
                     nomeuf = uni.SiglaUf

                 }).ToList();
            return pesquisa; ;

        }

        public List<RelatorioAquiculturaPoco> AquiculturaPorTipoeAno(int TipoA, int AnoRef, int IdMun)
        {
            var pesquisa =
                (from aqui in this.contexto.Aquiculturas
                 join tipoa in this.contexto.TipoAquiculturas on aqui.IdTipoAquicultura equals tipoa.IdTipoAquicultura
                 join muns in this.contexto.Municipios on aqui.IdMunicipio equals muns.CodigoIbge6
                 join uni in this.contexto.UnidadesFederacaos on muns.SiglaUf equals uni.SiglaUf
                 where ((aqui.IdTipoAquicultura == TipoA) && (aqui.Ano == AnoRef) && (aqui.IdMunicipio == IdMun))
                 select new RelatorioAquiculturaPoco
                 {
                     IdAquicultura = aqui.IdAquicultura,
                     Ano = aqui.Ano,
                     IdTipoAquicultura = aqui.IdTipoAquicultura,
                     DescricaoTipoAquicultura = tipoa.DescricaoTipoAquicultura,
                     Producao = aqui.Producao,
                     ValorProducao = aqui.ValorProducao,
                     ProporcaoValorProducao = aqui.ProporcaoValorProducao,
                     Moeda = aqui.Moeda,
                     IdMunicipio = aqui.IdMunicipio,
                     nomemunicipio = muns.NomeMunicipio,
                     siglauf = muns.SiglaUf,
                     nomeuf = uni.SiglaUf

                 }).ToList();
            return pesquisa; ;

        }
    }
}
