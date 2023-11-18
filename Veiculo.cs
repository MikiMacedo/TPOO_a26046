/**
 * \brief Trabalho de Programação Orientada Por objectos 
 * \details Parque de Estacionamento de um Hospital
 * \author Miguel António Costa Macedo, aluno 26046
 * \file Veiculo.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPOO_a26046
{
    // Dados do Veículo ao estacionar
    public class Veiculo
    {
        public string MatriculaVeiculo { get; set; }
        public string VeiculoTipo { get; set; }
        public DateTime Entrada { get; set; }
        public decimal TaxaEstacionamento { get; set; }
    }
    
}