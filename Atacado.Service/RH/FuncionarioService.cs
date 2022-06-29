﻿using Atacado.EF.Database;
using Atacado.Poco.RH;
using Atacado.Repository.RH;
using Atacado.Service.Ancestral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Service.RH
{
    public class FuncionarioService : BaseAncestralService<FuncionarioPoco, Funcionario>
    {
        private FuncionarioRepository repositorio;
        
        public FuncionarioService() : base()
        {
            this.mapeador = new MapeadorGenerico<FuncionarioPoco, Funcionario>();
            this.repositorio = new FuncionarioRepository(new AtacadoContext());
        }

        public List<FuncionarioPoco> Listar(int pular, int exibir)
        {
            List<Funcionario> listaDOM = this.repositorio.Read(pular, exibir).ToList();
            return this.ProcessarListaDOM(listaDOM);
        }

        protected override List<FuncionarioPoco> ProcessarListaDOM(List<Funcionario> listDOM)
        {
             return listDOM.Select(dom => this.mapeador.Mecanismo.Map<FuncionarioPoco>(dom)).ToList();
        }
        public override FuncionarioPoco Atualizar(FuncionarioPoco obj)
        {
            Funcionario temp = this.mapeador.Mecanismo.Map<Funcionario>(obj);
            Funcionario editado = this.repositorio.Edit(temp);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(editado);
            return poco;

        }

        public override FuncionarioPoco Criar(FuncionarioPoco obj)
        {
            Funcionario temp = this.mapeador.Mecanismo.Map<Funcionario>(obj);
            Funcionario criado = this.repositorio.Add(temp);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(criado);
            return poco;
        }
        public override FuncionarioPoco Excluir(FuncionarioPoco obj)
        {
            Funcionario temp = this.mapeador.Mecanismo.Map<Funcionario>(obj);
            Funcionario excluido = this.repositorio.Delete(temp);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(excluido);
            return poco;
        }
        public override FuncionarioPoco Excluir(int id)
        {
            Funcionario excluido = this.repositorio.DeleteById(id);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(excluido);
            return poco;
        }

        public override FuncionarioPoco Selecionar(int id)
        {
            Funcionario selecionado = this.repositorio.Read(id);
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(selecionado);
            return poco;
        }
        public FuncionarioPoco SelecionarPorMatricula(long mat)
        {
            Funcionario busca = this.repositorio.Browse(fun => fun.MatriculaFuncionario == mat).First();
            FuncionarioPoco poco = this.mapeador.Mecanismo.Map<FuncionarioPoco>(busca);
            return poco;
        }
        
    }
}