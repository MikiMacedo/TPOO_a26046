/* Trabalho de Programação Orientada Por objectos 
* Miguel António Costa Macedo, aluno 26046
* Fase 1 TPOO_a26046 - Registos do Parque - RegistoEstacionamento.cs*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPOO_a26046
{
    public class RegistoEstacionamento
    {
        public Veiculo Veiculo { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public decimal TaxaEstacionamento { get; set; }

        //Registo do Estacionamento do Veículo
        public RegistoEstacionamento(Veiculo veiculo, DateTime entrada, DateTime saida, decimal taxaEstacionamento)
        {
            Veiculo = veiculo;
            Entrada = entrada;
            Saida = saida;
            TaxaEstacionamento = taxaEstacionamento;
        }
    }
 
}

