/* Trabalho de Programação Orientada Por objectos 
 * Miguel António Costa Macedo, aluno 26046
 * Fase 1 TPOO_a26046 - Setores do Parque - SetoresParque.cs*/

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

        // Registo do Setor
        public SetorParque(string nomeSetor, int capacidade, Dictionary<string, decimal> pagamentoHora, List<string> tipoVeiculosPermitidos)
        {
            NomeSetor = nomeSetor;
            Capacidade = capacidade;
            PagamentoHoraPorTipoVeiculo = pagamentoHora;
            Veiculos = new List<Veiculo>();
            TiposVeiculosPermitidos = tipoVeiculosPermitidos;
            HistoricoParque = new List<RegistoEstacionamento>();
        }

    }
    
}

