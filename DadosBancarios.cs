using System;
namespace Banco
{
    class DadosBancarios
    {
        private int Numero;
        private string Titular;
        private double Saldo;
        
       

        public DadosBancarios(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;

        }

        

        public int getNumero()
        {
            return Numero;
        }
        public void setNumero(int numero)
        {
            Numero = numero;
        }

        public string getTitular()
        {
            return Titular;
        }
        public void setTitular(string titular)
        {
            Titular = titular;
        }

        public double getSaldo()
        {
            return Saldo;
        }

        public void Deposito(double valor)
        {
             Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= valor + 5;
        }
    }


}
