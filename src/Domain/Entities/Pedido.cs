using System;

namespace Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Apelido { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataEntrega { get; set; }
        public int Status { get; set; }

        public int idCliente { get; set; }

    } //class
} //namespace
