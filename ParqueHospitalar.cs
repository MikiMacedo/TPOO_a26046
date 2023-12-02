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
        public bool VeiculoRemovido { get; set; }

        public ParqueHospitalar()
        {
            SetoresParque = new List<SetorParque>();
            VeiculosFuncionarios = new List<VeiculoFuncionario>();
            VeiculoRemovido = false;
        }

        /** Adiciona o novo Setor */
        public void AdicionaSetor(SetorParque setorAd)
        {
            SetoresParque.Add(setorAd);
        }

        /** Verifica se a Matrícula já existe nos veículos já estacionados */
        public bool VerificarPorMatriculasExistentes(string matriculaVeiculo)
        {
            foreach (var setor in SetoresParque) // Verifica se já existe a matrícula em todos os setores existentes
            {
                if (setor.Veiculos.Exists(veiculo => veiculo.MatriculaVeiculo == matriculaVeiculo))
                {
                    return true; // Matrícula já existente
                }
            }
            return false; // A Matrícula ainda não existe
        }

        /** Adiciona veiculo de Funcionario à listagem dos veiculos de funcionários com direito a desconto */
        public void AdicionaVeiculoFuncionario(VeiculoFuncionario novoVeiculoFuncionario)
        {
            if (VeiculosFuncionarios.Any(f => f.MatriculaFuncionario == novoVeiculoFuncionario.MatriculaFuncionario)) // Verifica se a matrícula já existe
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|      MATRÍCULA JÁ REGISTADA !      |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|    Já exista um funcionário com    |");
                Console.WriteLine("|    com a matrícula indicada...     |");
                Console.WriteLine("+------------------------------------+"); 
            }
            else
            {
                VeiculosFuncionarios.Add(novoVeiculoFuncionario); // Adiciona o funcionário à lista

                Console.Clear(); // Mostra Relatório com as informações do Novo Funcionário adicionado
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

        /** Remove veiculo de Funcionario da listagem dos veiculos dos funcionários com direito a desconto */
        public void RemoveVeiculoFuncionario(string matriculaFuncionario)
        {
            VeiculoFuncionario veiculoRemover = VeiculosFuncionarios.FirstOrDefault(vf => vf.MatriculaFuncionario == matriculaFuncionario); // Procura o funcionário pela matrícula para remover

            if (veiculoRemover != null) // Verifica se o funcionário foi encontrado
            {
                VeiculosFuncionarios.Remove(veiculoRemover); // Remove Funcionário

                Console.Clear(); // Mostra relatório de Remoção da Matrícula do Funcionário
                Console.WriteLine();
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
                Console.WriteLine($"| Removido com sucesso o Funcionário com o veículo com a matrícula: {matriculaFuncionario,-18} |");
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
            }
            else
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|     MATRICULA NÃO ENCONTRADA     |");
                Console.WriteLine("|                                  |");
                Console.WriteLine("|  Não encontrado Funcionário com  |");
                Console.WriteLine($"|  o veículo {matriculaFuncionario,-20}  |");
                Console.WriteLine("+----------------------------------+");
            }

        }

        /** Altera veiculo de Funcionario da listagem dos veiculos dos funcionários com direito a desconto */
        public void AlteraVeiculoFuncionario(string matriculaFuncionario)
        {
            VeiculoFuncionario veiculoAlterar = VeiculosFuncionarios.FirstOrDefault(vf => vf.MatriculaFuncionario == matriculaFuncionario); // Procura o funcionário pela matrícula para alterar

            if (veiculoAlterar != null) // Verifica a matrícula para alterar foi encontrada
            {
                Console.Write("Alterar dados do Nome para (deixar em branco se quiser manter o nome): ");
                string novoNome = Console.ReadLine();
                veiculoAlterar.NomeFuncionario = string.IsNullOrWhiteSpace(novoNome) ? veiculoAlterar.NomeFuncionario : novoNome; // Verifica se o campo está vazio, se sim os dados antigos serão mantidos
                if (novoNome != null)
                {
                    novoNome = veiculoAlterar.NomeFuncionario; // Guarda os mesmos dados para mostrar
                }

                Console.Write("Alterar Matrícula do Veículo para (deixar em branco se quiser manter Matrícula): ");
                string novaMatricula = Console.ReadLine();
                veiculoAlterar.MatriculaFuncionario = string.IsNullOrWhiteSpace(novaMatricula) ? veiculoAlterar.MatriculaFuncionario : novaMatricula; // Verifica se o campo está vazio, se sim os dados antigos serão mantidos
                if (novaMatricula != null)
                {
                    novaMatricula = veiculoAlterar.MatriculaFuncionario; // Guarda os mesmos dados para mostrar
                }

                Console.Write("Alterar a Profissão para (deixar em branco se quiser manter Profissão): ");
                string novaProfissao = Console.ReadLine();
                veiculoAlterar.ProfissaoFuncionario = string.IsNullOrWhiteSpace(novaProfissao) ? veiculoAlterar.ProfissaoFuncionario : novaProfissao; // Verifica se o campo está vazio, se sim os dados antigos serão mantidos
                if (novaProfissao != null)
                {
                    novaProfissao = veiculoAlterar.ProfissaoFuncionario; // Guarda os mesmos dados para mostrar
                }

                Console.Clear(); // Mostra Relatório das novas informações do Funcionário
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
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
                Console.WriteLine($"|   Nenhum Funcionário com a matrícula {matriculaFuncionario,-18}. Verifique a matrícula   |");
                Console.WriteLine("+--------------------------------------------------------------------------------------+");
            }

        }

        /** Verifica se o veiculo pertence a um funcionario e devolve true se pertencer, false se não */
        public bool VeiculoPertenceFuncionario(string matriculaVeiculo)
        {
            return VeiculosFuncionarios.Any(vf => vf.MatriculaFuncionario == matriculaVeiculo); // Devolve se o veículo pertence a funcionário ou não 'True' se matrícula é de um funcionario, 'False' se não for
        }
    }
}