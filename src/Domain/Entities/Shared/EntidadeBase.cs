using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Shared
{
    public abstract class EntidadeBase
    {

        public List<string> ListaErros { get; set; } = new List<string>();

        public abstract bool EstaConsistente();

    } //class
} //namespace
