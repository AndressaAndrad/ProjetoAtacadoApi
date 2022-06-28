using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.RH
{
    public class FuncionarioRepository : BaseRepository<Funcionario>
    {
        public FuncionarioRepository(AtacadoContext contexto) 
            : base(contexto)
        { }

        public override Funcionario DeleteById(int id)
        {
            Funcionario funcionario = this.Read(id);
            this.context.Set<Funcionario>().Remove(funcionario);
            this.context.SaveChanges();
            return funcionario;
        }
    }
}
