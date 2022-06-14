using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Atacado.EF.Database
{
    [Table("Tipo_Logradouro")]
    public partial class TipoLogradouro
    {
        [Key]
        [Column("ID_Tipo_Logradouro")]
        public int IdTipoLogradouro { get; set; }
        [Column("Tipo_Logradouro")]
        [Unicode(false)]
        public string TipoLogradouro1 { get; set; } = null!;
        public bool? Situacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }
    }
}
