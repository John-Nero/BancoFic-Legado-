using System;
using System.Globalization;

namespace Banco
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());

                int confirmacaoNumero = numero.ToString().Length;
                if (confirmacaoNumero < 4 || confirmacaoNumero >= 5)
                {
                    Console.WriteLine(" O NUMERO DE CONTA DEVE CONTER QUATRO DIGITOS");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                }
                Console.Write(" Entre com o titular da conta: ");
                string titular = Console.ReadLine();
                int confirmacaoTitular = titular.Length;
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 5)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                }

                Conta conta = new(numero, titular);
            }
            catch (FormatException)
            {
                Console.WriteLine("DIGITE APENAS NUMEROS");
                Console.ReadLine();
                Console.Clear();
                Main(args);            
            }

            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("selecione que tipo de conta você deseja:");
                    Console.WriteLine("1 - Conta Poupança \n2 - Conta Corrente \n3 - Encerrar");
                    Console.Write(" Opção: ");
                    int op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                        Console.WriteLine("CONTA POUPANÇA SELECIONADA");
                        acaoPadrao();

                        break;

                        case 2:
                        Console.WriteLine("CONTA CORRENNTE SELECIONADA");
                        acaoCorrente();
                        ;
                        break;

                        case 3:
                        Console.WriteLine("Agradecemos a preferência.");
                        Environment.Exit(0);
                        loop = false;
                        break;

                        default:
                        Console.WriteLine(" OPÇÃO INVALIDA.");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("DIGITE APENAS NUMEROS.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        static void acaoPadrao()
        {
            Conta dados = new Conta();
            Console.Write(" Haverá depósito inicial: (s/n)? ");
            char res = char.Parse(Console.ReadLine().ToLower());
            if (res.Equals('s'))
            {
                Console.Write(" Entre com o valor de depósito inicial: ");
                dados.Deposito(double.Parse(Console.ReadLine()));
                Console.WriteLine("\n Dados da conta:");
                Console.WriteLine($" Nº da Conta: {dados.getNumero()}, Titular: {dados.getTitular()}, Saldo: {dados.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}\n");
            }
            else
            {
                Console.Write("\n Dados da conta:");
                Console.WriteLine($"\n Nº da Conta: {dados.getNumero()}, Titular: {dados.getTitular()}, Saldo: $ {dados.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}\n");
            }
            bool loop = true;

            while (loop)
            {
                try
                {
                    Console.WriteLine(" Digite a operação que deseja fazer\n");
                    Console.WriteLine(" 1 - Deposito \n 2 - Saque \n 3 - Ver saldo \n 4 - Encerrar");
                    Console.Write("\n Opção: ");
                    int op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                        Console.WriteLine("\n Entre um valor para Deposito: ");
                        Console.Write(" ");
                        dados.Deposito(double.Parse(Console.ReadLine()));
                        Console.WriteLine(" Saldo atualizado: ");
                        Console.WriteLine($" Saldo: $ {dados.getSaldo().ToString("F2", CultureInfo.InvariantCulture)} \n");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 2:
                        Console.WriteLine("\n Entre um valor para saque: ");
                        Console.Write(" ");
                        double saque = double.Parse(Console.ReadLine());

                        dados.Saque(saque);


                        Console.WriteLine(" Saldo atualizado: ");
                        Console.WriteLine($" Saldo: $ {dados.getSaldo().ToString("F2", CultureInfo.InvariantCulture)} \n");
                        Console.WriteLine(" Tecle Enter para continuar.");


                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 3:
                        Console.WriteLine(" Saldo atualizado: ");
                        Console.WriteLine($" Saldo: $ {dados.getSaldo().ToString("F2", CultureInfo.InvariantCulture)} \n");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 4:
                        Console.WriteLine(" Obrigado pela preferencia.");
                        Environment.Exit(op);
                        break;

                        default:
                        Console.WriteLine(" OPÇÃO INVALIDA.");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("DIGITE APENAS NUMEROS");
                }
            }
        }

        static void acaoCorrente()
        {
            ContaCorrente corrente = new ContaCorrente();

            Console.Write(" Haverá depósito inicial: (s/n)? ");
            char res = char.Parse(Console.ReadLine().ToLower());
            if (res.Equals('s'))
            {
                Console.Write(" Entre com o valor de depósito inicial: ");
                corrente.Deposito(double.Parse(Console.ReadLine()));
                Console.WriteLine("\n Dados da conta:");
                Console.WriteLine($" Nº da Conta: {corrente.getNumero()}, Titular: {corrente.getTitular()}, Saldo: {corrente.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}\n");
            }
            else
            {
                Console.Write("\n Dados da conta:");
                Console.WriteLine($"\n Nº da Conta: {corrente.getNumero()}, Titular: {corrente.getTitular()}, Saldo: $ {corrente.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}\n");
            }
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine(" Digite a operação que deseja fazer\n");
                    Console.WriteLine(" 1 - Deposito \n 2 - Saque \n 3 - Ver saldo \n 4 - emprestimo \n 5 - Encerrar");
                    Console.Write("\n Opção: ");
                    int op = int.Parse(Console.ReadLine());

                    switch (op)
                    {

                        case 1:
                        Console.WriteLine("\n Entre um valor para deposito: ");
                        Console.Write(" ");
                        corrente.Deposito(double.Parse(Console.ReadLine()));
                        Console.WriteLine(" Saldo atualizado: ");
                        Console.WriteLine($" Saldo: $ {corrente.getSaldo().ToString("F2", CultureInfo.InvariantCulture)} \n");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 2:
                        Console.WriteLine("\n Entre um valor para saque: ");
                        Console.Write(" ");
                        corrente.Saque(double.Parse(Console.ReadLine()));
                        Console.WriteLine(" Saldo atualizado: ");
                        Console.WriteLine($" Saldo: $ {corrente.getSaldo().ToString("F2", CultureInfo.InvariantCulture)} \n");
                        Console.WriteLine(" Tecle Enter para continuar.");

                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 3:
                        Console.WriteLine(" Saldo atualizado: ");
                        Console.WriteLine($" Saldo: $ {corrente.getSaldo().ToString("F2", CultureInfo.InvariantCulture)} \n");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 4:
                        Console.WriteLine("\n Entre o valor do empréstimo: ");
                        Console.Write(" ");
                        corrente.Emprestimo(double.Parse(Console.ReadLine()));
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 5:
                        Console.WriteLine(" Obrigado pela preferencia.");
                        Environment.Exit(op);
                        break;

                        default:
                        Console.WriteLine(" OPÇÃO INVALIDA.");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("DIGITE APENAS NUMEROS");
                }
            }

        }
    }
}
