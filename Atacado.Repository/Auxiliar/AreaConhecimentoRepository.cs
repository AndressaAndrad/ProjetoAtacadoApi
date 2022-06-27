using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class AreaConhecimentoRepository
        : BaseRepository<AreaConhecimento>
    {
        public AreaConhecimentoRepository(AtacadoContext contexto) 
            : base(contexto)
        { }

        public override AreaConhecimento DeleteById(int id)
        {
            AreaConhecimento areaconhecimento = this.Read(id);
            this.context.Set<AreaConhecimento>().Remove(areaconhecimento);
            this.context.SaveChanges();
            return areaconhecimento;
        }

        public override AreaConhecimento Read(int id)
        {
            return this.context.Set<AreaConhecimento>().Find(id);
        }
    }
}
