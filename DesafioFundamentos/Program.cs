using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

try
{
    // Solicita o valor da tarifa inicial
    Console.Write("Digite o preço inicial (R$): ");
    precoInicial = decimal.Parse(Console.ReadLine());
    // Solicita o valor da tarifa por hora
    Console.Write("Digite o preço por hora (R$): ");
    precoPorHora = decimal.Parse(Console.ReadLine());
}
catch (FormatException)
{
    Console.WriteLine("Ocorreu um erro ao ler os preços. Informe o valor certo");
    return;
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
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

    Console.WriteLine("Pressione uma tecla para continuar...");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
