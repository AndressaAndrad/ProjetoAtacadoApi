

using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.RH
{
    public class EmpresaRepository : BaseRepository<Empresa>
    {
        public EmpresaRepository(AtacadoContext contexto) 
            : base(contexto)
        { }

        public override Empresa DeleteById(int id)
        {
            Empresa empresa = this.Read(id);
            this.context.Set<Empresa>().Remove(empresa);
            this.context.SaveChanges();
            return empresa;
        }
    }
}
