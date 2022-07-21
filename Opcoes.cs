using System;
using System.Globalization;

namespace Banco
{
    class Opcoes
    {

        ContaCorrente corrente = new ContaCorrente();
        ContaPoupanca poupanca = new ContaPoupanca();

        //Opções e coleta de dados da conta poupança

        public Conta CriarContaPoupanca()
        {
            try
            {
                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());

                if (numero < 1000 || numero >= 10000)
                {
                    Console.WriteLine(" O NUMERO DE CONTA DEVE CONTER QUATRO DIGITOS");
                    Console.ReadLine();
                    Console.Clear();
                    CriarContaPoupanca();
                }

            VoltaNome:
                Console.Write(" Entre com o titular da conta: ");
                string titular = Console.ReadLine();


                int confirmacaoTitular = titular.Length;
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 5)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da conta:{poupanca.getNumero()}");
                    goto VoltaNome;
                }
                poupanca.setNumero(numero);
                poupanca.setTitular(titular);

                return poupanca;
            }
            catch (FormatException)
            {
                Console.WriteLine("DIGITE APENAS NUMEROS");
                Console.ReadLine();
                Console.Clear();
                CriarContaPoupanca();
                throw;
            }
        }

        public void inicialPS()
        {
            Console.Write(" Entre com o valor de depósito inicial: ");
            poupanca.Deposito(double.Parse(Console.ReadLine()));
            Console.WriteLine("\n Dados da conta:");
            Console.WriteLine($" Numero da conta: {poupanca.getNumero()}, Titular da conta: {poupanca.getTitular()}, Saldo atual:{poupanca.getSaldo()}");
        }

        public void DepositoPoupanca()
        {
            Console.WriteLine("\n Entre um quantidade para Deposito: ");
            Console.Write(" ");
            poupanca.Deposito(double.Parse(Console.ReadLine()));
            MostrarDadosPoupanca();
        }
        public void SaquePoupanca()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            double saque = double.Parse(Console.ReadLine());
            poupanca.Saque(saque);
            MostrarDadosPoupanca();
        }
        public void MostrarDadosPoupanca()
        {
            Console.WriteLine(" Saldo atualizado: ");
            Console.Write("\n Dados da conta:");
            Console.WriteLine($"\n Nº da Conta: {poupanca.getNumero()} , Titular: {poupanca.getTitular()}, Saldo: $ {poupanca.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}\n");
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Render()
        {
            Console.WriteLine("Saldo após renda");
            poupanca.Rentabiliade();
            Console.WriteLine(poupanca.getSaldo());
        }


        //opções e coleta de dados da conta corrente

        public Conta CriarContaCorrente()
        {
            try
            {
                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());

                if (numero < 1000 || numero >= 10000)
                {
                    Console.WriteLine(" O NUMERO DE CONTA DEVE CONTER QUATRO DIGITOS");
                    Console.ReadLine();
                    Console.Clear();
                    CriarContaCorrente();
                }

            VoltaNome:
                Console.Write(" Entre com o titular da conta: ");
                string titular = Console.ReadLine();


                int confirmacaoTitular = titular.Length;
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 5)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da conta:{corrente.getNumero()}");
                    goto VoltaNome;
                }
                corrente.setNumero(numero);
                corrente.setTitular(titular);

                return corrente;
            }
            catch (FormatException)
            {
                Console.WriteLine("DIGITE APENAS NUMEROS");
                Console.ReadLine();
                Console.Clear();
                CriarContaCorrente();
                throw;
            }

        }

        public void inicialCS()
        {
            Console.Write(" Entre com o valor de depósito inicial: ");
            corrente.Deposito(double.Parse(Console.ReadLine()));
            Console.WriteLine("\n Dados da conta:");
            Console.WriteLine($" Nº da Conta: {corrente.getNumero()}, Titular: {corrente.getTitular()}, Saldo: {corrente.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}\n");

        }

        public void DepositoCorrente()
        {
            Console.WriteLine("\n Entre um valor para deposito: ");
            Console.Write(" ");
            corrente.Deposito(double.Parse(Console.ReadLine()));
            MostrarDadosCorrente();
        }
        public void SaqueCorrente()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            corrente.Saque(double.Parse(Console.ReadLine()));
            MostrarDadosCorrente();


        }
        public void MostrarDadosCorrente()
        {
            Console.Write("\n Dados da conta:");
            Console.WriteLine($"\n Nº da Conta: {corrente.getNumero()}, Titular: {corrente.getTitular()}, Saldo: $ {corrente.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}\n");
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Emprestimo()
        {
            Console.WriteLine("\n Entre o valor do empréstimo: ");
            Console.Write(" ");
            corrente.Emprestimo(double.Parse(Console.ReadLine()));
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

    }

}


