/**
 * \brief Trabalho de Programação Orientada Por objectos 
 * \details Parque de Estacionamento de um Hospital
 * \author Miguel António Costa Macedo, aluno 26046
 * \file SetoresParque.cs
  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPOO_a26046
{
    public class SetorParque
    {
        public string NomeSetor { get; set; }
        public int Capacidade { get; set; }
        public List<Veiculo> Veiculos { get; set; }  /// Lista dos Veiculos Estacionados
        public Dictionary<string, decimal> PagamentoHoraPorTipoVeiculo { get; set; }
        public List<string> TiposVeiculosPermitidos { get; set; }  /// Lista dos Veículos Permitidos no Setor
        public decimal PercentagemDescontoFuncionarios { get; set; }
        public List<RegistoEstacionamento> HistoricoParque { get; set; } /// Lista dos Registos de Estacionamento e pagamentos

        /** Dados do Setor */
        public SetorParque(string nomeSetor, int capacidade, Dictionary<string, decimal> pagamentoHora, List<string> tipoVeiculosPermitidos, decimal percentagemDescontoFuncionarios)
        {
            NomeSetor = nomeSetor;
            Capacidade = capacidade;
            PagamentoHoraPorTipoVeiculo = pagamentoHora;
            Veiculos = new List<Veiculo>();
            TiposVeiculosPermitidos = tipoVeiculosPermitidos;
            PercentagemDescontoFuncionarios = percentagemDescontoFuncionarios;
            HistoricoParque = new List<RegistoEstacionamento>();
        }

        /** Para verificar e indicar que o setor já se encontra cheio, sem lugares disponíveis */
        public bool SetorCheio()
        {
            return Veiculos.Count >= Capacidade; // Devolve 'true' se Veículos foi igual ou superior à capacidade 
        }

        /** Calcula o Pagamento, valor calculado em Horas, para pagamento na retirada do veiculo */
        public decimal CalcularPagamentoParque(decimal taxaHora, DateTime entrada)
        {
            DateTime saida = DateTime.Now;
            TimeSpan tempoParque = saida - entrada;
            decimal horasEstacionado = (decimal)tempoParque.TotalHours;
            return horasEstacionado * taxaHora; // Devolve o valor a pagar
        }

        /** Regista o início do estacionamento do Veículo */
        public void EstacionaVeiculo(Veiculo veiculoEstaciona)
        {
            if (SetorCheio()) // Verifica se o Setor está já cheio
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|    O SETOR ESCOLHIDO ESTÁ CHEIO    |");
                Console.WriteLine("|                                    |");
                Console.WriteLine($"|  O Setor {NomeSetor,12} está cheio!  |");
                Console.WriteLine("|   Escolha outro setor no Parque... |");
                Console.WriteLine("+------------------------------------+");
                return;
            }

            if (!TiposVeiculosPermitidos.Contains(veiculoEstaciona.VeiculoTipo)) // Verifica se o Setor permite o tipo de veiculo
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|   TIPO DE VEÍCULO NÃO PERMITIDO!   |");
                Console.WriteLine("|                                    |");
                Console.WriteLine($"|  O Setor {NomeSetor,12} não permite  |");
                Console.WriteLine($"|   veículos do tipo {veiculoEstaciona.VeiculoTipo,-12}.   |");
                Console.WriteLine("+------------------------------------+");
                return;
            }

            veiculoEstaciona.Entrada = DateTime.Now;
            veiculoEstaciona.TaxaEstacionamento = CalcularPagamentoParque(PagamentoHoraPorTipoVeiculo[veiculoEstaciona.VeiculoTipo], veiculoEstaciona.Entrada); 
            Veiculos.Add(veiculoEstaciona);

            Console.Clear(); // Mostra ticket de Estacionamento
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Impressão do Ticket de Estacionamento...");
            Console.WriteLine(); 
            Console.WriteLine("\n+----------------------------------+");
            Console.WriteLine($"|    Ticket de Estacionamento      |");
            Console.WriteLine("+------------+---------------------+");
            Console.WriteLine($"| Setor     | {NomeSetor,-19} |");
            Console.WriteLine("+------------+---------------------+");
            Console.WriteLine($"| Entrada   | {DateTime.Now,-19} |");
            Console.WriteLine("+------------+---------------------+");
            Console.WriteLine($"| Taxa/Hora | {veiculoEstaciona.TaxaEstacionamento,-19} |"); 
            Console.WriteLine("+------------+---------------------+");
        }

        /** Regista a Saída do veiculo do estacionamento */
        public void FimEstacionamentoVeiculo(string matriculaVeiculo, string setorEstacionado, ParqueHospitalar parqueHospital)
        {
            Veiculo veiculoRemover = Veiculos.Find(v => v.MatriculaVeiculo == matriculaVeiculo); // Procura veículo a remover
            if (veiculoRemover != null) // verifica se foi encontrado veículo para remover
            {
                DateTime saida = DateTime.Now;
                TimeSpan tempoParque = saida - veiculoRemover.Entrada;
                decimal horasEstacionado = (decimal)tempoParque.TotalHours;

                bool pertenceFuncionario = parqueHospital.VeiculoPertenceFuncionario(matriculaVeiculo); // Procura para ver se pertence a funcionário

                if (pertenceFuncionario) // Verifica se pertence a funcionário e aplica Desconto se se 'true' e se 'false' aplica taxa sem desconto
                {
                    veiculoRemover.TaxaEstacionamento = horasEstacionado * PagamentoHoraPorTipoVeiculo[veiculoRemover.VeiculoTipo] * ((100 - PercentagemDescontoFuncionarios) / 100); // Aplica desconto na taxa
                }
                else
                {
                    // Não é funcionario por isso sem desconto
                    veiculoRemover.TaxaEstacionamento = horasEstacionado * PagamentoHoraPorTipoVeiculo[veiculoRemover.VeiculoTipo]; // Taxa sem desconto
                }


                RegistoEstacionamento registoEstacionamento = new RegistoEstacionamento(veiculoRemover, veiculoRemover.Entrada, saida, veiculoRemover.TaxaEstacionamento, PercentagemDescontoFuncionarios, setorEstacionado);
                HistoricoParque.Add(registoEstacionamento); // Cria Registo Estacionamento antes de remover o veiculo do Estacionamento

                Veiculos.Remove(veiculoRemover); // Remove o veiculo do Estacionamento
                parqueHospital.VeiculoRemovido = true;
                Console.Clear(); // Mostra Recibo do Estacionamento
                Console.WriteLine();
                Console.WriteLine();            
                Console.WriteLine("Impressão do Recibo de Estacionamento...");
                Console.WriteLine(); 
                Console.WriteLine("\n+-------------------------------------------+");
                Console.WriteLine($"|    Recibo do Veículo {matriculaVeiculo,-20} |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine("|        Setor        |         Taxa        |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine($"| {NomeSetor,-19} |      €{veiculoRemover.TaxaEstacionamento,-13:0.00} |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine("|       Entrada       |         Saída       |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine($"| {veiculoRemover.Entrada,-19} | {saida,-19} |");
                Console.WriteLine("+---------------------+---------------------+");
                
                if (pertenceFuncionario) // Se matricula pertencer a funcionário, mostra a percentagem do desconto e o valor descontado
                {
                    Console.WriteLine("| % Desconto aplicado |   Taxa Descontada   |");
                    Console.WriteLine("+---------------------+---------------------+");
                    Console.WriteLine($"|        {PercentagemDescontoFuncionarios,3} %        |    {(horasEstacionado * PagamentoHoraPorTipoVeiculo[veiculoRemover.VeiculoTipo]) - veiculoRemover.TaxaEstacionamento,12:0.00}€    |");
                    Console.WriteLine("+---------------------+---------------------+");
                }
            }

        }

        /** Calcula a soma das taxas de estacionamento pagas por setor */
        public decimal CalcularTotalTaxaEstacionamento()
        {
            return HistoricoParque.Sum(registo => registo.TaxaEstacionamento); // Devolve o Total de Taxas de Estacionamento pagas de cada setor
        }

       
    }

}

