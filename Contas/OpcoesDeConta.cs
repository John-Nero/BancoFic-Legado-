using System;
using System.Globalization;

namespace Banco
{
    class OpcoesDeConta
    {
        
        ContaPoupanca poupanca = new ContaPoupanca();
        SalvarELer salvar = new SalvarELer();

        // coleta de dados e Opções da conta poupança
        public ContaPoupanca CriarContaPoupanca()
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
                salvar.RegistrarCliente_AtualizarClientePoupanca(numero, titular, poupanca.getSaldo());


            voltaDeposito:
                Console.Write(" Haverá depósito inicial: (s/n)? ");
                char res = char.Parse(Console.ReadLine().ToLower());
                if (res.Equals('s'))
                {
                    DepositoPoupanca();
                }
                else if (res.Equals('n'))
                {
                    MostrarDadosPoupanca();
                }
                else
                {
                    Console.WriteLine("OPÇÃO INVALIDA!");
                    Console.ReadLine();
                    goto voltaDeposito;
                }
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
        public void ConsultarContaPoupanca()
        {
            
            Console.WriteLine("Digite os dados a seguir para consultar se sua conta já consta no sistema");

            Console.Write("Nome do Titular:");
            string titular = Console.ReadLine();

            Console.WriteLine("");

            Console.Write("Numero da conta:");
            int numero = int.Parse(Console.ReadLine());
                        
            salvar.procurarLinhapoupanca(titular, numero);
             
        }
        public void DepositoPoupanca()
        {
            Console.WriteLine("\n Entre um quantidade para Deposito: ");
            Console.Write(" ");
            poupanca.Deposito(double.Parse(Console.ReadLine()));
            salvar.RegistrarCliente_AtualizarClientePoupanca(poupanca.getNumero(), poupanca.getTitular(), poupanca.getSaldo());
            MostrarDadosPoupanca();
        }
        public void SaquePoupanca()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            double saque = double.Parse(Console.ReadLine());
            poupanca.Saque(saque);
            salvar.RegistrarCliente_AtualizarClientePoupanca(poupanca.getNumero(), poupanca.getTitular(), poupanca.getSaldo());
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
            Console.WriteLine("Saldo após renda:");
            poupanca.Rentabiliade();
            salvar.RegistrarCliente_AtualizarClientePoupanca(poupanca.getNumero(), poupanca.getTitular(), poupanca.getSaldo());
            Console.WriteLine(poupanca.getSaldo());
            Console.ReadLine();
        }

        // Coleta de dados e Opções da conta corrente
        ContaCorrente corrente = new ContaCorrente();
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
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 10)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da conta:{corrente.getNumero()}");
                    goto VoltaNome;
                }
                corrente.setNumero(numero);
                corrente.setTitular(titular);
                salvar.RegistrarClienteCorrente(numero, titular, corrente.getSaldo());
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
        public void ConsultarContaCorrente()
        {
            Console.WriteLine("CONSULTAR CONTA POUPANÇA SELECIONADA");
            Console.WriteLine("Digite os dados a seguir para consultar se sua conta já consta no sistema");
            Console.Write("Nome do Titular:");
            string titular = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Numero da conta:");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Saldo:");
            double saldo = double.Parse(Console.ReadLine());
            salvar.procurarLinhaCorrente(numero, titular, saldo);
        }
        public void DepositoCorrente()
        {
            Console.WriteLine("\n Entre um valor para deposito: ");
            Console.Write(" ");
            corrente.Deposito(double.Parse(Console.ReadLine()));
            salvar.RegistrarClienteCorrente(corrente.getNumero(), corrente.getTitular(), corrente.getSaldo());
            MostrarDadosCorrente();
        }
        public void SaqueCorrente()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            corrente.Saque(double.Parse(Console.ReadLine()));
            salvar.RegistrarClienteCorrente(corrente.getNumero(), corrente.getTitular(), corrente.getSaldo());
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
            salvar.RegistrarClienteCorrente(corrente.getNumero(), corrente.getTitular(), corrente.getSaldo());
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}


