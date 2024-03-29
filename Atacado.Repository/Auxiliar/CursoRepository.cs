﻿using Atacado.EF.Database;
using Atacado.Repository.Ancestral;
using Microsoft.EntityFrameworkCore;

namespace Atacado.Repository.Auxiliar
{
    public class CursoRepository
        : BaseRepository<Curso>
    {
        public CursoRepository(AtacadoContext contexto) 
            : base(contexto)
        {
        }

        public override Curso DeleteById(int id)
        {
            Curso curso = this.Read(id);
            this.context.Set<Curso>().Remove(curso);
            this.context.SaveChanges();
            return curso;
        }
    }
}
