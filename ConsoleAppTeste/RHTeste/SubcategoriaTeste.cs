using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.RHTeste
{
    public class SubcategoriaTeste
    {
        public void Executar()
        {
            SubcategoriaService srv = new SubcategoriaService();
            List<SubcategoriaPoco> listaPoco = srv.Listar();
            foreach (SubcategoriaPoco poco in listaPoco)
            {
                Console.WriteLine("Codigo Subcategoria: {0} - Codigo Categoria: {1} - {2} - {3}", poco.IdSubcategoria, poco.IdCategoria, poco.DescricaoSubcategoria, poco.Situacao);
                Console.WriteLine("----------------------------------------------------------------------");
            }
        }
    }
}
