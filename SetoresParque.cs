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
        public List<Veiculo> Veiculos { get; set; }
        public Dictionary<string, decimal> PagamentoHoraPorTipoVeiculo { get; set; }
        public List<string> TiposVeiculosPermitidos { get; set; }

        public List<RegistoEstacionamento> HistoricoParque { get; set; }

        // Dados do Setor
        public SetorParque(string nomeSetor, int capacidade, Dictionary<string, decimal> pagamentoHora, List<string> tipoVeiculosPermitidos)
        {
            NomeSetor = nomeSetor;
            Capacidade = capacidade;
            PagamentoHoraPorTipoVeiculo = pagamentoHora;
            Veiculos = new List<Veiculo>();
            TiposVeiculosPermitidos = tipoVeiculosPermitidos;
            HistoricoParque = new List<RegistoEstacionamento>();
        }

        /** Para verificar e indicar que o setor já se encontra cheio, sem lugares disponíveis */
        public bool SetorCheio()
        {
            return Veiculos.Count >= Capacidade;
        }

        /** Calcula o Pagamento, valor calculado em Horas, para pagamento na retirada do veiculo */
        public decimal CalcularPagamentoParque(decimal taxaHora, DateTime entrada)
        {
            DateTime saida = DateTime.Now;
            TimeSpan tempoParque = saida - entrada;
            decimal horasEstacionado = (decimal)tempoParque.TotalHours;
            return horasEstacionado * taxaHora;
        }

        /** Regista o início do estacionamento do Veículo */
        public void EstacionaVeiculo(Veiculo veiculoEstaciona)
        {
            if (SetorCheio()) /// Verifica se o Setor está já cheio
            {
                Console.WriteLine();
                Console.WriteLine($"O Setor {NomeSetor} está cheio");
                return;
            }

            if (!TiposVeiculosPermitidos.Contains(veiculoEstaciona.VeiculoTipo)) /// Verifica se o Setor permite o tipo de veiculo
            {
                Console.WriteLine();
                Console.WriteLine($"O Setor {NomeSetor} não permite veículos do tipo {veiculoEstaciona.VeiculoTipo}");
                return;
            }

            veiculoEstaciona.Entrada = DateTime.Now;
            veiculoEstaciona.TaxaEstacionamento = CalcularPagamentoParque(PagamentoHoraPorTipoVeiculo[veiculoEstaciona.VeiculoTipo], veiculoEstaciona.Entrada);
            Veiculos.Add(veiculoEstaciona);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Impressão do Ticket de Estacionamento...");
            Console.WriteLine("\n+----------------------------------+");
            Console.WriteLine($"|    Ticket de Estacionamento      |");
            Console.WriteLine("+------------+---------------------+");
            Console.WriteLine($"|   Setor    | {NomeSetor,-19} |");
            Console.WriteLine("+------------+---------------------+");
            Console.WriteLine($"|   Entrada  | {DateTime.Now,-18} |");
            Console.WriteLine("+------------+---------------------+");
        }

        /** Regista a Saída do veiculo do estacionamento */
        public void FimEstacionamentoVeiculo(string matriculaVeiculo)
        {
            Veiculo veiculoRemover = Veiculos.Find(v => v.MatriculaVeiculo == matriculaVeiculo);
            if (veiculoRemover != null)
            {
                DateTime saida = DateTime.Now;
                TimeSpan tempoParque = saida - veiculoRemover.Entrada;
                decimal horasEstacionado = (decimal)tempoParque.TotalHours;
                veiculoRemover.TaxaEstacionamento = horasEstacionado * PagamentoHoraPorTipoVeiculo[veiculoRemover.VeiculoTipo];

                /// Cria Registo Estacionamento antes de remover o veiculo do Estacionamento
                RegistoEstacionamento registoEstacionamento = new RegistoEstacionamento(veiculoRemover, veiculoRemover.Entrada, saida, veiculoRemover.TaxaEstacionamento);
                HistoricoParque.Add(registoEstacionamento);

                Veiculos.Remove(veiculoRemover);
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Impressão do Fatura de Estacionamento...");
                Console.WriteLine("\n+-------------------------------------------+");
                Console.WriteLine($"|    Fatura do Veículo {matriculaVeiculo,-20} |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine("|        Setor        |         Taxa        |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine($"| {NomeSetor,-19} |      €{veiculoRemover.TaxaEstacionamento,-13:0.00} |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine("|       Entrada       |         Saída       |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine($"| {veiculoRemover.Entrada,-19} | {saida,-19} |");
                Console.WriteLine("+---------------------+---------------------+");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Veiculo não foi encontrado no {NomeSetor}");
            }
        }

    }
    
}

