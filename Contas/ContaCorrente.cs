﻿using System;
using System.Globalization;

namespace Banco
{
    public sealed class ContaCorrente : Conta
    {
        private double LimiteEmprestimo = 500;

        public ContaCorrente() { }
        public ContaCorrente(string titular, int numero, double saldo) : base(titular, numero) {  Saldo = saldo; }

        //deixar a informação de emprestimo salvo no arquivo e verificar se a pessoa te limite
        public void SolicitarEmprestimo(double valor)
        {
            if (valor <= LimiteEmprestimo)
            {
                Depositar(valor);
                Console.WriteLine(" Saldo atualizado: ");
                Console.WriteLine($" Saldo: $ {Saldo.ToString("F2", CultureInfo.InvariantCulture)} \n");
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
