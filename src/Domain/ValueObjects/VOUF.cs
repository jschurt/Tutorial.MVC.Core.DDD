using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValueObjects
{
    public class VOUF
    {

        public string UF { get; set; }

        public List<string> ObterEstado()
        {
            return new List<string>
            {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MT", "MS", "PA", "PB", "PI", "PR", "RJ", "RN", "RS", "RO", "RR", "SC", "SE", "SP", "TO"
            };

        } //ObterEstado

        public bool Validar(string uf)
        {

            if (!string.IsNullOrEmpty(UF))
                return ValidarUf(uf);

            return true;
            
        } //Validar

        private bool ValidarUf(string uf)
        {
            if (uf.Length != 2)
                return false;

            var listaEstados = ObterEstado();
            if (!listaEstados.Where(l => listaEstados.Contains(uf)).Any())
                return false;

            return true;
            
        } //ValidarUf

    } //class
} //namespace
