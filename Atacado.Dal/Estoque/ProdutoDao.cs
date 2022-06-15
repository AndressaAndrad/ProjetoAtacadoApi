using Atacado.Dal.Ancestral;
using Atacado.EF.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dal.Estoque
{
    public class ProdutoDao : BaseAncestralDao<Produto>
    {
       
        public ProdutoDao() : base()
        { }
        public override Produto Create(Produto obj)
        {
            int chave = this.contexto.Produtos.Max(cat => cat.IdProduto) + 1;
            obj.IdProduto = chave;
            this.contexto.Produtos.Add(obj);
            this.contexto.SaveChanges();
            return obj;
        }

        public override Produto Read(int id)
        {
            Produto obj = this.contexto.Produtos.SingleOrDefault(cat => cat.IdProduto == id);
            return obj;
        }

        public override List<Produto> ReadAll()
        {
            return this.contexto.Produtos.ToList();

        }

        public override Produto Update(Produto obj)
        {
            Produto alt = this.Read(obj.IdProduto);
            alt.IdCategoria = obj.IdCategoria;
            alt.IdSubcategoria = obj.IdSubcategoria;
            alt.DescricaoProduto = obj.DescricaoProduto;
            alt.Situacao = obj.Situacao;
            this.contexto.SaveChanges();
            return obj;

        }
        public override Produto Delete(int id)
        {
            Produto del = this.Read(id);
            this.contexto.Produtos.Remove(del);
            this.contexto.SaveChanges();
            return del;
        }

        public override Produto Delete(Produto obj)
        {
            return this.Delete(obj.IdProduto);
        }

    }
}
