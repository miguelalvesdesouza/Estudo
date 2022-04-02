using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Veiculo.Veiculos
{
    public class Carro : Veiculo
    {
        private int Porta { get; set; }
        public Carro(int roda, double motor, int porta) : base(roda, motor)
        {
            Porta = porta;
        }

        public override string ShowPropriedades()
        {
            return $"Propriedade do Carro: \nRoda: {Roda}\nMotor: {Motor}\nPorta: {Porta}";
        }
    }
}
