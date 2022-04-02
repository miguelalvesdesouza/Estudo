using System;
using System.Globalization;

namespace Ex_Construtores
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco;
            Console.Write("Entre com o número da conta: ");
            int numConta = Convert.ToInt32(Console.ReadLine());
            Console.Write("Entre com o titular da conta: ");
            string nomeTitular = Console.ReadLine();
            Console.Write("Haverá depósito inicial (s/n)? ");
            char depositoInicial = Convert.ToChar(Console.ReadLine());

            if (depositoInicial == 's')
            {
                Console.Write("Entre com o valor do depósito inicial: ");
                double saldoConta = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                banco = new Banco(numConta, nomeTitular, saldoConta);
            }
            else
            {
                banco = new Banco(numConta, nomeTitular);
            }
            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(banco);
            Console.WriteLine();

            Console.Write("Entre um valor para depósito: ");
            double valor = double.Parse(Console.ReadLine());
            banco.Deposito(valor);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(banco);
            Console.WriteLine();

            Console.Write("Entre um valor para saque: ");
            valor = double.Parse(Console.ReadLine());
            banco.Saque(valor);
            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(banco);
            Console.WriteLine();
        }
    }
}
