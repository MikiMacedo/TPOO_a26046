/**
 * \brief Trabalho de Programação Orientada Por objectos 
 * \details Parque de Estacionamento de um Hospital
 * \author Miguel António Costa Macedo, aluno 26046
 * \file RegistoEstacionamento.cs
 */

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
        public decimal DescontoAplicado { get; set; }
        public string SetorEstacionado { get; set; } 

        /** Dados do Estacionamento do Veículo */
        public RegistoEstacionamento(Veiculo veiculo, DateTime entrada, DateTime saida, decimal taxaEstacionamento, decimal descontoAplicado, string setorEstacionado)
        {
            Veiculo = veiculo;
            Entrada = entrada;
            Saida = saida;
            TaxaEstacionamento = taxaEstacionamento;
            DescontoAplicado = descontoAplicado;
            SetorEstacionado = setorEstacionado;
        }

    
    }

}


