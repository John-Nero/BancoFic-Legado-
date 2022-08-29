using System;

namespace Banco
{
    public class Conta
    {

        //E se conseguissemos deixar a criação do número da conta de forma automática? Talvez com um guide
        //conseguindo deixar o número sendo geraldo automaticamente pede o cpf 
        //um outro incremento seria criar uma lista de cidades e agencias pra ser um atributo e ter a informação completa conta e agencia
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
