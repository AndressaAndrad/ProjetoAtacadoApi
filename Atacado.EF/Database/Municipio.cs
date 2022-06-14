using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Municipio")]
    public partial class Municipio
    {
        [Key]
        [Column("ID_Municipio")]
        public int IdMunicipio { get; set; }
        [Column("IBGE_7")]
        public int Ibge7 { get; set; }
        [Column("IBGE_6")]
        public int Ibge6 { get; set; }
        [Column("Nome_Municipio")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomeMunicipio { get; set; } = null!;
        [Column("ID_UF")]
        public int IdUf { get; set; }
        [Column("SiglaUF")]
        [StringLength(2)]
        [Unicode(false)]
        public string SiglaUf { get; set; } = null!;
        public int Mesoregiao { get; set; }
        public int Microregiao { get; set; }
        [Column("Populacao_Municipio")]
        public int? PopulacaoMunicipio { get; set; }
        [Column("Porte_Municipio")]
        [StringLength(50)]
        [Unicode(false)]
        public string PorteMunicipio { get; set; } = null!;
        [Column("Cep_Municipio")]
        public int? CepMunicipio { get; set; }
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }

        [ForeignKey("IdUf")]
        [InverseProperty("Municipios")]
        public virtual UnidadesFederacao IdUfNavigation { get; set; } = null!;
    }
}
