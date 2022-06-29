using Atacado.Business.Ancestral;

namespace Atacado.Business.RH
{
    public class TesteRegra : IRule
    {
        private List<string> ruleMessages;
        private List<string> RuleMessages => this.ruleMessages;

        public TesteRegra()
        {
            this.ruleMessages = new List<string>();
        }
        public bool Process()
        {
            throw new NotImplementedException();
        }

        private bool Regra01()
        { 
            
        }
        private bool Regra02()
        { }
        private bool Regra03()
        { }
        private bool Regra04()
        { }
        private bool Regra05()
        { }
    }
}
