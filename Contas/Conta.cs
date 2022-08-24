using System;

namespace Banco
{
    public class Conta
    {
        public int Numero { get; private set;}
        public string Titular { get; private set;}
        public double Saldo { get; internal set;}

        public Conta() {}
        public Conta(string titular, int numero) {Numero = numero;Titular = titular;}
        
        public void setNumero(int numero)
        {
            Numero = numero;
        }
        
        public void setTitular(string titular)
        {
            Titular = titular;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
        }
        public virtual void Sacar(double valor)
        {
            if (Saldo >= valor && valor > 0)
            {
                Saldo -= valor;
            }
            else
            {
                Console.WriteLine("SALDO INDISPONIVEL PARA OPERAÇÂO");
            }
        }
    }
}
