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
    public class RebanhoService : BaseAncestralService<RebanhoPoco>
    {
        private RebanhoMapper mapConfig;
        private RebanhoDao dao;
        public RebanhoService()
        {
            this.mapConfig = new RebanhoMapper();
            this.dao = new RebanhoDao();
        }

       
        public List<RebanhoPoco> Listar(int pular, int exibir)
        {
            List<Rebanho> listDOM = this.dao.ReadAll(pular, exibir);
            return ProcessarListaDOM(listDOM);

        }
        public List<RebanhoPoco> FiltrarPorAnoRefIdMun(int anoRef, int idMun)
        {
            List<Rebanho> listDOM = this.dao.QueryBy(reb => (reb.AnoRef == anoRef) && (reb.IDMunicipio == idMun)).ToList();
            return ProcessarListaDOM(listDOM);
        }

        private List<RebanhoPoco> ProcessarListaDOM(List<Rebanho> listDOM)
        {
            List<RebanhoPoco> listPOCO = new List<RebanhoPoco>();

            foreach (Rebanho item in listDOM)
            {
                RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(item);
                listPOCO.Add(poco);
            }

            return listPOCO;
        }

        public override RebanhoPoco Selecionar(int id)
        {
            Rebanho dom = this.dao.Read(id);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(dom);
            return poco;
        }
        public override RebanhoPoco Criar(RebanhoPoco obj)
        {
            Rebanho dom = this.mapConfig.Mapper.Map<Rebanho>(obj);
            Rebanho criado = this.dao.Create(dom);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(criado);
            return poco;

        }
        public override RebanhoPoco Atualizar(RebanhoPoco obj)
        {
            Rebanho dom = this.mapConfig.Mapper.Map<Rebanho>(obj);
            Rebanho atualizado = this.dao.Update(dom);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(atualizado);
            return poco;
        }
        public override RebanhoPoco Excluir(RebanhoPoco obj)
        {
            return this.Excluir(obj.IDRebanho);
        }
        public override RebanhoPoco Excluir(int id)
        {
            Rebanho excluido = this.dao.Delete(id);
            RebanhoPoco poco = this.mapConfig.Mapper.Map<RebanhoPoco>(excluido);
            return poco;
        }
    }
}
