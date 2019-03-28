using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class VOEndereco
    {
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

    } //class
} //namespace
