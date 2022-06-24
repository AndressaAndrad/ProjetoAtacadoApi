using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Poco.Auxiliar
{
    public class RebanhoPoco
    {
        public int IDRebanho { get; set; }
        public int AnoRef { get; set; }
        public int IDMunicipio { get; set; }
        public int IDTipoRebanho { get; set; }
        public string TipoRebanho { get; set; }
        public int? Quantidade { get; set; }
        public bool? Situacao { get; set; }
    }
}
