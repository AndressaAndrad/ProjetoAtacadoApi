using Atacado.EF.Database;
using Atacado.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Ancestral;
using Atacado.Repository.Auxiliar;
using Atacado.Mapper.Auxiliar;

namespace Atacado.Mapper
{
    public class TipoRebanhoService : BaseAncestralService<TipoRebanhoPoco, TipoRebanho>
    {
        
        private TipoRebanhoRepository repositorio;
        public TipoRebanhoService()
        {
            this.mapeador = new MapeadorGenerico<TipoRebanhoPoco, TipoRebanho>();
            this.repositorio = new TipoRebanhoRepository(new AtacadoContext());
        }
        public TipoRebanhoService(AtacadoContext contexto)
        {
            this.mapeador = new MapeadorGenerico<TipoRebanhoPoco, TipoRebanho>();
            this.repositorio = new TipoRebanhoRepository(contexto);
        }

        public override List<TipoRebanhoPoco> Listar()
        {

            List<TipoRebanho> listDOM = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDOM);
        }
        protected override List<TipoRebanhoPoco> ProcessarListaDOM(List<TipoRebanho> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<TipoRebanhoPoco>(dom)).ToList();
        }


        public override TipoRebanhoPoco Selecionar(int id)
        {
            TipoRebanho dom = this.repositorio.Read(id);
            TipoRebanhoPoco poco = this.mapeador.Mecanismo.Map<TipoRebanhoPoco>(dom);
            return poco;
        }
        public override TipoRebanhoPoco Criar(TipoRebanhoPoco obj)
        {
            TipoRebanho dom = this.mapeador.Mecanismo.Map<TipoRebanho>(obj);
            TipoRebanho criado = this.repositorio.Add(dom);
            TipoRebanhoPoco poco = this.mapeador.Mecanismo.Map<TipoRebanhoPoco>(criado);
            return poco;

        }
        public override TipoRebanhoPoco Atualizar(TipoRebanhoPoco obj)
        {
            TipoRebanho dom = this.mapeador.Mecanismo.Map<TipoRebanho>(obj);
            TipoRebanho atualizado = this.repositorio.Edit(dom);
            TipoRebanhoPoco poco = this.mapeador.Mecanismo.Map<TipoRebanhoPoco>(atualizado);
            return poco;
        }
        public override TipoRebanhoPoco Excluir(TipoRebanhoPoco obj)
        {
            return this.Excluir(obj.IDTipo);
        }
        public override TipoRebanhoPoco Excluir(int id)
        {
            TipoRebanho excluido = this.repositorio.DeleteById(id);
            TipoRebanhoPoco poco = this.mapeador.Mecanismo.Map<TipoRebanhoPoco>(excluido);
            return poco;
        }
    }
}
