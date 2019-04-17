using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ClienteViewModel
    {

        public int Id { get; set; }
        public List<string> ListaErrors { get; set; } = new List<string>();
        public string Apelido { get; set; }
        public string Nome { get; set; }

        [Display(Name ="CPF/CNPJ")]
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

    } //class
} //namespace
