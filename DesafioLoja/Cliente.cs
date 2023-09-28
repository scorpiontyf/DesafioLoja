using System;

namespace DesafioLoja
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public decimal Salario { get; set; }

        public Cliente(string nome, string telefone, decimal salario)
        {
            Nome = nome;
            Telefone = telefone;
            Salario = salario;
        }
    }
}