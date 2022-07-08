using Atacado.Envelope.Ancestral;
using Newtonsoft.Json;

namespace Atacado.Envelope.Auxiliar
{
    public class AquiculturaEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IdAquicultura { get; set; }

        [JsonProperty(PropertyName = "ano")]
        public int Ano { get; set; }

        [JsonProperty(PropertyName = "idmunicipio")]
        public int IdMunicipio { get; set; }

        [JsonProperty(PropertyName = "tipoaquicultura")]
        public int IdTipoAquicultura { get; set; }

        [JsonProperty(PropertyName = "producao")]
        public int? Producao { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public int? ValorProducao { get; set; }

        [JsonProperty(PropertyName = "proprocaovalorproducao")]
        public double? ProporcaoValorProducao { get; set; }

        [JsonProperty(PropertyName = "moeda")]
        public string? Moeda { get; set; }

        public override void SetLinks()
        {
            Links.List = "GET /aquicultura ";
            Links.Self = "GET /aquicultura /" + IdAquicultura.ToString();
            Links.Exclude = "DELETE /aquicultura / " + IdAquicultura.ToString();
            Links.Update = "PUT /aquicultura ";
            Links.Create = "POST /aquicultura ";
        }
    }
}
