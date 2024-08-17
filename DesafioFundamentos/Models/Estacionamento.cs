using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private const string Pattern = @"[A-Z]{3}[0-9][0-9A-Z][0-9]{2}";

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string plate = Console.ReadLine();
            plate = (plate.Length == 8) ? plate.Replace("-", "") : plate;
            plate = plate.ToUpper();
            Regex regex = new Regex(Pattern);
            if (regex.IsMatch(plate) && plate.Length > 0)
            {
                veiculos.Add(plate);
                Console.WriteLine($"Veículo {plate} adicionado com sucesso!");
            }else if(plate.Length == 0)
            {
                Console.WriteLine("Falha ao adicionar veículo!");
                Console.WriteLine("Erro: Placa não pode ser vazia!");
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
            string plate = Console.ReadLine();
            plate = (plate.Length == 8) ? plate.Replace("-", "") : plate;
            plate = plate.ToUpper();
            Regex regex = new Regex(Pattern);
            bool isRemoved = false;
            if (regex.IsMatch(plate) && (veiculos.Any(x => x.ToUpper() == plate.ToUpper())))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");            
                int horas = 0;
                decimal valorTotal = 0;
                try
                {
                    string horasString = Console.ReadLine();
                    if (horasString.Length > 0)
                    {
                        if (horasString.All(Char.IsDigit))
                        {
                            horas = Convert.ToInt32(horasString);
                            valorTotal = precoPorHora * horas + precoInicial;
                            veiculos.Remove(plate);
                            isRemoved = true;
                        }
                        else
                        {
                            Console.WriteLine("Erro: Horas inválidas!");
                        }
                    }else if(horasString.Length == 0)
                    {
                        Console.WriteLine("Erro: Horas não podem ser vazias!");
                    }
                    else
                    {
                        Console.WriteLine("Erro: Horas inválidas!");
                    }

                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao calcular o valor total");
                }

                if (isRemoved)
                {
                    Console.WriteLine($"O veículo {plate} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
