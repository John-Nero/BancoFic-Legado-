using System;
using System.Globalization;

namespace Banco
{
   public sealed class ContaCorrente : Conta
    {
        private double LimiteEmprestimo = 500;

        public ContaCorrente() { }
        public ContaCorrente(string titular, int numero) : base(titular, numero) { }
        public ContaCorrente(string titular, int numero, double saldo) : base(titular, numero) { Saldo = saldo; }
        public ContaCorrente(double limiteEmprestimo)
        {
            LimiteEmprestimo = limiteEmprestimo;
        }

        public void SolicitarEmprestimo(double valor)
        {
            if (valor <= LimiteEmprestimo)
            {
                Depositar(valor);
                Console.WriteLine(" Saldo atualizado: ");
                Console.WriteLine($" Saldo: $ {getSaldo().ToString("F2", CultureInfo.InvariantCulture)} \n");
                LimiteEmprestimo -= valor;
            }
            else { Console.WriteLine("O SEU LIMITE DE EMPRESTIMO NÃO É SUFICIENTE PARA A OPERAÇÃO"); }
        }
        public override void Sacar(double valor)
        {
            if (Saldo >= valor + 5 && valor > 0)
            {
                Saldo -= valor + 5;
            }
            else
            {
                Console.WriteLine("SALDO INDISPONIVEL PARA OPERAÇÂO");
            }

        }
    }
}
