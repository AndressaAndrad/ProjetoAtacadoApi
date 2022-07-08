using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class TipoAquiculturaRepository
        : BaseRepository<TipoAquicultura>

    {
        public TipoAquiculturaRepository(DbContext context) : base(context)
        {
        }

        public override TipoAquicultura DeleteById(int id)
        {
            TipoAquicultura tipoaquicultura = this.Read(id);
            this.context.Set<TipoAquicultura>().Remove(tipoaquicultura);
            this.context.SaveChanges();
            return tipoaquicultura;
        }
    }
}
