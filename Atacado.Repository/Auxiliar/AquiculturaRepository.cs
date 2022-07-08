using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class AquiculturaRepository
        : BaseRepository<Aquicultura>

    {
        public AquiculturaRepository(DbContext context) : base(context)
        {
        }

        public override Aquicultura DeleteById(int id)
        {
            Aquicultura aquicultura = this.Read(id);
            this.context.Set<Aquicultura>().Remove(aquicultura);
            this.context.SaveChanges();
            return aquicultura;
        }
    }
    
}
