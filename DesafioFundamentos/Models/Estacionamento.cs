using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private HashSet<string> veiculos = new HashSet<string>();

        private static readonly Regex PlacaAntigaRegex = new Regex(@"^[A-Z]{3}-[0-9]{4}$");
        private static readonly Regex PlacaMercosulRegex = new Regex(@"^[A-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placaVeiculo = Console.ReadLine()?.Trim().ToUpper();

            // Verifica se a placa do veículo é válida
            if (string.IsNullOrWhiteSpace(placaVeiculo) || !EhPlacaValida(placaVeiculo) )
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            // Verifica se o veículo existe
            if (!veiculos.Add(placaVeiculo))
            {
                Console.WriteLine("Veículo já está estacionado.");
                return;
            }

            Console.WriteLine("Veículo adicionado.");
        }

        public void RemoverVeiculo()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.Write("Digite a placa do veículo para remover: ");
            string placaVeiculo = Console.ReadLine()?.Trim().ToUpper();

            if (!veiculos.Contains(placaVeiculo))  {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return;
            }

            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            string quantidadeHoras = Console.ReadLine();

            if(!int.TryParse(quantidadeHoras, out int quantidadeHorasEstacionado) || quantidadeHorasEstacionado < 0)
            {
                Console.WriteLine("Entrada não válida. Tente novamente.");
                return;
            }


            decimal valorTotal = precoInicial + precoPorHora * quantidadeHorasEstacionado;

            veiculos.Remove(placaVeiculo);

            Console.WriteLine($"O veículo {placaVeiculo} foi removido " +
                $"e o preço total foi de: {valorTotal.ToString("C", new CultureInfo("pt-BR"))}");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Count > 0)
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string placaVeiculo in veiculos) 
                    Console.WriteLine(placaVeiculo);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool EhPlacaValida(string placaVeiculo)
        {
            return PlacaAntigaRegex.IsMatch(placaVeiculo) || PlacaMercosulRegex.IsMatch(placaVeiculo);
        }
    }
}
