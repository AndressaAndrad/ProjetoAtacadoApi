using Atacado.Envelope.Ancestral;
using Newtonsoft.Json;

namespace Atacado.Envelope.Auxiliar
{
    public class TipoAquiculturaEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IdTipoAquicultura { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string DescricaoTipoAquicultura { get; set; }

        [JsonProperty(PropertyName = "situacao")]
        public bool? Situacao { get; set; }

        public override void SetLinks()
        {
            this.Links.List = "GET /tipoaquicultura ";
            this.Links.Self = "GET /tipoaquicultura /" + this.IdTipoAquicultura.ToString();
            this.Links.Exclude = "DELETE /tipoaquicultura / " + this.IdTipoAquicultura.ToString();
            this.Links.Update = "PUT /tipoaquicultura ";
            this.Links.Create = "POST /tipoaquicultura ";

        }
    }
}
