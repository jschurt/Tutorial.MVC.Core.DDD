using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class EntidadeBase
    {

        public List<string> ListaErros { get; set; }

        public abstract bool EstaConsistente();

    } //class
} //namespace
