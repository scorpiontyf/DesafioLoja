using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioLoja
{
    public class Loja
    {
        public List<Computador> Computadores = new List<Computador>();
        public List<Cliente> Clientes = new List<Cliente>();

        public class SalarioInvalidoException : Exception
{
    public SalarioInvalidoException() : base("Salário inválido. O salário deve ser maior que zero.")
    {
    }
}
        public class ValorComputadorInvalidoException : Exception
        {
            public ValorComputadorInvalidoException() : base("Valor do computador inválido. O valor deve ser maior que zero.")
            {
            }
        }

        public void CadastrarComputador(string nome, string marca, string poderComputacional, decimal valor)
        {

            if (Computadores.Any(pc => pc.NomePC == nome))
            {
                Console.WriteLine($"Já existe um computador com o nome '{nome}'. Não é possível cadastrar um computador com o mesmo nome.");
            }
            else
            {
                Computador pc = new Computador(nome, marca, poderComputacional, valor);
                Computadores.Add(pc);
                Console.WriteLine($"O computador '{nome}' da marca {marca} foi cadastrado na loja no valor de {valor}!");
            }
        }

        public void CadastrarCliente(string nome, string telefone, decimal salario)
        {
            if (Clientes.Any(cliente => cliente.Nome == nome))
            {
                Console.WriteLine($"Já existe um cliente com o nome '{nome}'. Não é possível cadastrar um cliente com o mesmo nome.");
            }
            else
            {
                Cliente cliente = new Cliente(nome, telefone, salario);
                Clientes.Add(cliente);
                Console.WriteLine($"O cliente '{nome}' com telefone {telefone} foi cadastrado com um salário de {salario}!");
            }

        }

        public void Vender(string nomePC, string nomeCliente)
        {
            Computador pc = Computadores.Find(l => l.NomePC == nomePC);
            Cliente cliente = Clientes.Find(c => c.Nome == nomeCliente);

            if (pc != null)
            {
                if (!pc.IsVendido)
                {
                    if (cliente != null && cliente.Salario >= pc.Valor)
                    {
                        pc.IsVendido = true;
                        Console.WriteLine($"O computador '{nomePC}' foi vendido para o cliente '{nomeCliente}'!");
                    }
                    else
                    {
                        Console.WriteLine($"O computador '{nomePC}' não está disponível para compra ou o cliente não tem saldo suficiente.");
                    }
                }
                else
                {
                    Console.WriteLine($"O computador '{nomePC}' já foi vendido.");
                }
            }
            else
            {
                Console.WriteLine($"O computador '{nomePC}' não foi encontrado na loja.");
            }
        }

        public void VerificarEstoque()
        {
            Console.Clear();
            Console.WriteLine("======ESTOQUE======");
            Console.WriteLine();
            if (Computadores.Count == 0)
            {
                Console.WriteLine("Nenhum computador cadastrado na loja.");
            }
            else
            {
                foreach (var pc in Computadores)
                {
                    Console.WriteLine($"Nome: {pc.NomePC}");
                    Console.WriteLine($"Marca: {pc.Marca}");
                    Console.WriteLine($"Valor: {pc.Valor}");
                    Console.WriteLine($"Poder Computacional: {pc.PoderComputacional}");
                    Console.WriteLine($"Venda realizada: {(pc.IsVendido ? "Sim" : "Não")}");
                    Console.WriteLine("--------------------------------");
                }
            }

            Console.WriteLine("Pressione Enter para voltar ao menu.");
            Console.ReadLine();
        }

        public void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("======LISTA DE CLIENTES======");
            Console.WriteLine();
            if (Clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                foreach (var cliente in Clientes)
                {
                    Console.WriteLine($"Nome: {cliente.Nome}");
                    Console.WriteLine($"Telefone: {cliente.Telefone}");
                    Console.WriteLine($"Salário: {cliente.Salario}");
                    Console.WriteLine("--------------------------------");
                }
            }
            Console.ReadLine();
        }

            public void Comprar()
        {
            Console.Clear();
            Console.WriteLine("======COMPRA======");
            Console.WriteLine();
            Console.WriteLine("Digite o seu nome:");
            string nomeCliente = Console.ReadLine();

            Cliente cliente = Clientes.Find(c => c.Nome == nomeCliente);

            if (cliente == null)
            {
                Console.WriteLine($"O cliente '{nomeCliente}' não foi encontrado. Por favor, cadastre o cliente.");
                Console.WriteLine("Digite o telefone do cliente:");
                string telefone = Console.ReadLine();
                Console.WriteLine("Digite o salário do cliente:");

                if (decimal.TryParse(Console.ReadLine(), out decimal salario))
                {
                    CadastrarCliente(nomeCliente, telefone, salario);
                    cliente = Clientes.Find(c => c.Nome == nomeCliente);
                }
                else
                {
                    Console.WriteLine("Salário inválido. A compra não pode ser processada.");
                    Console.ReadLine();
                    return;
                }
            }

            Console.WriteLine("Digite o nome do computador:");
            Console.WriteLine("Lembre-se de digitar o nome do computador de forma idêntica ao seu nome no estoque.\nCaso não se recorde consulte novamente.");
            string nomePC2 = Console.ReadLine();

            Computador pc = Computadores.Find(l => l.NomePC == nomePC2);

            if (pc != null)
            {
                if (!pc.IsVendido)
                {
                    if (cliente.Salario >= pc.Valor)
                    {
                        pc.IsVendido = true;
                        Console.WriteLine($"O computador '{nomePC2}' foi vendido para o cliente '{nomeCliente}'!");
                        cliente.Salario -= pc.Valor;
                    }
                    else
                    {
                        Console.WriteLine($"O computador '{nomePC2}' não está disponível para compra devido ao saldo insuficiente do cliente.");
                    }
                }
                else
                {
                    Console.WriteLine($"O computador '{nomePC2}' já foi vendido.");
                }
            }
            else
            {
                Console.WriteLine($"O computador '{nomePC2}' não foi encontrado na loja.");
            }

            Console.ReadLine();
        }


        public void ApresentarEmpresa()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite a opção que deseja realizar:");
                Console.WriteLine("1- Cadastrar computador\n2- Cadastrar cliente\n3- Verificar Estoque\n4- Lista Clientes\n5-Sair");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("======CADASTRO DE COMPUTADOR======");
                        Console.WriteLine("\nDigite o nome do computador:");
                        string nomePC = Console.ReadLine();
                        Console.WriteLine("\nDigite a marca do computador:");
                        string marca = Console.ReadLine();
                        Console.WriteLine("\nDigite o poder computacional:");
                        string poderComputacional = Console.ReadLine();
                        Console.WriteLine("\nDigite o valor do computador:");
                        try
                        {
                            if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                            {
                                if (valor <= 0)
                                {
                                    Console.WriteLine("Sabe que esse valor não pode, Giovanni. Tecle enter para retornar à função escolhida.");
                                    Console.ReadLine();
                                    throw new ValorComputadorInvalidoException();
                                }
                                CadastrarComputador(nomePC, marca, poderComputacional, valor);
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido ou acima do limite. O computador não pode ser cadastrado.");
                            }
                        }
                        catch (ValorComputadorInvalidoException ex)
                        {
                            Console.WriteLine("Erro: " + ex.Message);
                        }
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("======CADASTRO DE CLIENTE======");
                        Console.WriteLine("\nDigite o nome do cliente:");
                        string nomeCliente = Console.ReadLine();
                        Console.WriteLine("\nDigite o telefone do cliente:");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("\nDigite o salário do cliente:");
                        try
                        {
                            if (decimal.TryParse(Console.ReadLine(), out decimal salario))
                            {
                                if (salario <= 0)
                                {
                                    Console.WriteLine("Sabe que esse valor não pode, Giovanni. Tecle enter para retornar à função escolhida.");
                                    Console.ReadLine();
                                    throw new SalarioInvalidoException();
                                }
                                else
                                {
                                    CadastrarCliente(nomeCliente, telefone, salario);
                                    Console.WriteLine($"O cliente '{nomeCliente}' com telefone '{telefone}' foi cadastrado com salário '{salario}'!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Salário inválido ou acima do limite. O cliente não pode ser cadastrado. Volte ao menu teclando enter e tente novamente");
                            }
                        }
                        catch (SalarioInvalidoException ex)
                        {
                            Console.WriteLine("Erro: " + ex.Message);
                        }
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ReadLine();
                        break;

                    case "3":
                        VerificarEstoque();
                        break;

                    case "4":
                        ListarClientes();
                        break;

                    case "5":
                        Console.WriteLine("O programa será encerrado.");
                        return;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("Escolha a opção correta!");
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void ApresentarCliente()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite a opção que deseja realizar:");
                Console.WriteLine("1- Comprar\n2- Verificar Estoque\n3- Sair");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Comprar();
                        break;

                    case "2":
                        VerificarEstoque();
                        break;

                    case "3":
                        Console.WriteLine("O programa será encerrado.");
                        return;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("Escolha a opção correta!");
                        Console.WriteLine("Pressione Enter para continuar.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
   