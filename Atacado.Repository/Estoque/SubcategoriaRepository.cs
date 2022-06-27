using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Estoque
{
    public class SubcategoriaRepository :
        BaseRepository<Subcategoria>
    {
        public SubcategoriaRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override Subcategoria DeleteById(int id)
        {
            Subcategoria subcategoria = this.Read(id);
            this.context.Set<Subcategoria>().Remove(subcategoria);
            this.context.SaveChanges();
            return subcategoria;
        }
    }
}
