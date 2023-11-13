/* Trabalho de Programação Orientada Por objectos 
* Miguel António Costa Macedo, aluno 26046
* Fase 1 TPOO_a26046 - Parque do Hospital - ParqueHospitalar.cs*/

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

    }
 }