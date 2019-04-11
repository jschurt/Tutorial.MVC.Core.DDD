using Domain.Entities.AggregationPedido;
using Domain.Entities.Shared;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public int Id { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public int idFornecedor { get; set; }


        //Propriedades de Navegacao...
        public virtual Fornecedor Fornecedor  { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }


        //Observe que estamos implementando aqui um padrao facade
        public override bool EstaConsistente()
        {
            ApelidoDeveSerPreenchido();
            ApelidoDeveTerUmTamanhoLimite(20);
            ApelidoDeveTerUmTamanhoMinimo(1);
            NomeDeveSerPreenchido();
            NomeDeveTerUmTamanhoLimite(150);
            NomeDeveTerUmTamanhoMinimo(1);
            ValorDeveSerSuperiorAZero();
            UnidadeDeveSerValida();
            FornecedorDeveSerPreenchido();

            return (ListaErros.Count == 0);

        } //EstaConsistente

        #region Validation Methods...

        private void ApelidoDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Apelido))
                ListaErros.Add("O campo Apelido deve ser preenchido.");

        } //ApelidoDeveSerPreenchido

        private void ApelidoDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Apelido.Length > tamanho)
                ListaErros.Add("O campo Apelido deve ter no maximo " + tamanho + " caracteres.");

        } //ApelidoDeveTerUmTamanhoLimite

        private void ApelidoDeveTerUmTamanhoMinimo(int tamanho)
        {

            if (Apelido.Length < tamanho)
                ListaErros.Add("O campo Apelido deve ter no minimo " + tamanho + " caracteres.");

        } //ApelidoDeveTerUmTamanhoMinimo

        private void NomeDeveSerPreenchido()
        {
            if (string.IsNullOrEmpty(Nome))
                ListaErros.Add("O campo Nome deve ser preenchido.");

        } //NomeDeveSerPreenchido

        private void NomeDeveTerUmTamanhoLimite(int tamanho)
        {

            if (Nome.Length > tamanho)
                ListaErros.Add("O campo Nome deve ter no maximo " + tamanho + " caracteres.");

        } //NomeDeveTerUmTamanhoLimite

        private void NomeDeveTerUmTamanhoMinimo(int tamanho)
        {

            if (Nome.Length < tamanho)
                ListaErros.Add("O campo Nome deve ter no minimo " + tamanho + " caracteres.");

        } //NomeDeveTerUmTamanhoMinimo

        private void ValorDeveSerSuperiorAZero()
        {
            if (Valor < 0)
                ListaErros.Add("O campo Valor deve ser superior a zero.");
        } //ValorDeveSerSuperiorAZero

        private void UnidadeDeveSerValida()
        {

            var listUnidade = new List<string> { "kg", "g", "m", "cm", "Qt" };

            if (!listUnidade.Contains(Unidade))
                ListaErros.Add("Unidade deve ser 'kg', 'g', 'm', 'cm', 'Qt' ");

        } //ValidarUnidade

        private void FornecedorDeveSerPreenchido()
        {
            if (idFornecedor == 0)
                ListaErros.Add("O campo Fornecedor deve ser informado.");
        } //FornecedorDeveSerPreenchido

        #endregion

    } //class
} //namespace
