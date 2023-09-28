namespace DesafioLoja
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Prover Gaming";

            Loja loja = new Loja();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo à Loja de Computadores!");
                Console.WriteLine("Escolha a opção que deseja realizar:");
                Console.WriteLine("1- Acesso como Empresa");
                Console.WriteLine("2- Acesso como Cliente");
                Console.WriteLine("3- Sair");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("====== ACESSO COMO EMPRESA ======");
                        Console.WriteLine("Digite o CNPJ:");
                        string cnpj = Console.ReadLine();

                        if (cnpj == "123")
                        {
                            loja.ApresentarEmpresa();
                        }
                        else
                        {
                            Console.WriteLine("CNPJ incorreto. Pressione Enter para continuar.");
                            Console.ReadLine();
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("====== ACESSO COMO CLIENTE ======");
                        loja.ApresentarCliente();
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