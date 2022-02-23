﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Gibi
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        [Range(0, 999999.99)]
        public decimal Valor { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        public DateTime DataPublicacao { get; set; }

        public Gibi()
        {

        }
        public void copiarDados(Models.Gibi gibi)
        {
            this.Titulo = gibi.Titulo;
            this.Valor = gibi.Valor;
            this.Editora = gibi.Editora;
            this.DataPublicacao = gibi.DataPublicacao;
        }
    }
}
