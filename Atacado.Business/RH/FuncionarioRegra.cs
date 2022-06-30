using Atacado.Business.Ancestral;
using Atacado.Poco.RH;

namespace Atacado.Business.RH
{

    public class FuncionarioRegra : RuleAncestor<FuncionarioPoco>, IRule
    {
        public FuncionarioRegra() : base()
        { }
        public FuncionarioRegra(FuncionarioPoco poco) : base(poco)
        { }

        public override bool Process()
        {
            bool resultado = true;

            string mensagemProcessamento = string.Empty;
            if (RegraGenericas.NomeRegra(this.poco.NomeFuncionario, ref mensagemProcessamento) == false)
            {
                this.ruleMessages.Add(mensagemProcessamento);
                resultado = false;
            }
            if (RegraGenericas.SobrenomeRegra(this.poco.SobrenomeFuncionario, ref mensagemProcessamento) == false)
            {
                this.ruleMessages.Add(mensagemProcessamento);
                resultado = false;
            }
            if (RegraGenericas.SexoRegra(this.poco.Sexo, ref mensagemProcessamento) == false)
            {
                this.ruleMessages.Add(mensagemProcessamento);
                resultado = false;
            }
            if (RegraGenericas.EmailRegra(this.poco.EmailFuncionario, ref mensagemProcessamento) == false)
            {
                this.ruleMessages.Add(mensagemProcessamento);
                resultado = false;
            }
            
                return resultado;
        }
        






    }
}
