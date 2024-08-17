using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private static Regex regex = new Regex(@"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}");

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string plate = Console.ReadLine()?.ToUpper().Replace("-", "");
            if (plate.Length == 0)
            {
                Console.WriteLine("Falha ao adicionar veículo!");
                Console.WriteLine("Erro: Placa não pode ser vazia!");
                return;
            }
            
            if (regex.IsMatch(plate))
            {
                veiculos.Add(plate);
                Console.WriteLine($"Veículo {plate} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao adicionar veículo!");
                Console.WriteLine($"Erro: Placa {plate} inválida!");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string plate = Console.ReadLine()?.ToUpper().Replace("-", ""); 
    
            if (string.IsNullOrEmpty(plate))
            {
                Console.WriteLine("Erro: Placa não pode ser vazia!");
                return;
            }
    
            if (!regex.IsMatch(plate)) 
            {
                Console.WriteLine($"Erro: Placa {plate} é inválida!");
                return;
            }

            if (!veiculos.Any(x => x.ToUpper() == plate.ToUpper()))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                return;
            }
    
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");            
            if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
            {
                Console.WriteLine("Erro: Horas inválidas!");
                return;
            }

            decimal valorTotal = precoPorHora * horas + precoInicial; 
            veiculos.Remove(plate);
            Console.WriteLine($"O veículo {plate} foi removido e o preço total foi de: R$ {valorTotal:F2}");
        }


        public void ListarVeiculos()
        {
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
    }
}
