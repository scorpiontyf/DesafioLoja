using System;

namespace DesafioLoja
{
    public class Computador
    {
        public string NomePC { get; set; }
        public string Marca { get; set; }
        public string PoderComputacional { get; set; }
        public decimal Valor { get; set; }
        public bool IsVendido { get; set; }

        public Computador(string nomePC, string marcaPC, string poderComputacional, decimal valor)
        {
            NomePC = nomePC;
            Marca = marcaPC;
            PoderComputacional = poderComputacional;
            Valor = valor;
            IsVendido = false;
        }
    }
}