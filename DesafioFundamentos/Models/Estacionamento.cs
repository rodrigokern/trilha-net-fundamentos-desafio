namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly HashSet<string> veiculos = new(StringComparer.InvariantCultureIgnoreCase);

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar (ou ENTER para sair):");

            string placa = Console.ReadLine();
            if (string.IsNullOrEmpty(placa))
            {
                return;
            }

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Desculpe, esse veículo já estava cadastrado. Confira se digitou a placa corretamente.");
                return;
            }

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover (ou ENTER para sair):");

            string placa = Console.ReadLine();
            if (string.IsNullOrEmpty(placa))
            {
                return;
            }

            if (!veiculos.Contains(placa))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                return;
            }

            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

            int horas = Convert.ToInt32(Console.ReadLine());

            decimal valorTotal = precoInicial + precoPorHora * horas;

            veiculos.Remove(placa);
            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        public void ListarVeiculos()
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Os veículos estacionados são:");

            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }
    }
}
