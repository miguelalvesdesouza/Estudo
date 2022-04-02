using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veiculo.Veiculos
{
    public class Moto : Veiculo
    {
        public Moto(int roda, double motor) : base(roda, motor) {  }

        public override string ShowPropriedades()
        {
            return $"Propriedades da Moto:\nRoda: {Roda}\nMotor: {Motor}";
        }
    }
}
