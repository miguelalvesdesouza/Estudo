using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Veiculo.Veiculos
{
    // classe abstrada não permite que seja instanciado novo objeto
    public abstract class Veiculo
    {
        public int Roda { get; private set; }
        public double Motor { get; private set; }

        public Veiculo(int roda, double motor)
        {
            Roda = roda;
            Motor = motor;
        }
        
        // métodos abstratos somente utilizados em clases abstratas
        public abstract string ShowPropriedades();
        
    }
}
