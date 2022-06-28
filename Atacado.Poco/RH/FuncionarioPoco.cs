namespace Atacado.Poco.RH
{
    public class FuncionarioPoco
    {
        public long IdFuncionario { get; set; }
        public long IdFuncionarioDadosEmpresa { get; set; }
        public long MatriculaFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public string SobrenomeFuncionario { get; set; }
        public string Sexo { get; set; }
        public DateTime DatanascFuncionario { get; set; }
        public string EmailFuncionario { get; set; }
        public DateTime DataAdmissaoFuncionario { get; set; }
        public string CTPS { get; set; }

        public long CTPSNum { get; set; }
        public int CTPSSerie { get; set; }
        public bool? Situacao { get; set; }
    }
}
