using Atacado.Poco.Estoque;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTeste.RHTeste
{
    public class CategoriaTeste
    {
        public void Executar()
        {
            CategoriaService srv = new CategoriaService();
            List<CategoriaPoco> listaPoco = srv.Listar();
            foreach (CategoriaPoco poco in listaPoco)
            {
                Console.WriteLine("Codigo: {0} - {1} - {2}", poco.Codigo, poco.Descricao, poco.Situacao);
                Console.WriteLine("---------------------------");
            }
        }
    }
}
