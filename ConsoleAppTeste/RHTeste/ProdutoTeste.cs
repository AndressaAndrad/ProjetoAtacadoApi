using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.RHTeste
{
    public class ProdutoTeste
    {
        public void Executar()
        {
            ProdutoService srv = new ProdutoService();
            List<ProdutoPoco> listaPoco = srv.Listar();
            foreach (ProdutoPoco poco in listaPoco)
            {
                Console.WriteLine("Codigo Produto: {0} Codigo Subcategoria: {1} - Codigo Categoria: {2}  - {3} - {4}", poco.IdProduto,poco.IdSubcategoria, poco.IdCategoria, poco.DescricaoProduto, poco.Situacao);
                Console.WriteLine("----------------------------------------------------------------------");
            }
        }
    }
}
