using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Repository.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class IdiomaService : BaseAncestralService<IdiomaPoco, Idioma>
    {
       private IdiomaRepository repositorio;

        public IdiomaService()
        {
            this.mapeador = new MapeadorGenerico<IdiomaPoco, Idioma>();
            this.repositorio = new IdiomaRepository(new AtacadoContext());
        }
        public IdiomaService(AtacadoContext contexto)
        {
            this.mapeador = new MapeadorGenerico<IdiomaPoco, Idioma>();
            this.repositorio = new IdiomaRepository(contexto);
        }

        public override List<IdiomaPoco> Listar()
        {

            List<Idioma> listDOM = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDOM);
        }
        protected override List<IdiomaPoco> ProcessarListaDOM(List<Idioma> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<IdiomaPoco>(dom)).ToList();
        }

        public override IdiomaPoco Selecionar(int id)
        {

            Idioma dom = this.repositorio.Read(id);
            IdiomaPoco poco = this.mapeador.Mecanismo.Map<IdiomaPoco>(dom);
            return poco;
        }

        public override IdiomaPoco Criar(IdiomaPoco obj)
        {
            Idioma dom = this.mapeador.Mecanismo.Map<Idioma>(obj);
            Idioma criado = this.repositorio.Add(dom);
            IdiomaPoco poco = this.mapeador.Mecanismo.Map<IdiomaPoco>(criado);
            return poco;

        }
        public override IdiomaPoco Atualizar(IdiomaPoco obj)
        {
            Idioma dom = this.mapeador.Mecanismo.Map<Idioma>(obj);
            Idioma atualizado = this.repositorio.Edit(dom);
            IdiomaPoco poco = this.mapeador.Mecanismo.Map<IdiomaPoco>(atualizado);
            return poco;
        }
        public override IdiomaPoco Excluir(IdiomaPoco obj)
        {
            return this.Excluir(obj.IdIdioma);
        }
        public override IdiomaPoco Excluir(int id)
        {
            Idioma excluido = this.repositorio.DeleteById(id);
            IdiomaPoco poco = this.mapeador.Mecanismo.Map<IdiomaPoco>(excluido);
            return poco;
        }
    }
}
