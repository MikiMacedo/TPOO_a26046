/**
 * \brief Trabalho de Programação Orientada Por objectos 
 * \details Parque de Estacionamento de um Hospital
 * \author Miguel António Costa Macedo, aluno 26046
 * \file VeiculosFuncionários.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPOO_a26046
{
    /// Dados dos Veículos dos Funcionários
    public class VeiculoFuncionario
    {
        public string NomeFuncionario { get; set; }
        public string MatriculaFuncionario { get; set; }
        public string ProfissaoFuncionario { get; set; }

        public VeiculoFuncionario(string NomeFuncionario, string MatriculaFuncionario, string ProfissaoFuncionario)
        {
            NomeFuncionario = nomeFuncionario;
            MatriculaFuncionario = matriculaFuncionario;
            ProfissaoFuncionario = profissaoFuncionario;
        }
    }
}
