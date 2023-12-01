/**
 * \brief Trabalho de Programação Orientada Por objectos 
 * \details Parque de Estacionamento de um Hospital
 * \author Miguel António Costa Macedo, aluno 26046
 * \file ParqueHospitalar.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPOO_a26046
{
    public class ParqueHospitalar
    {
        /** Registos do Parque do Estacionamento do Hospital */
        public List<SetorParque> SetoresParque { get; private set; }
        public List<VeiculoFuncionario> VeiculosFuncionarios { get; private set; }  /// Lista dos veículos dos funcionários

        public ParqueHospitalar()
        {
            SetoresParque = new List<SetorParque>();
            VeiculosFuncionarios = new List<VeiculoFuncionario>();
        }

        /** Adiciona o novo Setor */
        public void AdicionaSetor(SetorParque setorAd)
        {
            SetoresParque.Add(setorAd);
        }

        /** Verifica se a Matrícula já existe nos veículos já estacionados */
        public bool VerificarPorMatriculasExistentes(string matriculaVeiculo)
        {
            /// Verifica se já existe a matrícula em todos os setores existentes
            foreach (var setor in SetoresParque)
            {
                if (setor.Veiculos.Exists(veiculo => veiculo.MatriculaVeiculo == matriculaVeiculo))
                {
                    return true; /// Matrícula já existente
                }
            }
            return false; /// A Matrícula ainda não existe
        }

        //* Adiciona veiculo de Funcionario à listagem dos veiculos de funcionários com direito a desconto */
        public void AdicionaVeiculoFuncionario(VeiculoFuncionario novoVeiculoFuncionario)
        {
            // Verifica se a matrícula já existe
            if (VeiculosFuncionarios.Any(f => f.MatriculaFuncionario == novoVeiculoFuncionario.MatriculaFuncionario))
            {
                Console.WriteLine("Já existe um funcionário com essa matrícula.");
            }
            else
            {
                // Adiciona o funcionário à lista
                VeiculosFuncionarios.Add(novoVeiculoFuncionario);

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
                Console.WriteLine($"| Adicionado com sucesso o Funcionário do veículo com a matrícula: {novoVeiculoFuncionario.MatriculaFuncionario,-19} |");
                Console.WriteLine("+-------------------------------------------------------+------------------------------+");
                Console.WriteLine("|               Nome do Funcionário                     |   Profissão do Funcionario   |");
                Console.WriteLine("+-------------------------------------------------------+------------------------------+");
                Console.WriteLine($"| {novoVeiculoFuncionario.NomeFuncionario,-53} | {novoVeiculoFuncionario.ProfissaoFuncionario,27}  |");
                Console.WriteLine("+-------------------------------------------------------+------------------------------+");
            }
        }

        //* Remove veiculo de Funcionario da listagem dos veiculos dos funcionários com direito a desconto */
        public void RemoveVeiculoFuncionario(string matriculaFuncionario)
        {

            /// Procura o funcionário pela matrícula para remover
            VeiculoFuncionario veiculoRemover = VeiculosFuncionarios.FirstOrDefault(vf => vf.MatriculaFuncionario == matriculaFuncionario);

            if (matriculaFuncionario != null)
            {
                VeiculosFuncionarios.Remove(veiculoRemover);

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
                Console.WriteLine($"| Removido com sucesso o Funcionário com o veículo com a matrícula: {matriculaFuncionario,-18} |");
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
                Console.WriteLine($"|   Nenhum Funcionário com a matrícula {matriculaFuncionario,-18}. Verifique a matrícula   |");
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
            }

        }

        //* Altera veiculo de Funcionario da listagem dos veiculos dos funcionários com direito a desconto */
        public void AlteraVeiculoFuncionario(string matriculaFuncionario)
        {

            /// Procura o funcionário pela matrícula para alterar
            VeiculoFuncionario veiculoAlterar = VeiculosFuncionarios.FirstOrDefault(vf => vf.MatriculaFuncionario == matriculaFuncionario);

            if (veiculoAlterar != null)
            {
                Console.Write("Alterar dados do Nome para (deixar em branco se quiser manter o nome): ");
                string novoNome = Console.ReadLine();
                veiculoAlterar.NomeFuncionario = string.IsNullOrWhiteSpace(novoNome) ? veiculoAlterar.NomeFuncionario : novoNome;
                if (novoNome != null)
                {
                    novoNome = veiculoAlterar.NomeFuncionario;
                }

                Console.Write("Alterar Matrícula do Veículo para (deixar em branco se quiser manter Matrícula): ");
                string novaMatricula = Console.ReadLine();
                veiculoAlterar.MatriculaFuncionario = string.IsNullOrWhiteSpace(novaMatricula) ? veiculoAlterar.MatriculaFuncionario : novaMatricula;
                if (novaMatricula != null)
                {
                    novaMatricula = veiculoAlterar.MatriculaFuncionario;
                }

                Console.Write("Alterar a Profissão para (deixar em branco se quiser manter Profissão): ");
                string novaProfissao = Console.ReadLine();
                veiculoAlterar.ProfissaoFuncionario = string.IsNullOrWhiteSpace(novaProfissao) ? veiculoAlterar.ProfissaoFuncionario : novaProfissao;
                if (novaProfissao != null)
                {
                    novaProfissao = veiculoAlterar.ProfissaoFuncionario;
                }

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
                Console.WriteLine($"| Alterado com sucesso dados de {matriculaFuncionario,-19} para matrícula {novaMatricula,19} |");
                Console.WriteLine("+-------------------------------------------------------+------------------------------+");
                Console.WriteLine("|               Nome do Funcionário                     |   Profissão do Funcionario   |");
                Console.WriteLine("+-------------------------------------------------------+------------------------------+");
                Console.WriteLine($"| {novoNome,-53} |  {novaProfissao,26}  |");
                Console.WriteLine("+-------------------------------------------------------+------------------------------+");
            }
            else
            {
                Console.WriteLine($"Funcionário com o veículo {matriculaFuncionario} não encontrado. Verifique a matrícula.");
            }

        }

        //* Verifica se o veiculo pertence a um funcionario e devolve true se pertencer, false se não */
        public bool VeiculoPertenceFuncionario(string matriculaVeiculo)
        {
            return VeiculosFuncionarios.Any(vf => vf.MatriculaFuncionario == matriculaVeiculo);
        }
    }
}