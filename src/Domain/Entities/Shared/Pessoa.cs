using Domain.Entities.ValueObjects;

namespace Domain.Entities.Shared
{
    public abstract class Pessoa : EntidadeBase
    {

        public string Apelido { get; set; }
        public string Nome { get; set; }
        public VOCpfCnpj CpfCnpj { get; set; } = new VOCpfCnpj();
        public VOEmail Email { get; set; } = new VOEmail();
        public VOEndereco Endereco { get; set; } = new VOEndereco();

        #region Validation Methods...

        protected void ApelidoDeveSerPreenchido()
        {

            if (string.IsNullOrEmpty(Apelido))
                ListaErros.Add("Apelido deve ser preenchido");

        } //ApelidoDeveSerPreenchido

        protected void ApelidoDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Apelido.Trim().Length > tamanho)
                ListaErros.Add("O campo apelido deve ter no maximo " + tamanho + " caracteres");

        } //ApelidoDeveTerUmTamanhoLimite

        protected void NomeDeveSerPreenchido()
        {

            if (string.IsNullOrEmpty(Nome))
                ListaErros.Add("Nome deve ser preenchido");

        } //NomeDeveSerPreenchido

        protected void NomeDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Nome.Trim().Length > tamanho)
                ListaErros.Add("O campo nome deve ter no maximo " + tamanho + " caracteres");

        } //NomeDeveTerUmTamanhoLimite

        protected void CPFouCNPJDeveSerPreenchido()
        {

            if (string.IsNullOrEmpty(CpfCnpj.Numero))
                ListaErros.Add("CPF ou CNPJ deve ser preenchido");

        } //CPFouCNPJDeveSerPreenchido

        protected void CPFouCNPJDeveSerValido()
        {

            if (!CpfCnpj.Validar(CpfCnpj.Numero))
                ListaErros.Add("CPF ou CNPJ deve ser valido");

        } //CPFouCNPJDeveSerValido

        protected void EmailDeveSerValido()
        {

            if (!Email.Validar(Email.EnderecoEmail))
                ListaErros.Add("Email deve ser valido");

        } //EmailDeveSerValido

        protected void EmailDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Email.EnderecoEmail.Trim().Length > tamanho)
                ListaErros.Add("O campo email deve ter no maximo " + tamanho + " caracteres");

        } //EmailDeveTerUmTamanhoLimite

        protected void EnderecoDeveSerPreenchido()
        {

            if (string.IsNullOrEmpty(Endereco.Logradouro))
                ListaErros.Add("Endereco deve ser preenchido");

        } //EnderecoDeveSerPreenchido

        protected void EnderecoDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Endereco.Logradouro.Trim().Length > tamanho)
                ListaErros.Add("O campo endereco deve ter no maximo " + tamanho + " caracteres");

        } //EnderecoDeveTerUmTamanhoLimite

        protected void BairroDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Endereco.Bairro.Trim().Length > tamanho)
                ListaErros.Add("O campo bairro deve ter no maximo " + tamanho + " caracteres");

        } //BairroDeveTerUmTamanhoLimite

        protected void CidadeDeveSerPreenchido()
        {

            if (string.IsNullOrEmpty(Endereco.Cidade))
                ListaErros.Add("Cidade deve ser preenchido");

        } //CidadeDeveSerPreenchido

        protected void CidadeDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Endereco.Cidade.Trim().Length > tamanho)
                ListaErros.Add("O campo cidade deve ter no maximo " + tamanho + " caracteres");

        } //CidadeDeveTerUmTamanhoLimite

        protected void UFDeveSerPreenchido()
        {

            if (string.IsNullOrEmpty(Endereco.UF.UF))
                ListaErros.Add("UF deve ser preenchido");

        } //CidadeDeveSerPreenchido

        protected void UFDeveSerValida()
        {

            if (Endereco.UF.Validar(Endereco.UF.UF))
                ListaErros.Add("O campo UF deve ter valido");

        } //UFDeveSerValida

        protected void CEPDeveSerValido()
        {

            if (Endereco.ValidarCep(Endereco.CEP))
                ListaErros.Add("O campo UF deve ter valido");

        } //CEPDeveSerValido

        #endregion

    } //Pessoa
} //namespace
