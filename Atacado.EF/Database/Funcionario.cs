using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.EF.Database
{
    [Table("Funcionario")]
    public partial class Funcionario
    {
        [Key]
        [Column("ID_Funcionario")]
        public long IdFuncionario { get; set; }


        [Column("ID_FuncDadosEmpresa")]
        public long IdFuncionarioDadosEmpresa { get; set; }


        [Column("Matricula_Funcionario")]
        public long MatriculaFuncionario { get; set; }


        [Column ("Nome_Funcionario")]
        public string NomeFuncionario { get; set; }


        [Unicode(false)]
        [Column ("Sobrenome_Funcionario")]
	    public string SobrenomeFuncionario { get; set; }


        [Unicode(false)]
        [Column("Sexo_Funcionario")]
        [StringLength(1)]
        public string Sexo { get; set; }


        [Column("Datanasc_Funcionario", TypeName = "datetime")]
        public DateTime DatanascFuncionario { get; set; }


        [Column("Email_Funcionario")]
        [Unicode(false)]
        public string EmailFuncionario { get; set; }


        [Column("Data_Admissao_Funcionario", TypeName = "datetime")]
        public DateTime DataAdmissaoFuncionario { get; set; }


        [Column("Ctps_Funcionario")]
        [StringLength(50)]
        [Unicode(false)]
        public string CTPS { get; set; }


        [Column("Ctps_Num_Funcionario")]
        public long CTPSNum { get; set; }


        [Column("Ctps_Serie_Funcionario")]
        public int CTPSSerie { get; set; }


        public bool? Situacao { get; set; }
        public DateTime? DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAlteracao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataExclusao { get; set; }


    }
}
