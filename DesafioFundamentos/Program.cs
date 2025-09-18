using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("---| Sistema de Estacionamento |---");

decimal precoInicial = LerDecimal("Digite o preço inicial (R$): ");
decimal precoPorHora = LerDecimal("Digite o preço por hora (R$): ");

Estacionamento(new Estacionamento(precoInicial, precoPorHora));

static decimal LerDecimal(string mensagem)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("---| Sistema de Estacionamento |---");
        Console.Write(mensagem);
        if (decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            return valor;
        }
        Console.WriteLine("Valor inválido. Tente novamente.");
        Console.Write("Pressione uma tecla para tentar novamente...");
        Console.ReadLine();
    }
}

static void Estacionamento(Estacionamento estacionamento)
{
    Estacionamento es = estacionamento;

    bool exibirMenu = true;

    // Realiza o loop do menu
    while (exibirMenu)
    {
        Console.Clear();
        Console.WriteLine("---| Sistema de Estacionamento |---");
        Console.WriteLine("1 - Cadastrar veículo");
        Console.WriteLine("2 - Remover veículo");
        Console.WriteLine("3 - Listar veículos");
        Console.WriteLine("4 - Encerrar");
        Console.Write("Digite a sua opção: ");

        switch (Console.ReadLine())
        {
            case "1":
                es.AdicionarVeiculo();
                break;

            case "2":
                es.RemoverVeiculo();
                break;

            case "3":
                es.ListarVeiculos();
                break;

            case "4":
                exibirMenu = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }

        if(exibirMenu)
        {
            Console.Write("Pressione uma tecla para continuar...");
            Console.ReadLine();
        }
    }

    Console.WriteLine("O programa se encerrou");
}
