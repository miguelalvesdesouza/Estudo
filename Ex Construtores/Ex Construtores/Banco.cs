using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Ex_Construtores
{
    class Banco
    {
        public int Conta { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public Banco()
        {
            Saldo = 0.00;
        }

        public Banco(int conta, string titular) : this()
        {
            Conta = conta;
            Titular = titular;
        }

        public Banco(int conta, string titular, double saldo) : this(conta, titular)
        {
            Saldo = saldo;
        }
            
        public void Deposito(double valor) 
        {
            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= valor + 5;
        }

        public override string ToString()
        {
            return $"Conta {Conta}, Titular: {Titular}, Saldo: ${Saldo.ToString("F2", CultureInfo.InvariantCulture)}";
        }

    }
}
