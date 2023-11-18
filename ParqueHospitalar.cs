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
        // Registos do Parque do Estacionamento
        public List<SetorParque> SetoresParque { get; private set; }

        public ParqueHospitalar()
        {
            SetoresParque = new List<SetorParque>();
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


    }
}