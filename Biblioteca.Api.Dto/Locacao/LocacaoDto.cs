﻿using System;
using System.Collections.Generic;

namespace Biblioteca.Api.Dto
{
    public class LocacaoDto
    {
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Cliente { get; set; }
        public virtual IReadOnlyList<LocacaoLivroDto> Livros { get; set; }
        public bool TeveMulta { get; set; }

        public class LocacaoLivroDto
        {
            public string Titulo { get; set; }
            public string SubTitulo { get; set; }
        }
    }
}