using Atacado.Dal.Auxiliar;
using Atacado.EF.Database;
using Atacado.Mapper.Auxiliar;
using Atacado.Poco.Auxiliar;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.Auxiliar
{
    public class AreaConhecimentoService : BaseAncestralService<AreaConhecimentoPoco>
    {
        private AreaConhecimentoMapper mapConfig;
        private AreaConhecimentoDao dao;
       
        public AreaConhecimentoService()
        {
            this.mapConfig = new AreaConhecimentoMapper();
            this.dao = new AreaConhecimentoDao();
        }
        public override List<AreaConhecimentoPoco> Listar()
        {
            List<AreaConhecimento> listDOM = this.dao.ReadAll().Skip(0).Take(100).ToList();
            List<AreaConhecimentoPoco> listPOCO = new List<AreaConhecimentoPoco>();
            foreach (AreaConhecimento item in listDOM)
            {
                AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(item);
                listPOCO.Add(poco);
            }

            return listPOCO;
        }
        public List<AreaConhecimentoPoco> Listar(int pular, int exibir)
        {
            List<AreaConhecimento> listDOM = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDOM);
        }
        private List<AreaConhecimentoPoco> ProcessarListaDOM(List<AreaConhecimento> listDOM)
        {
            List<AreaConhecimentoPoco> listPOCO = new List<AreaConhecimentoPoco>();

            foreach (AreaConhecimento item in listDOM)
            {
                AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(item);
                listPOCO.Add(poco);
            }

            return listPOCO;
        }
        public override AreaConhecimentoPoco Selecionar(int id)
        {
            AreaConhecimento dom = this.dao.Read(id);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(dom);
            return poco;
        }
        public override AreaConhecimentoPoco Criar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapConfig.Mapper.Map<AreaConhecimento>(obj);
            AreaConhecimento criado = this.dao.Create(dom);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(criado);
            return poco;
        }
        public override AreaConhecimentoPoco Atualizar(AreaConhecimentoPoco obj)
        {
            AreaConhecimento dom = this.mapConfig.Mapper.Map<AreaConhecimento>(obj);
            AreaConhecimento atualizado = this.dao.Update(dom);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(atualizado);
            return poco;
        }
        public override AreaConhecimentoPoco Excluir(AreaConhecimentoPoco obj)
        {
            return this.Excluir(obj.IdArea);
        }
        public override AreaConhecimentoPoco Excluir(int id)
        {
            AreaConhecimento excluido = this.dao.Delete(id);
            AreaConhecimentoPoco poco = this.mapConfig.Mapper.Map<AreaConhecimentoPoco>(excluido);
            return poco;
        }

    }
}
