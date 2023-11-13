/* Trabalho de Programação Orientada Por objectos 
 * Miguel António Costa Macedo, aluno 26046
 * Fase 1 TPOO_a26046 - Menus e Programa Principal*/

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
                // Estatística de todos os sectores existentes
                Console.Clear();
                Console.WriteLine("\n+----------------------------------------------------------------+");
                Console.WriteLine("|    Estatísticas do Parque de Estacionamento do Hospital        |");
                Console.WriteLine("+----------------------------------------------------------------+");
                Console.WriteLine("|      Nome do Setor     |      Estacionados      |    Cheio?    |");
                Console.WriteLine("+----------------------------------------------------------------+");

                if (parqueHospital.SetoresParque.Count == 0) //Não há setores ainda
                {
                    Console.WriteLine("|           Ainda não Existem Sectores de Estacionamento         |");
                    Console.WriteLine("+----------------------------------------------------------------+");
                }
                else
                {
                    // Faz a tabela com os dados dos sectores, os valores são para definir o tamanho na tabela, negativos alinhados à esquerda, positivos alinhados à direita

                }

                // Menu do Sistema de Parqueamento
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
                        MenuGerirParque(parqueHospital, TiposDeVeiculos);
                        break;

                    case '2':
                        MenuUtilizador(parqueHospital, TiposDeVeiculos);
                        break;

                    case '3':
                        Console.WriteLine();
                        MenuEstatisticas(parqueHospital);
                        break;

                    case '0':
                        return;

                    default:
                        Console.WriteLine("Escolha inválida, por favor, escolha entre 0 e 3");
                        break;
                }
            }
        }

        // Menu de Gestão do Sistema do Parque
        static void MenuGerirParque(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n+---------------------------------------------------------+");
                Console.WriteLine("|  Menu de Gestão                                         |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine("| 1 |  Adicionar Setor do Parque                         |");
                Console.WriteLine("| 2 |  Remover Setor do Parque                           |");
                Console.WriteLine("| 3 |  Alterar Setor do Parque                           |");
                Console.WriteLine("| 0 |  Voltar ao Menu Principal                           |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine();
                Console.Write("    Escolhe uma opção de 0 a 3: ");

                ConsoleKeyInfo opcaoGestao = Console.ReadKey(); // Recebe a tecla carregada para opção

                switch ((char)opcaoGestao.Key)
                {
                    case '1':
                        /// Adicionar um novo Setor ao Parque
                        break;

                    case '2':
                        /// Remover um Setor do Parque
                        break;

                    case '3':
                        /// Alterar um Setor já existente do Parque
                        break;

                    case '0':
                        return;

                    default:
                        break;
                }
            }
        }

        // Menu do Utilizador do Parque (Estacionar e Remover o veículo no Parque)
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
                        /// Estacionar o veiculo no Parque

                        break;

                    case '2':
                        /// Remover o veículo do estacionamento do Parque e pagar Estacionamento
                        
                        break;

                    case '0':
                        /// Volta ao Menu Principal
                        
                        return;

                    default:
                        break;
                }
            }
        }

        // Menu para Mostrar as Estatísticas do Parque
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
                Console.WriteLine("| 0 |  Voltar ao Menu de Gestão                           |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine(" ");
                Console.Write("    Escolhe uma opção de 0 a 4: ");


                ConsoleKeyInfo opcaoEstatitica = Console.ReadKey(); /// Recebe a tecla carregada para opção

                switch ((char)opcaoEstatitica.Key)
                {
                    case '1':
                        /// Estatísticas do Setor

                        break;

                    case '2':
                        /// Menu das Estatísticas dos Veículos
                        MenuEstatisticasVeiculos(parqueHospital);
                        break;

                    case '3':
                        /// Histórico de Estacionamento por Matrícula

                        break;

                    case '4':
                        /// Mostrar o total de receitas do Parque (Total de Pagamentos de todos os Setores)

                        break;


                    case '0':
                        /// Voltar ao Menu Principal

                        return;

                    default:
                        break;
                }
            }
        }

        static void MenuEstatisticasVeiculos(ParqueHospitalar parqueHospital)
        {
            Console.WriteLine();
            Console.WriteLine("\n+---------------------------------------------------------+");
            Console.WriteLine("|  Menu de Estatísticas dos Veículos                      |");
            Console.WriteLine("+---+-----------------------------------------------------+");
            Console.WriteLine("| 1 |  Listar Todos os Veiculos                           |");
            Console.WriteLine("| 2 |  Listar Veiculos por Setor                          |");
            Console.WriteLine("| 0 |  Voltar ao Menu de Estatísticas                     |");
            Console.WriteLine("+---+-----------------------------------------------------+");
            Console.WriteLine(" ");
            Console.Write("    Escolhe uma opção de 0 a 2: ");


            ConsoleKeyInfo opcaoEstatisticaVeiculos = Console.ReadKey(); /// Recebe a tecla carregada para opção

            switch ((char)opcaoEstatisticaVeiculos.Key)
            {
                case '1':
                    /// Lista todos os Veículos

                    break;

                case '2':
                    /// Lista os Veiculos por Setor

                    break;

                case '0':
                    /// Volta ao Menu de Estatísticas
                    return;

                default:
                    break;
            }
        }
    }
}

    

 