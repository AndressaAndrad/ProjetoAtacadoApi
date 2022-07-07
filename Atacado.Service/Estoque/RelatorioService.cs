using Atacado.EF.Database;
using Atacado.Repository.Estoque;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class RelatorioService
    {
        private CategoriaRepository categorioRepo;

        private SubcategoriaRepository subcategorioRepo;

        private ProdutoRepository produtoRepo;

        private AtacadoContext contexto;

        public RelatorioService()
        {
            this.categorioRepo = new CategoriaRepository(this.contexto);
            this.subcategorioRepo = new SubcategoriaRepository(this.contexto);
            this.produtoRepo = new ProdutoRepository(this.contexto);
            this.contexto = new AtacadoContext();
        }

        public List<RelatorioPoco> CategoriaPorID(int IdCat)
        {

            var pesquisa =
             (from cats in this.contexto.Categorias
              join subs in this.contexto.Subcategorias on cats.IdCategoria equals subs.IdCategoria
              join prots in this.contexto.Produtos on subs.IdCategoria equals prots.IdCategoria
              where cats.IdCategoria == IdCat
              select new RelatorioPoco
              {
                  IdCategoria = cats.IdCategoria,
                  DescricaoCategoria = cats.DescricaoCategoria,
                  IdSubcategoria = subs.IdSubcategoria,
                  DescricaoSubcategoria = subs.DescricaoSubcategoria,
                  IdProduto = prots.IdProduto,
                  DescricaoProduto = prots.DescricaoProduto
              }).ToList();
            return pesquisa;
       
        }

        public List<RelatorioPoco> SubcategoriaPorID(int IdSub)
        {

            var pesquisa =
             (from subs in this.contexto.Subcategorias
              join cats in this.contexto.Categorias on subs.IdCategoria equals cats.IdCategoria
              join prots in this.contexto.Produtos on subs.IdSubcategoria equals prots.IdSubcategoria
              where subs.IdSubcategoria == IdSub
              select new RelatorioPoco
              {
                  IdCategoria = cats.IdCategoria,
                  DescricaoCategoria = cats.DescricaoCategoria,
                  IdSubcategoria = subs.IdSubcategoria,
                  DescricaoSubcategoria = subs.DescricaoSubcategoria,
                  IdProduto = prots.IdProduto,
                  DescricaoProduto = prots.DescricaoProduto

              }).ToList();
            return pesquisa;

        }

        public List<RelatorioPoco> ProdutoPorID(int IdProt)
        {

            var pesquisa =
             (from prots in this.contexto.Produtos
              join subs in this.contexto.Subcategorias on prots.IdSubcategoria equals subs.IdSubcategoria
              join cats in this.contexto.Categorias on subs.IdCategoria equals cats.IdCategoria
              where prots.IdProduto == IdProt
              select new RelatorioPoco
              {
                  IdCategoria = cats.IdCategoria,
                  DescricaoCategoria = cats.DescricaoCategoria,
                  IdSubcategoria = subs.IdSubcategoria,
                  DescricaoSubcategoria = subs.DescricaoSubcategoria,
                  IdProduto = prots.IdProduto,
                  DescricaoProduto = prots.DescricaoProduto
              }).ToList();
            return pesquisa;

        }

    }

}   