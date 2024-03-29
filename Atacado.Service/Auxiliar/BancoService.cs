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
    public class BancoService : BaseAncestralService<BancoPoco, Banco>
    {
        
        private BancoRepository repositorio;

        public BancoService()
        {
            this.mapeador = new MapeadorGenerico<BancoPoco, Banco>();
            this.repositorio = new BancoRepository(new AtacadoContext());
        }

        public BancoService(AtacadoContext contexto)
        {
            this.mapeador = new MapeadorGenerico<BancoPoco, Banco>();
            this.repositorio = new BancoRepository(contexto);
        }


        public override List<BancoPoco> Listar()
        {
            List<Banco> listDOM = this.repositorio.Read().ToList();
            return ProcessarListaDOM(listDOM);
        }
        protected override List<BancoPoco> ProcessarListaDOM(List<Banco> listDOM)
     
        {
            return listDOM.Select(dom => this.mapeador.Mecanismo.Map<BancoPoco>(dom)).ToList(); //<-- MINIMAL API//
        }
    

        public override BancoPoco Selecionar(int id)
        {
            Banco dom = this.repositorio.Read(id);
            BancoPoco poco = this.mapeador.Mecanismo.Map<BancoPoco>(dom);
            return poco;
        }
        public override BancoPoco Criar(BancoPoco obj)
        {
            Banco dom = this.mapeador.Mecanismo.Map<Banco>(obj);
            Banco criado = this.repositorio.Add(dom);
            BancoPoco poco = this.mapeador.Mecanismo.Map<BancoPoco>(criado);
            return poco;
        }
        public override BancoPoco Atualizar(BancoPoco obj)
        {
            Banco dom = this.mapeador.Mecanismo.Map<Banco>(obj);
            Banco atualizado = this.repositorio.Edit(dom);
            BancoPoco poco = this.mapeador.Mecanismo.Map<BancoPoco>(atualizado);
            return poco;
        }
        public override BancoPoco Excluir(BancoPoco obj)
        {
            return this.Excluir(obj.IdBanco);
        }

        public override BancoPoco Excluir(int id)
        {
            Banco excluido = this.repositorio.DeleteById(id);
            BancoPoco poco = this.mapeador.Mecanismo.Map<BancoPoco>(excluido);
            return poco;
        }

    }
}
