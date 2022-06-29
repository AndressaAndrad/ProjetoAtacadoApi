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
    public class CursoService : BaseAncestralService<CursoPoco, Curso>
    {
        
        private CursoRepository repositorio;

        public CursoService()
        {
            this.mapeador = new MapeadorGenerico<CursoPoco, Curso>();
            this.repositorio = new CursoRepository(new AtacadoContext());
        }
        public List<CursoPoco> Listar(int pular, int exibir)
        {
            List<Curso> listDOM = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDOM);

        }

        protected override List<CursoPoco> ProcessarListaDOM(List<Curso> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<CursoPoco>(dom)).ToList();
        }
        public override CursoPoco Selecionar(int id)
        {
            Curso dom = this.repositorio.Read(id);
            CursoPoco poco = this.mapeador.Mecanismo.Map<CursoPoco>(dom);
            return poco;
        }

        public override CursoPoco Criar(CursoPoco obj)
        {
            Curso dom = this.mapeador.Mecanismo.Map<Curso>(obj);
            Curso criado = this.repositorio.Add(dom);
            CursoPoco poco = this.mapeador.Mecanismo.Map<CursoPoco>(criado);
            return poco;
        }
        public override CursoPoco Atualizar(CursoPoco obj)
        {
            Curso dom = this.mapeador.Mecanismo.Map<Curso>(obj);
            Curso atualizado = this.repositorio.Edit(dom);
            CursoPoco poco = this.mapeador.Mecanismo.Map<CursoPoco>(atualizado);
            return poco;
        }
        public override CursoPoco Excluir(CursoPoco obj)
        {
            return this.Excluir(obj.IdCurso);
        }
        public override CursoPoco Excluir(int id)
        {
            Curso excluido = this.repositorio.DeleteById(id);
            CursoPoco poco = this.mapeador.Mecanismo.Map<CursoPoco>(excluido);
            return poco;
        }

    }
}
