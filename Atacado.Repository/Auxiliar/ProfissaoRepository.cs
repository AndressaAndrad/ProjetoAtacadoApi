using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class ProfissaoRepository
        : BaseRepository<Profissao>
    {
        public ProfissaoRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override Profissao DeleteById(int id)
        {
            Profissao profissao = this.Read(id);
            this.context.Set<Profissao>().Remove(profissao);
            this.context.SaveChanges();
            return profissao;
        }
    }
}
