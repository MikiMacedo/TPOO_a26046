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
                Console.WriteLine("|      Nome do Setor     |      Estacionados      |    Cheio?    |");
                Console.WriteLine("+----------------------------------------------------------------+");

                if (parqueHospital.SetoresParque.Count == 0) //Não há setores ainda
                {
                    Console.WriteLine("|           Ainda não Existem Setores de Estacionamento          |");
                    Console.WriteLine("+----------------------------------------------------------------+");
                }
                else
                {
                    string setorEstaCheio;
                    foreach (var nomeSetor in parqueHospital.SetoresParque) /// Mostra tabela dos setores existentes
                    {
                        ///Transformar um valor booleano em "Sim" ou "Não" para indicar se o setor está cheio
                        if (nomeSetor.SetorCheio())
                        {
                            setorEstaCheio = "Sim";
                        }
                        else
                        {
                            setorEstaCheio = "Não";
                        }
                        /// Faz a tabela com os dados dos setores, os valores são para definir o tamanho na tabela, negativos alinhados à esquerda, positivos alinhados à direita
                        Console.WriteLine($"|   {nomeSetor.NomeSetor,-20} |       {nomeSetor.Veiculos.Count,16} | {setorEstaCheio,6}       |");
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
                Console.WriteLine("| 0 |  Voltar ao Menu Principal                           |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine();
                Console.Write("    Escolhe uma opção de 0 a 3: ");

                ConsoleKeyInfo opcaoGestao = Console.ReadKey(); // Recebe a tecla carregada para opção

                switch ((char)opcaoGestao.Key)
                {
                    case '1':
                        /// Adicionar um novo Setor ao Parque
                        Console.WriteLine();
                        AdicionarSetor(parqueHospital, TiposDeVeiculos);
                        CarregaTecla();
                        break;

                    case '2':
                        /// Remover um Setor do Parque
                        Console.WriteLine();
                        RemoverSetor(parqueHospital);
                        CarregaTecla();
                        break;

                    case '3':
                        /// Alterar um Setor já existente do Parque
                        Console.WriteLine();
                        AlterarSetor(parqueHospital, TiposDeVeiculos);
                        CarregaTecla();
                        break;

                    case '0':
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
                        /// Estacionar o veiculo no Parque
                        Console.WriteLine();
                        EstacionarVeiculo(parqueHospital, TiposDeVeiculos);
                        CarregaTecla();
                        break;

                    case '2':
                        /// Remover o veículo do estacionamento do Parque e pagar Estacionamento
                        Console.WriteLine();
                        RemoverVeiculo(parqueHospital);
                        CarregaTecla();
                        break;

                    case '0':
                        /// Volta ao Menu Principal
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
                Console.WriteLine("| 0 |  Voltar ao Menu de Gestão                           |");
                Console.WriteLine("+---+-----------------------------------------------------+");
                Console.WriteLine(" ");
                Console.Write("    Escolhe uma opção de 0 a 4: ");


                ConsoleKeyInfo opcaoEstatitica = Console.ReadKey(); /// Recebe a tecla carregada para opção

                switch ((char)opcaoEstatitica.Key)
                {
                    case '1':
                        /// Estatísticas do Setor
                        EstatisticasSetor(parqueHospital);
                        break;

                    case '2':
                        /// Menu das Estatísticas dos Veículos
                        MenuEstatisticasVeiculos(parqueHospital);
                        break;

                    case '3':
                        /// Histórico de Estacionamento por Matrícula
                        MostrarHistoricoVeiculo(parqueHospital);
                        break;

                    case '4':
                        /// Mostrar o total de receitas do Parque (Total de Pagamentos de todos os Setores)
                        MostrarTotalPagamentosParque(parqueHospital);
                        break;


                    case '0':
                        /// Voltar ao Menu Principal
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

            ConsoleKeyInfo opcaoEstatisticaVeiculos = Console.ReadKey(); /// Recebe a tecla carregada para opção

            switch ((char)opcaoEstatisticaVeiculos.Key)
            {
                case '1':
                    /// Lista todos os Veículos
                    ListaTodosVeiculos(parqueHospital);
                    break;

                case '2':
                    /// Lista os Veiculos por Setor
                    ListaVeiculosPorSetor(parqueHospital);
                    break;

                case '0':
                    /// Volta ao Menu de Estatísticas
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
            Console.Write("Nome do Setor: ");  /// Para escrever o nome do novo Setor
            string nomeSetor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nomeSetor))
            {
                Console.Write("Capacidade do Setor: "); /// Para definir a capacidade do Setor
                if (int.TryParse(Console.ReadLine(), out int capacidadeSetor))
                {
                    List<string> tipoVeiculosPermitidos = RetiraTipoVeiculosPermitidos(TiposDeVeiculos); ///Para definir os tipos de veículos permitidos no Setor
                    if (tipoVeiculosPermitidos.Count == 0)
                    {
                        Console.WriteLine("Pelo menos um tipo de Veiculo é necessário");
                        return;
                    }
                    Dictionary<string, decimal> pagamentoHora = RetiraPagamentoHora(tipoVeiculosPermitidos);
                    if (pagamentoHora.Count == 0)
                    {
                        Console.WriteLine("É preciso colocar quanto custa o estacionamento por Hora");
                        return;
                    }

                    SetorParque novoSetor = new SetorParque(nomeSetor, capacidadeSetor, pagamentoHora, tipoVeiculosPermitidos);
                    parqueHospital.AdicionaSetor(novoSetor);
                    Console.Clear();
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
                        Console.WriteLine($"|  {tipoVeiculo,-15}  |  {pagamentoHora[tipoVeiculo],11:0.00}€  |");
                    }
                    Console.WriteLine("+------------------------------------+");
                }
                else
                {
                    Console.WriteLine("Capacidade Inválida. Por favor, coloque um número válido");
                }
            }
            else
            {
                Console.WriteLine("O Nome do Setor não pode estar vazio.");
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
                Console.WriteLine((i + 1) + " - " + parqueHospital.SetoresParque[i].NomeSetor);
                verificaSetor = true; /// Para verificar se há setores, true significa que foi entrado o setor
            }

            if (!verificaSetor) /// Não existem Setores
            {
                Console.WriteLine();
                Console.WriteLine("Sem Setores para remover");
                return;
            }

            Console.Write("Coloque o número do setor a remover, conforme tabela, ou qualquer outros para desistir: ");  ///Existem Setores para remover
            if (int.TryParse(Console.ReadLine(), out int nomeSetor) && nomeSetor >= 1 && nomeSetor <= parqueHospital.SetoresParque.Count)
            {
                int refSetorRemover = nomeSetor - 1;
                if (refSetorRemover >= 0 && refSetorRemover < parqueHospital.SetoresParque.Count)
                {
                    parqueHospital.SetoresParque.RemoveAt(refSetorRemover); /// Remove o setor escolhido

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("\n+------------------------------------+");
                    Console.WriteLine("|      FOI REMOVIDO DO PARQUE DE     |");
                    Console.WriteLine("|      ESTACIONAMENTO DO HOSPITAL    |");
                    Console.WriteLine("+------------------------------------+");
                    Console.WriteLine("|        Nome do Setor removido      |");
                    Console.WriteLine("+------------------------------------+");
                    Console.WriteLine($"|     {nomeSetor,-26}     |");
                    Console.WriteLine("+------------------------------------+");
                }
                else
                {
                    Console.WriteLine("Desistência da Remoção. Se realmente deseja remover, por favor, coloque um número válido");
                }
            }
            else
            {
                Console.WriteLine("Desistência da Remoção. Se realmente deseja remover, por favor, coloque um número válido");
            }
        }

        /** Alterar um dos setores existentes */
        static void AlterarSetor(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\n+------------------------------------+");
            Console.WriteLine("|     Alterar um Setor Existente     |");
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine();
            Console.Write("Nome do Setor a ser alterado: ");
            string nomeSetor = Console.ReadLine();

            // Procura o setor pelo nome
            SetorParque setorExistente = parqueHospital.SetoresParque.FirstOrDefault(s => s.NomeSetor == nomeSetor);

            if (setorExistente != null)
            {
                Console.WriteLine();
                Console.WriteLine("Novas informações para o setor:");

                Console.Write("Novo Nome do Setor: ");
                string novoNomeSetor = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(novoNomeSetor))
                {
                    Console.Write("Nova Capacidade do Setor: ");
                    if (int.TryParse(Console.ReadLine(), out int novaCapacidadeSetor))
                    {
                        List<string> novoTipoVeiculosPermitidos = RetiraTipoVeiculosPermitidos(TiposDeVeiculos);
                        if (novoTipoVeiculosPermitidos.Count == 0)
                        {
                            Console.WriteLine("Pelo menos um tipo de Veículo é necessário");
                            return;
                        }

                        Dictionary<string, decimal> novoPagamentoHora = RetiraPagamentoHora(novoTipoVeiculosPermitidos);
                        if (novoPagamentoHora.Count == 0)
                        {
                            Console.WriteLine("É preciso colocar quanto custa o estacionamento por Hora");
                            return;
                        }

                        // Atualiza as informações do setor
                        string antigoNomeSetor = nomeSetor;
                        setorExistente.NomeSetor = novoNomeSetor;
                        setorExistente.Capacidade = novaCapacidadeSetor;
                        setorExistente.TiposVeiculosPermitidos = novoTipoVeiculosPermitidos;
                        setorExistente.PagamentoHoraPorTipoVeiculo = novoPagamentoHora;

                        Console.Clear();
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
                            Console.WriteLine($"|  {tipoVeiculo,-15}  |  {novoPagamentoHora[tipoVeiculo],11:0.00}€  |");
                        }
                        Console.WriteLine("+------------------------------------+");
                    }
                    else
                    {
                        Console.WriteLine("Capacidade Inválida. Por favor, coloque um número válido");
                    }
                }
                else
                {
                    Console.WriteLine("O Nome do Setor não pode estar vazio.");
                }
            }
            else
            {
                Console.WriteLine("Setor não encontrado. Verifique o nome do setor.");
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
                Console.WriteLine((i + 1) + " - " + tiposVeiculo[i]);
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
            catch (System.FormatException) /// Detecta se há um FormatException (caracteres sem sem números e o espaço como separador de números)
            {
                Console.WriteLine("Os números devem ser separados por um espaço, caracteres não permitidos"); /// Detecta se o valor é inválido, solução encontrada em stackoverflow.com/questions/12269254/how-to-resolve-input-string-was-not-in-a-correct-format-error
                numTiposVeiculosEscolhaTemp = "999"; ///Define um novo valor para não dar FormatException no finally
            }
            finally   /// Já com o formato correcto e para o valor ser transmitido
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
                if (decimal.TryParse(Console.ReadLine(), out decimal taxaHora))
                {
                    pagamentoHora[veiculoTipo] = taxaHora;
                }
                else
                {
                    Console.WriteLine($"Taxa Horária inválida para {veiculoTipo}. Adicionar um número válido.");
                }
            }

            return pagamentoHora;
        }

        /// Inicio do Estacionamento de um determinado Veículo
        static void EstacionarVeiculo(ParqueHospitalar parqueHospital, List<string> TiposDeVeiculos)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Coloque a Matrícula: ");
                string matriculaVeiculo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(matriculaVeiculo))
                {
                    if (parqueHospital.VerificarPorMatriculasExistentes(matriculaVeiculo))
                    {
                        Console.WriteLine("Essa Matrícula já esta estacionada. Verifique e volte a colocar a Matrícula correta");
                        continue;
                    }

                    Console.WriteLine("Tipo de Veículo dos Existentes:");
                    for (int i = 0; i < TiposDeVeiculos.Count; i++)
                    {
                        Console.WriteLine((i + 1) + " - " + TiposDeVeiculos[i]);
                    }
                    Console.Write("Escolha o Tipo de Veiculo: ");
                    if (int.TryParse(Console.ReadLine(), out int escolhaTipoVeiculo) && escolhaTipoVeiculo >= 1 && escolhaTipoVeiculo <= TiposDeVeiculos.Count)
                    {
                        string veiculoTipo = TiposDeVeiculos[escolhaTipoVeiculo - 1];

                        Console.WriteLine("Setores de Estacionamento Disponíveis: ");
                        for (int i = 0; i < parqueHospital.SetoresParque.Count; i++)
                        {
                            Console.WriteLine((i + 1) + " - " + parqueHospital.SetoresParque[i].NomeSetor);
                        }
                        Console.Write("Escolha o Setor em que deseja estacionar: ");
                        if (int.TryParse(Console.ReadLine(), out int escolhaSetor) && escolhaSetor >= 1 && escolhaSetor <= parqueHospital.SetoresParque.Count)
                        {
                            Veiculo veiculo = new Veiculo
                            {
                                MatriculaVeiculo = matriculaVeiculo,
                                VeiculoTipo = veiculoTipo,
                            };
                            parqueHospital.SetoresParque[escolhaSetor - 1].EstacionaVeiculo(veiculo);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Número de Setor Inválido");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tipo veiculo inválido");
                    }
                }
                else
                {
                    Console.WriteLine("O Campo da Matrícula não pode estar vazio, adicione a Matrícula");
                }
            }
        }

        /// Fim do Estacionamento de um determinado veículo
        static void RemoverVeiculo(ParqueHospitalar parqueHospital)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write("Matrícula do veiculo a remover: ");
                string matriculaRemove = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(matriculaRemove))
                {
                    foreach (var setor in parqueHospital.SetoresParque)
                    {
                        setor.FimEstacionamentoVeiculo(matriculaRemove);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("O Campo da Matrícula não pode estar vazio, adicione a Matrícula");
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

            if (parqueHospital.SetoresParque.Count == 0)
            {
                Console.WriteLine("|                   Ainda não Existem Setores de Estacionamento                  |");
                Console.WriteLine("+--------------------------------------------------------------------------------+");
                CarregaTecla();
            }
            else
            {
                string estaCheio;
                foreach (var setorEstat in parqueHospital.SetoresParque)
                {
                    //Transformar um valor booleano em "Sim" ou "Não" para indicar se o sector está cheio
                    if (setorEstat.SetorCheio())
                    {
                        estaCheio = "Sim";
                    }
                    else
                    {
                        estaCheio = "Não";
                    }
                    Console.WriteLine($"| {setorEstat.NomeSetor,-16} | {setorEstat.Capacidade,10} | {setorEstat.Veiculos.Count,12} | {setorEstat.Capacidade - setorEstat.Veiculos.Count,6} | {estaCheio,-6} | {setorEstat.CalcularTotalTaxaEstacionamento(),13:0.00} |");

                }
                Console.WriteLine("+--------------------------------------------------------------------------------+");
                CarregaTecla();
            }
        }

        /** Listagem dos Histórico de Estacionamento de determinado veículo (matrícula) */
        static void MostrarHistoricoVeiculo(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            if (parqueHospital.SetoresParque.Count == 0)
            {
                Console.WriteLine();
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
                Console.WriteLine();
                Console.Write("Entre a Matrícula: ");
                string matriculaVeiculoHist = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(matriculaVeiculoHist))
                {
                    Console.WriteLine();
                    Console.WriteLine("\n+------------------------------------------------------------------------+");
                    Console.WriteLine($"| Histórico de Estacionamento do veículo com matrícula: {matriculaVeiculoHist,-16} |");
                    Console.WriteLine("+------------------------------------------------------------------------+");
                    Console.WriteLine("| Nome do Setor  |       Entrada       |        Saida        | Pagamento |");
                    Console.WriteLine("+------------------------------------------------------------------------+");
                    foreach (var setorEst in parqueHospital.SetoresParque)
                    {
                        foreach (var registoEst in setorEst.HistoricoParque)
                        {
                            if (registoEst.Veiculo.MatriculaVeiculo == matriculaVeiculoHist)
                            {
                                
                                foreach (var setorEstat in parqueHospital.SetoresParque)
                                {
                                    encontradaMatrícula = true;
                                    Console.WriteLine($"| {setorEstat.NomeSetor,-14} | {registoEst.Entrada,14} | {registoEst.Saida,14} | {registoEst.TaxaEstacionamento,8:0.00}€ |");
                                }
                            }
                        }
                    }
                    if (!encontradaMatrícula)
                    {
                        Console.WriteLine($"|    Sem Histórico de Estacionamento para a matrícula {matriculaVeiculoHist,-16}   |");
                    }
                    Console.WriteLine("+------------------------------------------------------------------------+");
                }
                else
                {
                    Console.WriteLine("A matrícula não pode estar vazia");
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

            if (parqueHospital.SetoresParque.Count == 0)
            {
                Console.WriteLine("| Ainda sem pagamentos efetuados |");
                Console.WriteLine("+--------------------------------+");
                CarregaTecla();
            }
            else
            {
                /// Percorre todos os setores para calcular a o total das taxas pagas no Parque
                foreach (var setorEstat in parqueHospital.SetoresParque)
                {
                    totalPagamentos += setorEstat.CalcularTotalTaxaEstacionamento();

                }
                Console.WriteLine($"|   {totalPagamentos,24:0.00}€    |");
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

            int totalVeiculos = 0;
            foreach (var setor in parqueHospital.SetoresParque)
            {
                totalVeiculos += setor.Veiculos.Count;
                foreach (var veiculoListar in setor.Veiculos)
                {
                    Console.WriteLine($"| {veiculoListar.MatriculaVeiculo,-15} | {veiculoListar.VeiculoTipo,-21} |");
                }

            }
            if (totalVeiculos == 0)
            {
                Console.WriteLine("|  Sem veículos estacionados nos Setores  |");
            }
            Console.WriteLine("+-----------------------------------------+");
            CarregaTecla();
        }

        /** Mostra os veículos Estacionados por setor */
        static void ListaVeiculosPorSetor(ParqueHospitalar parqueHospital)
        {
            Console.Clear();
            if (parqueHospital.SetoresParque.Count == 0)
            {
                Console.WriteLine();
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

                if (int.TryParse(Console.ReadLine(), out int escolhaSetor) && escolhaSetor >= 1 && escolhaSetor <= parqueHospital.SetoresParque.Count)
                {
                    var setorVeiculosEscolha = parqueHospital.SetoresParque[escolhaSetor - 1].Veiculos;

                    if (setorVeiculosEscolha.Count == 0)
                    {
                        Console.WriteLine();
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
                    Console.WriteLine();
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
            Console.Write("Carregue em qualquer tecla para seguir...");
            Console.ReadKey();
        }
    }
}

    

 