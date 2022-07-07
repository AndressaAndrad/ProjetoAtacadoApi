using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Estoque
{
    public class RelatorioPoco
    {
        public int IdCategoria { get; set; }
        public string DescricaoCategoria { get; set; }
        public int IdSubcategoria { get; set; }
        public string DescricaoSubcategoria { get; set; } = null!;
        public int IdProduto { get; set; }
        public string DescricaoProduto { get; set; } = null!;
        public bool? Situacao { get; set; }
    }
}
