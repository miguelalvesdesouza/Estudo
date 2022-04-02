using System;
using Veiculo.Veiculos;

namespace Veiculo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira a quantidade de Veiculos: ");
            int quantidade = int.Parse(Console.ReadLine());

            for(int i = 1; i<=quantidade; i++)
            {
                Console.WriteLine($"Dados do Veículo {i}");
                Console.Write("Roda: ");
                int roda = int.Parse(Console.ReadLine());
                Console.Write("Motor: ");
                double motor = double.Parse(Console.ReadLine());
                Console.Write("Portas: ");
                int portas = int.Parse(Console.ReadLine());

                if(portas != 0)
                {
                    Carro carro = new Carro(roda, motor, portas);
                    Console.WriteLine(carro.ShowPropriedades());
                }
                else if(portas == 0)
                {
                    
                    Moto moto = new Moto(roda, motor);
                    Console.WriteLine(moto.ShowPropriedades());
                }
                else
                {
                    Console.WriteLine("Valores Inválidos");
                }
            }
        }
    }
}
