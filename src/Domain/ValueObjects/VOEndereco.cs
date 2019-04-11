using CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class VOEndereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public VOUF UF { get; set; } = new VOUF();
        public string CEP { get; set; }

        public bool Validar(string cep)
        {

            if (!string.IsNullOrEmpty(cep))
            {
                return ValidarCep(cep);
            } //if

            return true;

        } //Validar

        public bool ValidarCep(string cep)
        {

            if (cep.SomenteLetras().Length != 0)
                return false;

            if (cep.SomenteNumeros().Length != 8)
                return false;

            return true;

        } //ValidarCep

    } //class
} //namespace
