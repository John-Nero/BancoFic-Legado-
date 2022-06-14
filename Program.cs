using System;
using System.Globalization;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" Entre com o numero da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write(" Entre com o titular da conta: ");
            string titular = Console.ReadLine();
            DadosBancarios dados = new DadosBancarios(numero, titular);
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
                    double saldo = dados.getSaldo();
                    Console.WriteLine(" Entre o valor do saque: ");
                    Console.Write(" ");
                    double valor = double.Parse(Console.ReadLine());
                    
                    if (saldo > valor)
                    {
                        dados.Saque(valor);
                        Console.WriteLine(" Saldo atualizado: ");
                        Console.WriteLine($" Saldo: $ {dados.getSaldo().ToString("F2", CultureInfo.InvariantCulture)} ");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(" SALDO INSUFICIENTE!.");
                        break;
                    }


                    case 3:
                    Console.WriteLine($" Saldo atual: {dados.getSaldo().ToString("F2", CultureInfo.InvariantCulture)}");
                    Console.WriteLine(" Tecle Enter para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                    break;

                    case 4:
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

        }
    }
}