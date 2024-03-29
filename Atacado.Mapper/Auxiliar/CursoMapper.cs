﻿using Atacado.EF.Database;
using Atacado.Mapper.Ancestral;
using Atacado.Poco.Auxiliar;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Mapper.Auxiliar
{
    public class CursoMapper : BaseAncestralMapper
    {
        public CursoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Curso, CursoPoco>();


                cfg.CreateMap<CursoPoco, Curso>();

            });
            this.getMapper = configuration.CreateMapper();
        }
    }
}
