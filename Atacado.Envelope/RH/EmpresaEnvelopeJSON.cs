﻿using Atacado.Envelope.Ancestral;
using Newtonsoft.Json;

namespace Atacado.Envelope.RH
{
    public class EmpresaEnvelopeJSON : BaseEnvelopeJSON
    {
        [JsonProperty(PropertyName = "codigo")]
        public int Id_Empresa { get; set; }

        [JsonProperty(PropertyName = "razaosocila")]
        public string RazaoSocial { get; set; }
        [JsonProperty(PropertyName = "nomefantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty(PropertyName = "cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty(PropertyName = "ie")]
        public string InscricaoEstadual { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "endereco")]
        public string Endereco { get; set; }


        public override void SetLinks()
        {
            this.Links.List = "GET /empresa ";
            this.Links.Self = "GET /empresa /" + this.Id_Empresa.ToString();
            this.Links.Exclude = "DELETE /empresa / " + this.Id_Empresa.ToString();
            this.Links.Update = "PUT /empresa ";
            this.Links.Create = "POST /empresa ";

        }
    }
}
