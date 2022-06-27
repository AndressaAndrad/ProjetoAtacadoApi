using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Estoque
{
    public class ProdutoRepository
        : BaseRepository<Produto>
    {
        public ProdutoRepository(AtacadoContext contexto) : base(contexto)
        {
        }

        public override Produto DeleteById(int id)
        {
            Produto produto = this.Read(id);
            this.context.Set<Produto>().Remove(produto);
            this.context.SaveChanges();
            return produto;
        }
    }
}
