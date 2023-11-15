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
        public List<SetorParque> SetoresParque { get; private set; }

        public ParqueHospitalar()
        {
            SetoresParque = new List<SetorParque>();
        }

        /// Adiciona o novo Setor
        public void AdicionaSetor(SetorParque setorAd)
        {
            SetoresParque.Add(setorAd);
        }


    }
}