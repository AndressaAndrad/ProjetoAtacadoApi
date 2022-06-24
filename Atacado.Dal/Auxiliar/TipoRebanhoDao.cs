using Atacado.Dal.Ancestral;
using Atacado.EF.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Dal.Auxiliar
{
    public class TipoRebanhoDao : BaseAncestralDao<TipoRebanho>
    {
        public TipoRebanhoDao() : base()
        { }
        public override TipoRebanho Create(TipoRebanho obj)
        {

            contexto.TipoRebanhos.Add(obj);
            contexto.SaveChanges();
            return obj;
        }

        public override TipoRebanho Read(int id)
        {
            TipoRebanho obj = contexto.TipoRebanhos.SingleOrDefault(cat => cat.IDTipo == id);
            return obj;
        }

        public override List<TipoRebanho> ReadAll()
        {
            return contexto.TipoRebanhos.ToList();

        }
       

        public override TipoRebanho Update(TipoRebanho obj)
        {
            TipoRebanho alt = Read(obj.IDTipo);
            alt.Descricao = obj.Descricao;
            contexto.SaveChanges();
            return obj;

        }
        public override TipoRebanho Delete(int id)
        {
            TipoRebanho del = Read(id);
            contexto.TipoRebanhos.Remove(del);
            contexto.SaveChanges();
            return del;
        }

        public override TipoRebanho Delete(TipoRebanho obj)
        {
            return Delete(obj.IDTipo);
        }

    }
}
