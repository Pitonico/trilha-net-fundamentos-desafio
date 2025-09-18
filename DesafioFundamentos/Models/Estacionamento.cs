using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placaVeiculo = Console.ReadLine().ToUpper();

            // Verifica se a placa do veículo é válida
            if (!EhPlacaValida(placaVeiculo))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            // Verifica se o veículo existe
            if (ExistePlacaVeiculo(placaVeiculo))
            {
                Console.WriteLine("Veículo já está estacionado.");
                return;
            }

            veiculos.Add(placaVeiculo);
            Console.WriteLine("Veículo adicionado.");
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placaVeiculo = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (ExistePlacaVeiculo(placaVeiculo))
            {

                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                string entrada = Console.ReadLine();
                
                try
                {
                    int quantidadeHorasEstacionado = entrada != string.Empty ? int.Parse(entrada) : 0;

                    decimal valorTotal = precoInicial + precoPorHora * quantidadeHorasEstacionado;

                    veiculos.Remove(placaVeiculo);

                    Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de: {valorTotal.ToString("C", new CultureInfo("pt-BR"))}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada não valida");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool EhPlacaValida(string placaVeiculo)
        {
            string placaAntiga = @"^[A-Z]{3}-[0-9]{4}$";
            string placaMercosul = @"^[A-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$";

            bool ehValida = Regex.IsMatch(placaVeiculo, placaAntiga) || Regex.IsMatch(placaVeiculo, placaMercosul);
            
            return ehValida;
        }

        private bool ExistePlacaVeiculo(string placaVeiculo)
        {
            return veiculos.Any(placaVeiculoCadastrada => placaVeiculoCadastrada == placaVeiculo);
        }
    }
}
