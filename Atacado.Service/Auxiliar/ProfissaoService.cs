﻿using Atacado.EF.Database;
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
    public class ProfissaoService : BaseAncestralService<ProfissaoPoco, Profissao>
    {
        private ProfissaoRepository repositorio;

        public ProfissaoService()
        {
            this.mapeador = new MapeadorGenerico<ProfissaoPoco, Profissao>();
            this.repositorio = new ProfissaoRepository(new AtacadoContext());
        }
        public ProfissaoService(AtacadoContext contexto)
        {
            this.mapeador = new MapeadorGenerico<ProfissaoPoco, Profissao>();
            this.repositorio = new ProfissaoRepository(contexto);
        }


        public List<ProfissaoPoco> Listar(int pular, int exibir)
        {
            List<Profissao> listDOM = this.repositorio.Read(pular, exibir).ToList();
            return ProcessarListaDOM(listDOM);

        }

        protected override List<ProfissaoPoco> ProcessarListaDOM(List<Profissao> listDOM)
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<ProfissaoPoco>(dom)).ToList();
        }
        public override ProfissaoPoco Selecionar(int id)
        {
            Profissao dom = this.repositorio.Read(id);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(dom);
            return poco;
        }

        public ProfissaoPoco Criar(ProfissaoPoco obj)
        {
            Profissao dom = this.mapeador.Mecanismo.Map<Profissao>(obj);
            Profissao criado = this.repositorio.Add(dom);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(criado);
            return poco;
        }
        public override ProfissaoPoco Atualizar(ProfissaoPoco obj)
        {
            Profissao dom = this.mapeador.Mecanismo.Map<Profissao>(obj);
            Profissao atualizado = this.repositorio.Edit(dom);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(atualizado);
            return poco;
        }
        public override ProfissaoPoco Excluir(ProfissaoPoco obj)
        {
            return this.Excluir(obj.IdProfissao);
        }
        public override ProfissaoPoco Excluir(int id)
        {
            Profissao excluido = this.repositorio.DeleteById(id);
            ProfissaoPoco poco = this.mapeador.Mecanismo.Map<ProfissaoPoco>(excluido);
            return poco;
        }
    }
}
