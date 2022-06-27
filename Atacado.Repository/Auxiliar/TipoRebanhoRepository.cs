using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class TipoRebanhoRepository
        : BaseRepository<TipoRebanho>
    {
        public TipoRebanhoRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override TipoRebanho DeleteById(int id)
        {
            TipoRebanho tiporebanho = this.Read(id);
            this.context.Set<TipoRebanho>().Remove(tiporebanho);
            this.context.SaveChanges();
            return tiporebanho;
        }
    }
}
