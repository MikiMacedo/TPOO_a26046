/**
 * \brief Trabalho de Programação Orientada Por objectos 
 * \details Parque de Estacionamento de um Hospital
 * \author Miguel António Costa Macedo, aluno 26046
 * \file program.cs 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TPOO_a26046
{
    class Program
    {
        static void Main()
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8; // Solução para sair o simbolo de € e carateres especiais, encontrada em stackoverflow.com/questions/7929763/how-do-i-write-special-characters-0x80-0x9f-to-the-windows-console

            ParqueHospitalar parqueHospital = new ParqueHospitalar();

            List<string> TiposDeVeiculos = new List<string> { "Motociclo", "Carro", "Carrinha", "Camião" }; // Define os tipos de Veículos para listagem
           
            while (true)
            {
                /** Estatística de todos os setores existentes no ecrão inicial */
                Console.Clear();
                Console.WriteLine("\n+----------------------------------------------------------------+");
                Console.WriteLine("|    Estatísticas do Parque de Estacionamento do Hospital        |");
                Console.WriteLine("+----------------------------------------------------------------+");
                Console.WriteLine("|      Nome do Setor      |  Estacionados  | Cheio? | % Desconto |");
                Console.WriteLine("+----------------------------------------------------------------+");

                if (parqueHospital.SetoresParque.Count == 0) // Não há setores ainda
                {
                    Console.WriteLine("|           Ainda não Existem Setores de Estacionamento          |");
                    Console.WriteLine("+----------------------------------------------------------------+");
                }
                else
                {
                    string setorEstaCheio;
                    foreach (var nomeSetor in parqueHospital.SetoresParque) // Mostra tabela dos setores existentes
                    {
                        if (nomeSetor.SetorCheio()) // Transformar um valor booleano em "Sim" ou "Não" para indicar se o setor está cheio
                        {
                            setorEstaCheio = "Sim";
                        }
                        else
                        {
                            setorEstaCheio = "Não";
                        }
                        Console.WriteLine($"| {nomeSetor.NomeSetor,-23} |       {nomeSetor.Veiculos.Count,8} | {setorEstaCheio,6} | {nomeSetor.PercentagemDescontoFuncionarios,7} %  |"); // Faz a tabela com os dados dos setores, os valores são para definir o tamanho na tabela, negativos alinhados à esquerda, positivos alinhados à direita
                    }
                    Console.WriteLine("+----------------------------------------------------------------+");
                }

                /** Menu do Sistema de Parqueamento */
                Console.WriteLine("\n+----------------------------------------------------------------+");
                Console.WriteLine("|    Sistema de Gestão do Parque de Estacionamento do Hospital   |");
                Console.WriteLine("+---+------------------------------------------------------------+");
                Console.WriteLine("| 1 |  Menu de Gestão                                            |");
                Console.WriteLine("| 2 |  Menu de Utilizador                                        |");
                Console.WriteLine("| 3 |  Menu de Estatísticas                                      |");
                Console.WriteLine("| 0 |  Sair do Sistema                                           |");
                Console.WriteLine("+---+------------------------------------------------------------+");
                Console.WriteLine(" ");
                Console.Write("    Escolhe uma opção de 0 a 3: ");

                ConsoleKeyInfo opcaoMenu = Console.ReadKey(); // Recebe a tecla carregada para opção

                switch ((char)opcaoMenu.Key)
                {
                    case '1':
                        /** Menu de Gestão */
                        MenuGerirParque(parqueHospital, TiposDeVeiculos);
                        break;

                    case '2':
                        /** Menu do Utilizador do Parque (Estacionar e Remover o veículo do Estacionamento */
                        MenuUtilizador(parqueHospital, TiposDeVeiculos);
                        break;

                    case '3':
                        /** Menu de Estatísticas e Informações sobre o Parque de Estacionamento e seus setores */
                        Console.WriteLine();
                        MenuEstatisticas(parqueHospital);
                        break;

                    case '0':
                        /** Sai do Programa de Gestão do Sistema do Parque Hospitalar */
                        return;

                    default:
                        Console.WriteLine("Escolha inválida, por favor, escolha entre 0 e 3");
                        break;
                }
            }
        }

        /** Menu de Gestão do Sistema do Parque */
        static void MenuGerirParque(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n+---------------------------------------------------------+");
                Console.WriteLine("|  Menu de Gestão                                         |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine("| 1 |  Adicionar Setor do Parque                          |");
                Console.WriteLine("| 2 |  Remover Setor do Parque                            |");
                Console.WriteLine("| 3 |  Alterar Setor do Parque                            |");
                Console.WriteLine("| 4 |  Adicionar Veículo de Funcionário para Desconto     |");
                Console.WriteLine("| 5 |  Remover Veículo de Funcionário do Desconto         |");
                Console.WriteLine("| 6 |  Alterar Veículo de Funcinário para Desconto        |");
                Console.WriteLine("| 0 |  Voltar ao Menu Principal                           |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine();
                Console.Write("    Escolhe uma opção de 0 a 3: ");

                ConsoleKeyInfo opcaoGestao = Console.ReadKey(); // Recebe a tecla carregada para opção

                switch ((char)opcaoGestao.Key)
                {
                    case '1':
                        /** Adicionar um novo Setor ao Parque */
                        Console.WriteLine();
                        AdicionarSetor(parqueHospital, TiposDeVeiculos);
                        CarregaTecla();
                        break;

                    case '2':
                        /** Remover um Setor do Parque */
                        Console.WriteLine();
                        RemoverSetor(parqueHospital);
                        CarregaTecla();
                        break;

                    case '3':
                        /** Alterar um Setor já existente do Parque */
                        Console.WriteLine();
                        AlterarSetor(parqueHospital, TiposDeVeiculos);
                        CarregaTecla();
                        break;

                    case '4':
                        /** Adicionar Veículo de Funcionário do Hospital com direito a Desconto */
                        Console.WriteLine();
                        AdicionarVeiculoFuncionario(parqueHospital);
                        CarregaTecla();
                        break;

                    case '5':
                        /** Remover um Veículo de Funcionário do Hospital com direito a Desconto */
                        Console.WriteLine();
                        RemoverVeiculoFuncionario(parqueHospital);
                        CarregaTecla();
                        break;
                    
                    case '6':
                        /** Alterar Veículo de Funcionário do Hospital com direito a Desconto */
                        Console.WriteLine();
                        AlterarVeiculoFuncionario(parqueHospital);
                        CarregaTecla();
                        break;

                    case '0':
                        /** Volta ao Menu Principal */
                        return;

                    default:
                        break;
                }
            }
        }

        /** Menu do Utilizador do Parque (Estacionar e Remover o veículo no Parque) */
        static void MenuUtilizador(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n+---------------------------------------------------------+");
                Console.WriteLine("|  Menu de Utilizador                                     |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine("| 1 |  Estacionar Veículo                                 |");
                Console.WriteLine("| 2 |  Remover Veiculo do Estacionamento                  |");
                Console.WriteLine("| 0 |  Voltar ao Menu Principal                           |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine(" ");
                Console.Write("    Escolhe uma opção de 0 a 2: ");

                ConsoleKeyInfo opcaoUtilizador = Console.ReadKey(); // Recebe a tecla carregada para opção

                switch ((char)opcaoUtilizador.Key)
                {
                    case '1':
                        /** Estacionar o veiculo no Parque */
                        Console.WriteLine();
                        EstacionarVeiculo(parqueHospital, TiposDeVeiculos);
                        CarregaTecla();
                        break;

                    case '2':
                        /** Remover o veículo do estacionamento do Parque e pagar Estacionamento */
                        Console.WriteLine();
                        RemoverVeiculo(parqueHospital);
                        CarregaTecla();
                        break;

                    case '0':
                        /** Volta ao Menu Principal */
                        return;

                    default:
                        break;
                }
            }
        }

        /** Menu para Mostrar as Estatísticas do Parque */
        static void MenuEstatisticas(ParqueHospitalar parqueHospital)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n+---------------------------------------------------------+");
                Console.WriteLine("|  Menu de Estatísticas do Parque                         |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine("| 1 |  Estatísticas dos Setores                           |");
                Console.WriteLine("| 2 |  Estatísticas dos Veiculos no Estacionamento        |");
                Console.WriteLine("| 3 |  Histórico de Pagamentos por Veículo                |");
                Console.WriteLine("| 4 |  Total de Receita do Parque de Estacionamento       |");
                Console.WriteLine("| 5 |  Listar Funcionários com direito a desconto         |");
                Console.WriteLine("| 0 |  Voltar ao Menu de Gestão                           |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine(" ");
                Console.Write("    Escolhe uma opção de 0 a 4: ");


                ConsoleKeyInfo opcaoEstatitica = Console.ReadKey(); // Recebe a tecla carregada para opção

                switch ((char)opcaoEstatitica.Key)
                {
                    case '1':
                        /** Estatísticas do Setor */
                        EstatisticasSetor(parqueHospital);
                        break;

                    case '2':
                        /** Menu das Estatísticas dos Veículos */
                        MenuEstatisticasVeiculos(parqueHospital);
                        break;

                    case '3':
                        /** Histórico de Estacionamento por Matrícula de veículo */
                        MostrarHistoricoVeiculo(parqueHospital);
                        break;

                    case '4':
                        /** Mostrar o total de receitas do Parque (Total de Pagamentos de todos os Setores) */
                        MostrarTotalPagamentosParque(parqueHospital);
                        break;

                    case '5':
                        /** Lista Veículos de Funcionário do Hospital com direito a Desconto */
                        Console.WriteLine();
                        ListarFuncionarios(parqueHospital);
                        CarregaTecla();
                        break;

                    case '0':
                        /** Volta ao Menu Principal */
                        return;

                    default:
                        break;
                }
            }
        }

        /** Menu das Estatísticas dos Veículos */
        static void MenuEstatisticasVeiculos(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+---------------------------------------------------------+");
            Console.WriteLine("|  Menu de Estatísticas dos Veículos                      |");
            Console.WriteLine("+---+-----------------------------------------------------+");
            Console.WriteLine("| 1 |  Listar Todos os Veiculos Estacionados              |");
            Console.WriteLine("| 2 |  Listar Veiculos por Setor                          |");
            Console.WriteLine("| 0 |  Voltar ao Menu de Estatísticas                     |");
            Console.WriteLine("+---+-----------------------------------------------------+");
            Console.WriteLine(" ");
            Console.Write("    Escolhe uma opção de 0 a 2: ");

            ConsoleKeyInfo opcaoEstatisticaVeiculos = Console.ReadKey(); // Recebe a tecla carregada para opção

            switch ((char)opcaoEstatisticaVeiculos.Key)
            {
                case '1':
                    /** Lista todos os Veículos que ainda estão no estacionamento (ainda não pagaram nem sairam do Parque) */
                    ListaTodosVeiculos(parqueHospital);
                    break;

                case '2':
                    /** Lista os Veiculos estacionados por Setor (que ainda não pagaram nem sairam do Parque) */
                    ListaVeiculosPorSetor(parqueHospital);
                    break;

                case '0':
                    /** Volta ao Menu de Estatísticas */
                    return;

                default:
                    break;
            }
        }

        /** Adicionar um novo setor */
        static void AdicionarSetor(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+------------------------------------+");
            Console.WriteLine("|  Adicionar um Novo Setor ao Parque |");
            Console.WriteLine("+------------------------------------+"); 
            Console.WriteLine();
            Console.Write("Nome do Setor: ");  // Para escrever o nome do novo Setor
            string nomeSetor = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(nomeSetor)) // Verifica se o nome do setor não está vazio, se estiver mostra mensagem de erro
            {
                if (parqueHospital.SetoresParque.Any(setor => setor.NomeSetor == nomeSetor)) // Verifica se já existe um Setor com o mesmo nome, para evitar repetição do nome
                {
                    Console.Clear(); // Mensagem de Erro
                    Console.WriteLine();
                    Console.WriteLine("\n+------------------------------------+");
                    Console.WriteLine("|          SETOR JÁ EXISTE!          |");
                    Console.WriteLine("|                                    |");
                    Console.WriteLine("|      Tem que inserir um nome,      |");
                    Console.WriteLine("|      diferente do existente...     |");
                    Console.WriteLine("+------------------------------------+");
                    return;
                }
                else
                {
                    Console.Write("Capacidade do Setor: "); // Para definir a capacidade do Setor
                    if (int.TryParse(Console.ReadLine(), out int capacidadeSetor))
                    {
                        Console.Write("Desconto para Funcionários no Setor: "); // Para definir a desconto dos funcionários no Setor
                        if (decimal.TryParse(Console.ReadLine(), out decimal percentagemDescontoFuncionarios))
                        {
                            if (percentagemDescontoFuncionarios >= 0 && percentagemDescontoFuncionarios <= 100) // Verifica se foi inserido um Desconto para Funcionário Válido (entre 0 e 100)
                            {
                                List<string> tipoVeiculosPermitidos = RetiraTipoVeiculosPermitidos(TiposDeVeiculos); // Para definir os tipos de veículos permitidos no Setor
                                if (tipoVeiculosPermitidos.Count == 0) // Verifica se há tipos de carros inseridos válidos e senão mostra mensagem de erro
                                {
                                    Console.Clear(); // Mensagem de Erro
                                    Console.WriteLine();
                                    Console.WriteLine("\n+------------------------------------+");
                                    Console.WriteLine("|     TIPO DE VEICULO NECESSÁRIO     |");
                                    Console.WriteLine("|                                    |");
                                    Console.WriteLine("|   Tem que escolher, pelo menos,    |");
                                    Console.WriteLine("|       um tipo de veiculo...        |");
                                    Console.WriteLine("+------------------------------------+");
                                    return;
                                }
                                Dictionary<string, decimal> pagamentoHora = RetiraPagamentoHora(tipoVeiculosPermitidos);
                                if (pagamentoHora.Count == 0) // Verifica se foi inserido o custo/hora válido e se não mostra mensagem de erro
                                {
                                    Console.Clear(); // Mensagem de Erro
                                    Console.WriteLine();
                                    Console.WriteLine("\n+------------------------------------+");
                                    Console.WriteLine("|      NECESSÁRIO O CUSTO/HORA!      |");
                                    Console.WriteLine("|                                    |");
                                    Console.WriteLine("| É preciso colocar quanto um número |");
                                    Console.WriteLine("| válido para o custo/hora do setor. |");
                                    Console.WriteLine("+------------------------------------+");
                                    return;
                                }


                                SetorParque novoSetor = new SetorParque(nomeSetor, capacidadeSetor, pagamentoHora, tipoVeiculosPermitidos, percentagemDescontoFuncionarios);
                                parqueHospital.AdicionaSetor(novoSetor); // Adiciona Novo Setor
                                Console.Clear(); // Imprime relatório com informações do Novo Setor
                                Console.WriteLine();
                                Console.WriteLine("\n+------------------------------------+");
                                Console.WriteLine("|  ADICIONADO NOVO SETOR AO PARQUE   |");
                                Console.WriteLine("|   DE ESTACIONAMENTO DO HOSPITAL    |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|   Nome do Setor   |   Capacidade   |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine($"|  {nomeSetor,-15}  |  {capacidadeSetor,12}  |");
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine("|  Tipo de Veículo  |   Taxa/Hora    |");
                                Console.WriteLine("+------------------------------------+");
                                foreach (var tipoVeiculo in pagamentoHora.Keys)
                                {
                                    Console.WriteLine($"|  {tipoVeiculo,-15}  |  {pagamentoHora[tipoVeiculo],11:0,000.00}€  |");
                                }
                                Console.WriteLine("+------------------------------------+");
                                Console.WriteLine($"| Desconto para Funcionários: {percentagemDescontoFuncionarios,5}% |");
                                Console.WriteLine("+------------------------------------+");
                            }
                            else
                            {
                                Console.Clear(); // Mensagem de Erro
                                Console.WriteLine();
                                Console.WriteLine("\n+------------------------------------+");
                                Console.WriteLine("|         DESCONTO INVÁLIDO!         |");
                                Console.WriteLine("|                                    |");
                                Console.WriteLine("|     A percentagem de desconto      |");
                                Console.WriteLine("|    deve ser entre 0% e 100%...     |");
                                Console.WriteLine("+------------------------------------+");
                                return;
                            }
                        }
                        else
                        {
                            Console.Clear(); // Mensagem de Erro
                            Console.WriteLine();
                            Console.WriteLine("\n+------------------------------------+");
                            Console.WriteLine("|         DESCONTO INVÁLIDO!         |");
                            Console.WriteLine("|                                    |");
                            Console.WriteLine("|   A percentagem de desconto deve   |");
                            Console.WriteLine("|   número válido entre 0 e 100...   |");
                            Console.WriteLine("+------------------------------------+");
                            return;
                        }
                    }
                    else
                    {
                        Console.Clear(); // Mensagem de Erro
                        Console.WriteLine();
                        Console.WriteLine("\n+------------------------------------+");
                        Console.WriteLine("|        CAPACIDADE INVÁLIDA!        |");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("|     A capacidade é inválida...     |");
                        Console.WriteLine("|      Coloque número válido...      |");
                        Console.WriteLine("+------------------------------------+");
                        return;
                    }
                }
            }
            else
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|      NOME DE SETOR INVÁLIDO !      |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|   O nome do setor não pode estar   |");
                Console.WriteLine("|  vazio, escreva um nome válido...  |");
                Console.WriteLine("+------------------------------------+");
                return;
            }
        }


        /** Remover um dos setores que existe */
        static void RemoverSetor(ParqueHospitalar parqueHospital)
        {
            bool verificaSetor = false;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+------------------------------------+");
            Console.WriteLine("|     Remover um Setor ao Parque     |");
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine();
            Console.WriteLine("Setores Disponíveis:");
            for (int i = 0; i < parqueHospital.SetoresParque.Count; i++)
            {
                string estadoEstacionamento = parqueHospital.SetoresParque[i].Veiculos.Count > 0 ? "Tem veículos estacionados" : "Vazio, pode remover";
                Console.WriteLine(" " + (i + 1) + " - " + parqueHospital.SetoresParque[i].NomeSetor + " (" + estadoEstacionamento + ").");
                verificaSetor = true; // Para verificar se há setores, true significa que foi encontrados o setores, false quando não há setores registados
            }

            if (!verificaSetor) // Não existem Setores
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+----------------------------------------+");
                Console.WriteLine("|       SEM SETORES PARA REMOVER !       |");
                Console.WriteLine("+----------------------------------------+");
                return;
            }

            Console.Write("Coloque o número do setor a remover, conforme tabela, ou qualquer outros para desistir: ");  // Existem Setores para remover, para escolher o que se quer remover
            if (int.TryParse(Console.ReadLine(), out int nomeSetor) && nomeSetor >= 1 && nomeSetor <= parqueHospital.SetoresParque.Count) // Verifica se Setor escolhido é válido
            {
                int refSetorRemover = nomeSetor - 1;
                if (parqueHospital.SetoresParque[refSetorRemover].Veiculos.Count > 0) //  Verifica se há veículos estacionados, se sim, não deixa remover e mostra mensagem de erro
                {
                    Console.Clear(); // Mensagem de Erro
                    Console.WriteLine();
                    Console.WriteLine("\n+----------------------------------------+");
                    Console.WriteLine("| SETOR QUE TENTOU REMOVER TEM VEICULOS! |");
                    Console.WriteLine("|                                        |");
                    Console.WriteLine("| Deve remover veiculos antes de remover |");
                    Console.WriteLine($"| do Parque o setor {parqueHospital.SetoresParque[refSetorRemover].NomeSetor,-20} |");


                    Console.WriteLine("+----------------------------------------+");
                }
                else
                { 
                    if (refSetorRemover >= 0 && refSetorRemover < parqueHospital.SetoresParque.Count) // Verifica se Setor escolhido existe para remover
                    {
                        string setorRemovido = parqueHospital.SetoresParque[refSetorRemover].NomeSetor; // antes de remover o setor guarda o seu nome para imprimir no ecrã na mensagem de remoção
                        parqueHospital.SetoresParque.RemoveAt(refSetorRemover); // Remove o setor escolhido

                        Console.Clear(); // Relatório com informação sobre o setor removido
                        Console.WriteLine();
                        Console.WriteLine("\n+------------------------------------+");
                        Console.WriteLine("|      FOI REMOVIDO DO PARQUE DE     |");
                        Console.WriteLine("|      ESTACIONAMENTO DO HOSPITAL    |");
                        Console.WriteLine("+------------------------------------+");
                        Console.WriteLine("|        Nome do Setor removido      |");
                        Console.WriteLine("+------------------------------------+");
                        Console.WriteLine($"|     {setorRemovido,-26}     |");
                        Console.WriteLine("+------------------------------------+");
                    }
                    else
                    {
                        Console.Clear(); // Mensagem de Erro, Número inválido, logo pode indicar desistância da remoção
                        Console.WriteLine();
                        Console.WriteLine("\n+------------------------------------+");
                        Console.WriteLine("|      DESISTÊNCIA DA REMOÇÃO !      |");
                        Console.WriteLine("|                                    |"); 
                        Console.WriteLine("|    Se realmente deseja remover,    |");
                        Console.WriteLine("|    coloque um número válido...     |");
                        Console.WriteLine("+------------------------------------+");
                    }
                }
                
            }
            else
            {
                Console.Clear(); // Mensagem de Erro, Número inválido, logo pode indicar desistância da remoção
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|      DESISTÊNCIA DA REMOÇÃO !      |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|    Se realmente deseja remover,    |");
                Console.WriteLine("|    coloque um número válido...     |");
                Console.WriteLine("+------------------------------------+");
            }
        }

        /** Alterar um dos setores existentes */
        static void AlterarSetor(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            if (parqueHospital.SetoresParque.Count == 0) // Verifica se já há setores
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+-----------------------------------+");
                Console.WriteLine("|    NÃO HÁ SETORES REGISTADOS !    |");
                Console.WriteLine("|                                   |");
                Console.WriteLine("|    Tem que adicionar setores...   |");
                Console.WriteLine("+-----------------------------------+");
            }
            else
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|     Alterar um Setor Existente     |");
                Console.WriteLine("+------------------------------------+");
                Console.WriteLine();
                Console.Write("Nome do Setor a ser alterado: ");
                string nomeSetor = Console.ReadLine();

                SetorParque setorExistente = parqueHospital.SetoresParque.FirstOrDefault(s => s.NomeSetor == nomeSetor); // Procura o setor pelo nome

                if (setorExistente != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Novas informações para o setor:");

                    Console.Write("Novo Nome do Setor: ");
                    string novoNomeSetor = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(novoNomeSetor)) // Verifica se o nome está vazio
                    {
                        if ((nomeSetor != novoNomeSetor) && (parqueHospital.SetoresParque.Any(setor => setor.NomeSetor == nomeSetor))) // Verifica se o nome já existe, se sim, mostra mensagem de erro
                        {
                            Console.Clear(); // Mensagem de Erro
                            Console.WriteLine();
                            Console.WriteLine("\n+------------------------------------+");
                            Console.WriteLine("|          SETOR JÁ EXISTE!          |");
                            Console.WriteLine("|                                    |");
                            Console.WriteLine("|      Tem que inserir um nome,      |");
                            Console.WriteLine("|      diferente do existente...     |");
                            Console.WriteLine("+------------------------------------+");
                            return;
                        }
                        else
                        {
                            Console.Write("Nova Capacidade do Setor: ");
                            if (int.TryParse(Console.ReadLine(), out int novaCapacidadeSetor)) // Verifica se o número é válido
                            {
                                Console.Write("Novo valor de Desconto para Funcionários no Setor: "); // Para definir a desconto dos funcionários no Setor
                                if (decimal.TryParse(Console.ReadLine(), out decimal novaPercentagemDesconto)) // Verifica é um número válido
                                {
                                    if (novaPercentagemDesconto >= 0 && novaPercentagemDesconto <= 100) // Verifica se o número está entre 0 e 100
                                    {
                                        List<string> novoTipoVeiculosPermitidos = RetiraTipoVeiculosPermitidos(TiposDeVeiculos);
                                        if (novoTipoVeiculosPermitidos.Count == 0) // Verifica se foi inserido algum tipo de veículo, se não, mostra mensagem de erro
                                        {
                                            Console.Clear(); // Mensagem de Erro
                                            Console.WriteLine();
                                            Console.WriteLine("\n+------------------------------------+");
                                            Console.WriteLine("|     TIPO DE VEICULO NECESSÁRIO     |");
                                            Console.WriteLine("|                                    |");
                                            Console.WriteLine("|   Tem que escolher, pelo menos,    |");
                                            Console.WriteLine("|       um tipo de veiculo...        |");
                                            Console.WriteLine("+------------------------------------+");
                                            return;
                                        }

                                        Dictionary<string, decimal> novoPagamentoHora = RetiraPagamentoHora(novoTipoVeiculosPermitidos);
                                        if (novoPagamentoHora.Count == 0) // Verifica se os pagamento para o tipo de veículo é válido
                                        {
                                            Console.Clear(); // Mensagem de Erro
                                            Console.WriteLine();
                                            Console.WriteLine("\n+------------------------------------+");
                                            Console.WriteLine("|      NECESSÁRIO O CUSTO/HORA!      |");
                                            Console.WriteLine("|                                    |");
                                            Console.WriteLine("| É preciso colocar quanto um número |");
                                            Console.WriteLine("| válido para o custo/hora do setor. |");
                                            Console.WriteLine("+------------------------------------+");
                                            return;
                                        }

                                        string antigoNomeSetor = nomeSetor; // Atualiza as informações do setor
                                        setorExistente.NomeSetor = novoNomeSetor;
                                        setorExistente.Capacidade = novaCapacidadeSetor;
                                        setorExistente.TiposVeiculosPermitidos = novoTipoVeiculosPermitidos;
                                        setorExistente.PagamentoHoraPorTipoVeiculo = novoPagamentoHora;
                                        setorExistente.PercentagemDescontoFuncionarios = novaPercentagemDesconto;

                                        Console.Clear(); // Relatório com as informação novas/alteradas do Setor e o antigo nome do Setor
                                        Console.WriteLine("\n+------------------------------------+");
                                        Console.WriteLine("|      SETOR ALTERADO NO PARQUE      |");
                                        Console.WriteLine("|    DE ESTACIONAMENTO DO HOSPITAL   |");
                                        Console.WriteLine("+------------------------------------+");
                                        Console.WriteLine($"|  Antigo Nome: {antigoNomeSetor,-19}  |");
                                        Console.WriteLine("+------------------------------------+");
                                        Console.WriteLine("|   Nome do Setor   |   Capacidade   |");
                                        Console.WriteLine("+------------------------------------+");
                                        Console.WriteLine($"|  {setorExistente.NomeSetor,-15}  |  {setorExistente.Capacidade,12}  |");
                                        Console.WriteLine("+------------------------------------+");
                                        foreach (var tipoVeiculo in novoPagamentoHora.Keys)
                                        {
                                            Console.WriteLine($"|  {tipoVeiculo,-15}  |  {novoPagamentoHora[tipoVeiculo],11:0,000.00}€  |");
                                        }
                                        Console.WriteLine("+------------------------------------+");
                                        Console.WriteLine($"| Desconto para Funcionários: {novaPercentagemDesconto,5}% |");
                                        Console.WriteLine("+------------------------------------+");
                                    }
                                    else
                                    {
                                        Console.Clear(); // Mensagem de Erro
                                        Console.WriteLine();
                                        Console.WriteLine("\n+------------------------------------+");
                                        Console.WriteLine("|         DESCONTO INVÁLIDO!         |");
                                        Console.WriteLine("|                                    |");
                                        Console.WriteLine("|     A percentagem de desconto      |");
                                        Console.WriteLine("|    deve ser entre 0% e 100%...     |");
                                        Console.WriteLine("+------------------------------------+");
                                    }
                                }
                                else
                                {
                                    Console.Clear(); // Mensagem de Erro
                                    Console.WriteLine();
                                    Console.WriteLine("\n+------------------------------------+");
                                    Console.WriteLine("|         DESCONTO INVÁLIDO!         |");
                                    Console.WriteLine("|                                    |");
                                    Console.WriteLine("|     A percentagem de desconto      |");
                                    Console.WriteLine("|    deve ser entre 0% e 100%...     |");
                                    Console.WriteLine("+------------------------------------+");
                                }
                            }
                            else
                            {
                                Console.Clear(); // Mensagem de Erro
                                Console.WriteLine();
                                Console.WriteLine("\n+------------------------------------+");
                                Console.WriteLine("|        CAPACIDADE INVÁLIDA!        |");
                                Console.WriteLine("|                                    |");
                                Console.WriteLine("|     A capacidade é inválida...     |");
                                Console.WriteLine("|      Coloque número válido...      |");
                                Console.WriteLine("+------------------------------------+");
                            }

                        }
                    }
                    else
                    {
                        Console.Clear(); // Mensagem de Erro
                        Console.WriteLine();
                        Console.WriteLine("\n+------------------------------------+");
                        Console.WriteLine("|      NOME DE SETOR INVÁLIDO !      |");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("|      O nome do setor não pode      |");
                        Console.WriteLine("|            estar vazio...          |");
                        Console.WriteLine("+------------------------------------+");
                    }
                }
                else
                {
                    Console.Clear(); // Mensagem de Erro
                    Console.WriteLine();
                    Console.WriteLine("\n+-----------------------------------+");
                    Console.WriteLine("|       SETOR NÃO ENCONTRADO !      |");
                    Console.WriteLine("|                                   |");
                    Console.WriteLine("|    Verifique o nome do setor...   |");
                    Console.WriteLine("+-----------------------------------+");
                }
            }
        }

        /** Para definir os tipos de Veículos Permitidos para estacionar no setor */
        static List<string> RetiraTipoVeiculosPermitidos(List<string> tiposVeiculo)
        {
            Console.WriteLine();
            List<string> tipoVeiculosPermitidos = new List<string>();
            Console.WriteLine("Colocar os tipos de veículos permitidos (número separados por um espaço entre eles):");

            for (int i = 0; i < tiposVeiculo.Count; i++)
            {
                Console.WriteLine(" " + (i + 1) + " - " + tiposVeiculo[i]);
            }

            Console.Write("Coloque os números dos tipos de veiculos permitidos: ");

            var numTiposVeiculosEscolhaTemp = Console.ReadLine();
            try
            {
                var numerosTiposVeiculosEscolha = numTiposVeiculosEscolhaTemp.Split(' ')
                .Select(str => str.Trim())
                .Select(int.Parse)
                .ToList();
            }
            catch (System.FormatException) // Detecta se há um FormatException (caracteres sem sem números e o espaço como separador de números), solução encontrada em stackoverflow.com/questions/12550184/throw-a-format-exception-c-sharp
            {
                Console.WriteLine("   Os números devem ser separados por um espaço, caracteres não permitidos!!!"); // Detecta se o valor é inválido, solução encontrada em stackoverflow.com/questions/12269254/how-to-resolve-input-string-was-not-in-a-correct-format-error
                numTiposVeiculosEscolhaTemp = "999"; // Define um novo valor para não dar FormatException no finally
            }
            finally   // Com o formato correcto e para o valor ser transmitido
            {
                var numerosTiposVeiculosEscolha = numTiposVeiculosEscolhaTemp.Split(' ')
               .Select(str => str.Trim())
               .Select(int.Parse)
               .ToList();
                foreach (var numeroTipoEscolha in numerosTiposVeiculosEscolha)
                {
                    if (numeroTipoEscolha >= 1 && numeroTipoEscolha <= tiposVeiculo.Count)
                    {
                        tipoVeiculosPermitidos.Add(tiposVeiculo[numeroTipoEscolha - 1]);
                    }
                }
            }
            return tipoVeiculosPermitidos;

        }

        /** Para definir o Pagamento Hora para determinado tipo de Veículo no setor */
        static Dictionary<string, decimal> RetiraPagamentoHora(List<string> tipoVeiculosPermitidos)
        {
            Dictionary<string, decimal> pagamentoHora = new Dictionary<string, decimal>();
            Console.WriteLine();
            Console.WriteLine("Define a Taxa Horária por tipo de Veiculo permitidos:");

            foreach (var veiculoTipo in tipoVeiculosPermitidos)
            {
                Console.Write($"Taxa Horária para o tipo de veículo {veiculoTipo}: €");
                if (decimal.TryParse(Console.ReadLine(), out decimal taxaHora)) // Verifica se a taxa é válida, se não, mostra mensagem de erro
                {
                    pagamentoHora[veiculoTipo] = taxaHora;
                }
                else
                {
                    Console.Clear(); // Mensagem de Erro
                    Console.WriteLine();
                    Console.WriteLine("\n+------------------------------------+");
                    Console.WriteLine("|       TAXA HORÁRIA INVÁLIDA!       |");
                    Console.WriteLine("|                                    |");
                    Console.WriteLine("|   Adicionar um número válido para  |");
                    Console.WriteLine($"|   os veículos tipo {veiculoTipo,-13}   |");
                    Console.WriteLine("+------------------------------------+"); 
                }
            }

            return pagamentoHora;
        }

        /** Inicio do Estacionamento de um determinado Veículo */
        static void EstacionarVeiculo(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            if (parqueHospital.SetoresParque.Count == 0) // Verifica se já há setores
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+-----------------------------------+");
                Console.WriteLine("|    NÃO HÁ SETORES REGISTADOS !    |");
                Console.WriteLine("|                                   |");
                Console.WriteLine("|    Tem que adicionar setores...   |");
                Console.WriteLine("+-----------------------------------+");
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\n+-----------------------------------+");
                    Console.WriteLine("|  Estacionar um Veículo no Parque  |");
                    Console.WriteLine("+-----------------------------------+");
                    Console.WriteLine();
                    Console.Write("Coloque a Matrícula: ");
                    string matriculaVeiculo = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(matriculaVeiculo))
                    {
                        if (parqueHospital.VerificarPorMatriculasExistentes(matriculaVeiculo)) // Verifica se o veículo já está estacionado
                        {
                            Console.WriteLine("Essa Matrícula já esta estacionada. Verifique e volte a colocar a Matrícula correta");
                            continue;
                        }

                        Console.WriteLine("Tipo de Veículo dos Existentes:");
                        for (int i = 0; i < TiposDeVeiculos.Count; i++)
                        {
                            Console.WriteLine(" " + (i + 1) + " - " + TiposDeVeiculos[i]);
                        }
                        Console.Write("Escolha o Tipo de Veiculo: ");
                        if (int.TryParse(Console.ReadLine(), out int escolhaTipoVeiculo) && escolhaTipoVeiculo >= 1 && escolhaTipoVeiculo <= TiposDeVeiculos.Count) // Verifica se o tipo de veículos é válido
                        {
                            string veiculoTipo = TiposDeVeiculos[escolhaTipoVeiculo - 1];

                            Console.WriteLine("Setores de Estacionamento Disponíveis: ");

                            for (int i = 0; i < parqueHospital.SetoresParque.Count; i++)
                            {
                                string estadoEstacionamento = parqueHospital.SetoresParque[i].Veiculos.Count >= parqueHospital.SetoresParque[i].Capacidade ? "Está cheio, sem lugares vagos" : "Com lugares vagos, " + (parqueHospital.SetoresParque[i].Capacidade - parqueHospital.SetoresParque[i].Veiculos.Count) + " disponíveis"; // Indica se o parte está cheio ou tem lugares vagos, indicando os lugares vagos
                                Console.WriteLine(" " + (i + 1) + " - " + parqueHospital.SetoresParque[i].NomeSetor + " (" + estadoEstacionamento + ").");

                            }

                            Console.Write("Escolha o Setor em que deseja estacionar: ");
                            if (int.TryParse(Console.ReadLine(), out int escolhaSetor) && escolhaSetor >= 1 && escolhaSetor <= parqueHospital.SetoresParque.Count) // Verifica se o setor é válido
                            {
                                Veiculo veiculo = new Veiculo
                                {
                                    MatriculaVeiculo = matriculaVeiculo,
                                    VeiculoTipo = veiculoTipo,
                                };
                                parqueHospital.SetoresParque[escolhaSetor - 1].EstacionaVeiculo(veiculo); // Estaciona o Veículo
                                break;
                            }
                            else
                            {
                                Console.Clear(); // Mensagem de Erro
                                Console.WriteLine();
                                Console.WriteLine("\n+------------------------------------+");
                                Console.WriteLine("|      OPÇÃO DE SETOR INVÁLIDA!      |");
                                Console.WriteLine("|                                    |");
                                Console.WriteLine("|  A opção que escolheu é inválida!  |");
                                Console.WriteLine("|  Escolha uma oção válida da lista. |");
                                Console.WriteLine("+------------------------------------+");
                            }
                        }
                        else
                        {
                            Console.Clear(); // Mensagem de Erro
                            Console.WriteLine();
                            Console.WriteLine("\n+------------------------------------+");
                            Console.WriteLine("|     TIPO DE VEICULO INVÁLIDO !     |");
                            Console.WriteLine("|                                    |");
                            Console.WriteLine("|  A opção que escolheu é inválida!  |");
                            Console.WriteLine("|  Escolha uma oção válida da lista. |");
                            Console.WriteLine("+------------------------------------+");
                        }
                    }
                    else
                    {
                        Console.Clear(); // Mensagem de Erro
                        Console.WriteLine();
                        Console.WriteLine("\n+-----------------------------------+");
                        Console.WriteLine("|        MATRÍCULA INVÁLIDA!        |");
                        Console.WriteLine("|                                   |");
                        Console.WriteLine("|   O campo da matrícula não pode   |");
                        Console.WriteLine("|  estar vazio adicione matrícula.  |");
                        Console.WriteLine("+-----------------------------------+");
                    }
                }
            }
        }

        /** Fim do Estacionamento de um determinado veículo */
        static void RemoverVeiculo(ParqueHospitalar parqueHospital)
        {
            if (parqueHospital.SetoresParque.Count == 0) // Verifica se já há setores
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+-----------------------------------+");
                Console.WriteLine("|    NÃO HÁ SETORES REGISTADOS !    |");
                Console.WriteLine("|                                   |");
                Console.WriteLine("|    Tem que adicionar setores...   |");
                Console.WriteLine("+-----------------------------------+");
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\n+-----------------------------------+");
                    Console.WriteLine("| Remover Veículo do Estacionamento |");
                    Console.WriteLine("+-----------------------------------+");
                    Console.WriteLine();
                    Console.Write("Matrícula do veiculo a remover: ");
                    string matriculaRemove = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(matriculaRemove)) // Verifica se a matrícula não está vazia
                    {
                        foreach (var setor in parqueHospital.SetoresParque)
                        {
                            setor.FimEstacionamentoVeiculo(matriculaRemove, setor.NomeSetor, parqueHospital); // Remove o veículo do setor, fim do estacionamento
                        }

                        if (!parqueHospital.VeiculoRemovido) // Verifica se o Veículo foi removido, se false, mostra mensagem de erro
                        {
                            Console.Clear(); // Mensagem de Erro
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("\n+-------------------------------------------+");
                            Console.WriteLine("|   NÃO FOI ENCONTRADO NENHUM VEÍCULO NOS   |");
                            Console.WriteLine($"|  SETORES COM A MATRÍCULA: {matriculaRemove,-14}  |");
                            Console.WriteLine("+---------------------+---------------------+");
                            parqueHospital.VeiculoRemovido = false; // Reinicia o indicador de veículo removido para false
                        }
                        break;
                    }
                    else
                    {
                        Console.Clear(); // Mensagem de Erro
                        Console.WriteLine();
                        Console.WriteLine("\n+-----------------------------------+");
                        Console.WriteLine("|        MATRÍCULA INVÁLIDA!        |");
                        Console.WriteLine("|                                   |");
                        Console.WriteLine("|   O campo da matrícula não pode   |");
                        Console.WriteLine("|  estar vazio adicione matrícula.  |");
                        Console.WriteLine("+-----------------------------------+");
                    }
                }
            }
        }

        /** Estatísticas por Setor, Nome, Capacidade, Veículos Estacionados, lugares vagos, se já se encontra cheio e total de pagamentos efetuados do setor */
        static void EstatisticasSetor(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+--------------------------------------------------------------------------------+");
            Console.WriteLine("|                           Estatísticas do Setor                                |");
            Console.WriteLine("+--------------------------------------------------------------------------------+");
            Console.WriteLine("|  Nome do Setor   | Capacidade | Estacionados | Vagos  | Cheio? | Receita Total |");
            Console.WriteLine("+--------------------------------------------------------------------------------+");

            if (parqueHospital.SetoresParque.Count == 0) // Verifica se há setores registados no Parque, se não há, mostra mensagem a indicar que não há setores
            {
                Console.WriteLine("|                   Ainda não Existem Setores de Estacionamento                  |");
                Console.WriteLine("+--------------------------------------------------------------------------------+");
                CarregaTecla();
            }
            else
            {
                string estaCheio; // Para guardar valor de "Sim" e "Não"
                foreach (var setorEstat in parqueHospital.SetoresParque)
                {
                    if (setorEstat.SetorCheio()) // Transformar um valor booleano em string  de "Sim" ou "Não" para indicar se o setor está cheio
                    {
                        estaCheio = "Sim";
                    }
                    else
                    {
                        estaCheio = "Não";
                    }
                    Console.WriteLine($"| {setorEstat.NomeSetor,-16} | {setorEstat.Capacidade,10} | {setorEstat.Veiculos.Count,12} | {setorEstat.Capacidade - setorEstat.Veiculos.Count,6} | {estaCheio,-6} | {setorEstat.CalcularTotalTaxaEstacionamento(),13:0,000.00} |");

                }
                Console.WriteLine("+--------------------------------------------------------------------------------+");
                CarregaTecla();
            }
        }

        /** Listagem dos Histórico de Estacionamento de determinado veículo (matrícula) */
        static void MostrarHistoricoVeiculo(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            if (parqueHospital.SetoresParque.Count == 0) // Verifica se há setores
            {
                Console.WriteLine(); // Mensagem de Erro
                Console.WriteLine("\n+----------------------------------------+");
                Console.WriteLine("|      Histórico de Estacionamento       |");
                Console.WriteLine("+----------------------------------------+");
                Console.WriteLine("| Não existem Setores de Estacionamento  |");
                Console.WriteLine("+----------------------------------------+");
                CarregaTecla();
            }
            else
            {
                bool encontradaMatrícula = false;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("\n+----------------------------------------+");
                Console.WriteLine("|      Histórico de Estacionamento       |");
                Console.WriteLine("+----------------------------------------+");
                Console.WriteLine();
                Console.Write("Entre a Matrícula: ");
                string matriculaVeiculoHist = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(matriculaVeiculoHist)) // Verifica se a matrícula está vazia
                {
                    Console.WriteLine();
                    Console.WriteLine("\n+-------------------------------------------------------------------------------------+");
                    Console.WriteLine($"|        Histórico de Estacionamento do veículo com matrícula: {matriculaVeiculoHist,-16}       |");
                    Console.WriteLine("+-------------------------------------------------------------------------------------+");
                    Console.WriteLine("| Nome do Setor  |       Entrada       |        Saida        | Pagamento | % Desconto |");
                    Console.WriteLine("+-------------------------------------------------------------------------------------+");
                    foreach (var setorEst in parqueHospital.SetoresParque)
                    {
                        bool setorNaoListado = true; // Para evitar duplicação de dados listados
                        foreach (var registoEst in setorEst.HistoricoParque)
                        {
                            if (registoEst.Veiculo.MatriculaVeiculo == matriculaVeiculoHist)
                            {

                                foreach (var setorEstat in parqueHospital.SetoresParque)
                                {
                                    encontradaMatrícula = true;
                                    if (setorNaoListado)
                                    {
                                        setorNaoListado = false;
                                        Console.WriteLine($"| {registoEst.SetorEstacionado,-14} | {registoEst.Entrada,14} | {registoEst.Saida,14} | {registoEst.TaxaEstacionamento,8:0,000.00}€ |    {registoEst.DescontoAplicado,3}%    |");

                                    }
                                }
                            }
                        }
                    }
                    if (!encontradaMatrícula) // Verifica se a matrícula foi encontrada, se false mostra mensagem a indicar que não existe histórico
                    {
                        Console.WriteLine($"|    Sem Histórico de Estacionamento para a matrícula {matriculaVeiculoHist,-16}   |");
                    }
                    Console.WriteLine("+-------------------------------------------------------------------------------------+");
                }
                else
                {
                    Console.Clear(); // Mensagem de Erro
                    Console.WriteLine();
                    Console.WriteLine("\n+-----------------------------------+");
                    Console.WriteLine("|        MATRÍCULA INVÁLIDA!        |");
                    Console.WriteLine("|                                   |");
                    Console.WriteLine("|   O campo da matrícula não pode   |");
                    Console.WriteLine("|  estar vazio adicione matrícula.  |");
                    Console.WriteLine("+-----------------------------------+");
                }
                CarregaTecla();
            }
        }

        /** Mostra o total de pagamentos já efetuados no Parque (em todos os setores) */
        static void MostrarTotalPagamentosParque(ParqueHospitalar parqueHospital)
        {
            decimal totalPagamentos = 0;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+--------------------------------+");
            Console.WriteLine("|   Total de Receitas do Parque  |");
            Console.WriteLine("+--------------------------------+");

            if (parqueHospital.SetoresParque.Count == 0) // Verifica se já há pagamentos para determinada matrícula
            {
                Console.WriteLine("| Ainda sem pagamentos efetuados |");
                Console.WriteLine("+--------------------------------+");
                CarregaTecla();
            }
            else
            {
                foreach (var setorEstat in parqueHospital.SetoresParque) // Percorre todos os setores para calcular a o total das taxas pagas no Parque
                {
                    totalPagamentos += setorEstat.CalcularTotalTaxaEstacionamento(); // Acumula a soma de todos os setores

                }
                Console.WriteLine($"|   {totalPagamentos,24:0,000.00}€    |");
                Console.WriteLine("+--------------------------------+");
                CarregaTecla();
            }
        }

        /** Mostra todos os veículos Estacionados */
        static void ListaTodosVeiculos(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+-----------------------------------------+");
            Console.WriteLine("| Listagem dos Veículos no Estacionamento |");
            Console.WriteLine("+-----------------+-----------------------+");
            Console.WriteLine("|    Matrícula    |    Tipo de Veículo    |");
            Console.WriteLine("+-----------------+-----------------------+");

            int totalVeiculos = 0; // Para guardar o total de veículos encontrados
            foreach (var setor in parqueHospital.SetoresParque)
            {
                totalVeiculos += setor.Veiculos.Count;
                foreach (var veiculoListar in setor.Veiculos)
                {
                    Console.WriteLine($"| {veiculoListar.MatriculaVeiculo,-15} | {veiculoListar.VeiculoTipo,-21} |");
                }

            }
            if (totalVeiculos == 0) // Verifica se foram encontrados veículos, se for 0 é porque não há veiculos estacionados
            {
                Console.WriteLine("|  Sem veículos estacionados nos Setores  |");
            }
            if (totalVeiculos > 0) // Verifica se foram encontrados veículos, se for maior que 0, mostra total de veículos estacionados
            {
                Console.WriteLine("+-----------------+-----------------------+");
                Console.WriteLine($"| Total de Veículos Estacionados: {totalVeiculos,6} |");
            }
            Console.WriteLine("+-----------------------------------------+");
            CarregaTecla();
        }

        /** Mostra os veículos Estacionados por setor */
        static void ListaVeiculosPorSetor(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            if (parqueHospital.SetoresParque.Count == 0) // Verifica se há setores, se não mostra erro
            {
                Console.WriteLine(); // Mensagem de Erro
                Console.WriteLine("\n+----------------------------------------+");
                Console.WriteLine("|      Listagem Veículos por Setor       |");
                Console.WriteLine("+----------------------------------------+");
                Console.WriteLine("| Não existem Setores de Estacionamento  |");
                Console.WriteLine("+----------------------------------------+");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("\n+-----------------------------+");
                Console.WriteLine("|    Setores para Escolher    |");
                Console.WriteLine("+-------+---------------------+");
                Console.WriteLine("| Opção |    Nome do Setor    |");
                Console.WriteLine("+-------+---------------------+");
                int opcaoI;
                for (int i = 0; i < parqueHospital.SetoresParque.Count; i++)
                {
                    opcaoI = i + 1;

                    Console.WriteLine($"| {opcaoI,5} | {parqueHospital.SetoresParque[i].NomeSetor,-19} |");
                    Console.WriteLine("+-------+---------------------+");
                }
                Console.Write("Escolha o setor: ");

                if (int.TryParse(Console.ReadLine(), out int escolhaSetor) && escolhaSetor >= 1 && escolhaSetor <= parqueHospital.SetoresParque.Count) // Verifica se o setore escolhido é válido
                {
                    var setorVeiculosEscolha = parqueHospital.SetoresParque[escolhaSetor - 1].Veiculos;

                    if (setorVeiculosEscolha.Count == 0) // Verifica se há veículos no setor escolhido
                    {
                        Console.WriteLine(); // Mostra que não há veículos no setor
                        Console.WriteLine("\n+----------------------------------------+");
                        Console.WriteLine("|      Listagem Veículos por Setor       |");
                        Console.WriteLine("+----------------------------------------+");
                        Console.WriteLine($"|  Sem veículos no Setor {parqueHospital.SetoresParque[escolhaSetor - 1].NomeSetor,-15} |");
                        Console.WriteLine("+----------------------------------------+");
                    }
                    else
                    {
                        Console.WriteLine("\n+----------------------------------------+"); 
                        Console.WriteLine($"| Listagem Veículos no {parqueHospital.SetoresParque[escolhaSetor - 1].NomeSetor,-17} |");
                        Console.WriteLine("+-----------------+----------------------+");
                        Console.WriteLine("|    Matrícula    |   Tipo de Veículo    |");
                        Console.WriteLine("+-----------------+----------------------+");
                        foreach (var veiculo in setorVeiculosEscolha)
                        {
                            Console.WriteLine($"| {veiculo.MatriculaVeiculo,-15} | {veiculo.VeiculoTipo,-20} |");
                        }
                        Console.WriteLine("+-----------------+----------------------+");
                    }
                }
                else
                {
                    Console.WriteLine(); // Mensagem de Erro
                    Console.WriteLine("+------------------------------------------+");
                    Console.WriteLine("| Número de Setor Inválido ou inexistente  |");
                    Console.WriteLine("+------------------------------------------+");
                }
            }
            CarregaTecla();
        }

        /** Espera que uma tecla seja carregada para avanças (para evitar repetição de código, assim chama só esta função */
        static void CarregaTecla()
        {
            Console.WriteLine();
            Console.Write("Carregue em qualquer tecla para continuar...");
            Console.ReadKey(); // Aguarda que se toque em qualquer tecla para continuar
        }

        /** Adiciona os dados de determinada matrícula de um veículo do funcionário que poderá ter direito ao descontos oferecidos no parque de estacionamento */
        static void AdicionarVeiculoFuncionario(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+-----------------------------------+");
            Console.WriteLine("| Adicionar Funcionário do Hospital |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine();
           
            Console.Write("Nome do Funcionário: ");
            string nomeFuncionario = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nomeFuncionario)) // Verifica se o nome do funcionário não está vazio, se estiver mostra mensagem de erro
            {
                Console.Write("Profissão do Funcionário: ");
                string profissaoFuncionario = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(profissaoFuncionario)) // Verifica se a profissão do funcionário não está vazio, se estiver mostra mensagem de erro
                {
                    Console.Write("Matrícula do Funcionário: ");
                    string matriculaFuncionario = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(matriculaFuncionario)) // Verifica se  a matrícula do veículo do funcionário não está vazio, se estiver mostra mensagem de erro
                    {
                        VeiculoFuncionario novoVeiculoFuncionario = new VeiculoFuncionario(nomeFuncionario, matriculaFuncionario, profissaoFuncionario);

                        parqueHospital.AdicionaVeiculoFuncionario(novoVeiculoFuncionario); // Adiciona Funcionário
                    }
                    else
                    {
                        Console.Clear(); // Mensagem de Erro
                        Console.WriteLine();
                        Console.WriteLine("\n+------------------------------------+");
                        Console.WriteLine("|   MATRÍCULA DO VEÍCULO INVÁLIDA!   |");
                        Console.WriteLine("|                                    |");
                        Console.WriteLine("|     A matrícula do veículo do      |");
                        Console.WriteLine("| funcionário não pode estar vazia.  |");
                        Console.WriteLine("+------------------------------------+");
                    }
                }
                else
                {
                    Console.Clear(); // Mensagem de Erro
                    Console.WriteLine();
                    Console.WriteLine("\n+------------------------------------+");
                    Console.WriteLine("| PROFISSÃO DE FUNCIONÁRIO INVÁLIDA! |");
                    Console.WriteLine("|                                    |");
                    Console.WriteLine("|   A profissão do funcionário não   |");
                    Console.WriteLine("|         pode estar vazia...        |");
                    Console.WriteLine("+------------------------------------+");
                }
            }
            else
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|   NOME DE FUNCIONÁRIO INVÁLIDO !   |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|   O nome do funcionário não pode   |");
                Console.WriteLine("|            estar vazio...          |");
                Console.WriteLine("+------------------------------------+");
            }
                    
        }

        /** Altera os dados de determinada matrícula de um veículo do funcionário que poderá ter direito ao descontos oferecidos no parque de estacionamento */
        static void AlterarVeiculoFuncionario(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+-----------------------------------+");
            Console.WriteLine("|  Alterar Funcionário do Hospital  |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine();
            Console.Write("Matrícula do Funcionário a ser alterado: ");
            string matriculaFuncionario = Console.ReadLine();

            parqueHospital.AlteraVeiculoFuncionario(matriculaFuncionario); // Altera dados do Funcionário
        }

        /** Remove um funcionário e o seu veículo para deixar de ter direito aos descontos oferecidos no parque de estacionamento */
        static void RemoverVeiculoFuncionario(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+-----------------------------------+");
            Console.WriteLine("|  Remover Funcionário do Hospital  |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine();

            Console.Write("Matrícula do Funcionário a ser removido: ");
            string matriculaFuncionario = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(matriculaFuncionario)) // Verifica se a matrícula do veículo do funcionário não está vazio, se estiver mostra mensagem de erro
            {
                parqueHospital.RemoveVeiculoFuncionario(matriculaFuncionario); // Remove Funcionário
            }
            else
            {
                Console.Clear(); // Mensagem de Erro
                Console.WriteLine();
                Console.WriteLine("\n+------------------------------------+");
                Console.WriteLine("|   MATRÍCULA DO VEÍCULO INVÁLIDA!   |");
                Console.WriteLine("|                                    |");
                Console.WriteLine("|     A matrícula do veículo do      |");
                Console.WriteLine("| funcionário não pode estar vazia.  |");
                Console.WriteLine("+------------------------------------+");
            }
        }   

        /** Lista todos os funcionários e a matrícula veículo que pode ter direito aos descontos no parque de estacionamento */
        static void ListarFuncionarios(ParqueHospitalar parqueHospital)
        {
            
            Console.Clear();
            Console.WriteLine(); 
            Console.WriteLine("\n+----------------------------------------------------------------------------------------------------------+");
            if (parqueHospital.VeiculosFuncionarios.Count == 0) // Verfica se Não há funcionários
            {
                Console.WriteLine("|       NÃO EXISTEM AINDA FUNCIONÁRIOS COM DIREITO A DESCONTO REGISTADOS NO PARQUE DE ESTACIONAMENTO       |");
            }
            else
            {
                Console.WriteLine("|           LISTA DE FUNCIONÁRIOS COM DIREITO A DESCONTO NO PARQUE DE ESTACIONAMENTO DO HOSPITAL           |");
                Console.WriteLine("+-------------------------------------------------------+---------------------------+----------------------+");
                Console.WriteLine("|                  Nome do Funcionário                  | Profissão do Funcionário  | Matrícula do Veículo |");
                Console.WriteLine("+-------------------------------------------------------+---------------------------+----------------------+");

                foreach (var funcionario in parqueHospital.VeiculosFuncionarios)
                {
                    Console.WriteLine($"| {funcionario.NomeFuncionario,-53} | {funcionario.ProfissaoFuncionario,-25} |  {funcionario.MatriculaFuncionario,18}  |");
                }
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------+");
        }
        
    }
}

    

 