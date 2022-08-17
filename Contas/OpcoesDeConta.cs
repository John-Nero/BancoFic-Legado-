using System;
using System.Globalization;

namespace Banco
{
    class OpcoesDeConta // se atentar aos modificadores de acesso e reestruturar para tirar duplicidade de codigo
    {
        SalvarELer salvar = new SalvarELer(); // iniciar letra maiuscula

        // coleta de dados e Opções da conta poupança
        ContaPoupanca poupanca = new ContaPoupanca(); // Cuidado com a quebra de estrutura de Atributos para cima e metodos para baixo EX: linha 171
        public ContaPoupanca CriarContaPoupanca()
        {
            try
            {
                salvar.SalvarEmListaPoupanca(); // Qual o intuito dessa linha?

                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());


                if (numero >= 1000 || numero <= 10000)
                {
                    foreach (ContaPoupanca conta in salvar.LIstaDasPoupancas)
                    {
                        if (conta.getNumero() == numero)
                        {
                            Console.WriteLine("NUMERO DE CONTA JÁ CONSTA NO SISTEMA");
                            Console.ReadLine();
                            Console.Clear();
                            CriarContaPoupanca(); // Encerrar o codigo
                        }
                    }
                }
                else
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
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 15)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da conta:{numero}");
                    goto VoltaNome;
                }
                poupanca.setNumero(numero);
                poupanca.setTitular(titular);
                salvar.AtualizarClientePoupanca(titular, numero, poupanca.getSaldo());


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
            Console.WriteLine("Digite os dados a seguir para consultar se sua conta já consta no sistema\n");

            Console.Write("Nome do Titular:");
            string titular = Console.ReadLine();

            Console.Write("Numero da conta:");
            int numero = int.Parse(Console.ReadLine());

            try
            {
                int Confirmação = 0;

                salvar.SalvarEmListaPoupanca();
                foreach (ContaPoupanca conta in salvar.LIstaDasPoupancas)
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.Clear();
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}\n");
                        Confirmação++;
                        poupanca.setNumero(numero);
                        poupanca.setTitular(titular);
                        poupanca.Deposito(conta.getSaldo());
                    }
                }
                if (Confirmação == 0)
                {
                    Console.WriteLine("DADOS INCORRETOS OU CONTA NÃO CONSTA NO SISTEMA");
                    Console.ReadLine();
                    Console.Clear();
                    ConsultarContaPoupanca();
                }
            }
            catch (FieldAccessException e)
            {
                Console.WriteLine("Ops... isso não deveria ter acontecido.");
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public void DepositoPoupanca()
        {
            Console.WriteLine("\n Entre um quantidade para Deposito: ");
            Console.Write(" ");
            double valor = double.Parse(Console.ReadLine());
            poupanca.Deposito(valor);
            salvar.AtualizarClientePoupanca(poupanca.getTitular(), poupanca.getNumero(), valor);

        }
        public void SaquePoupanca()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            double valor = double.Parse(Console.ReadLine());
            poupanca.Saque(valor);
            valor = valor * -1;
            salvar.AtualizarClientePoupanca(poupanca.getTitular(), poupanca.getNumero(), valor);

        }
        public void MostrarDadosPoupanca()
        {
            Console.WriteLine(" Saldo atualizado: ");
            Console.Write("\n Dados da conta:");
            Console.WriteLine($"\n Nº da Conta: {poupanca.getNumero()} , Titular: {poupanca.getTitular()}, Saldo: $ {poupanca.getSaldo().ToString("F2")}\n");
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Render()
        {
            Console.WriteLine("Conta atualizada:");
            poupanca.Deposito(poupanca.Rentabiliade());
            salvar.AtualizarClientePoupanca(poupanca.getTitular(), poupanca.getNumero(), poupanca.Rentabiliade());

            Console.ReadLine();
        }

        // Coleta de dados e Opções da conta corrente
        ContaCorrente corrente = new ContaCorrente(); // Conta perdida no meio do codigo
        public ContaCorrente CriarContaCorrente() 
        {
            try
            {
                salvar.SalvarEmListaCorrente(); // Qual o intuito dessa linha existir?

                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());


                if (numero >= 1000 || numero <= 10000)
                {
                    foreach (ContaCorrente conta in salvar.LIstaDasCorrentes)
                    {
                        if (conta.getNumero() == numero)
                        {
                            Console.WriteLine("NUMERO DE CONTA JÁ CONSTA NO SISTEMA");
                            Console.ReadLine();
                            Console.Clear();
                            CriarContaCorrente();
                        }
                    }
                }
                else
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
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 15)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da conta:{numero}");
                    goto VoltaNome;
                }
                corrente.setNumero(numero);
                corrente.setTitular(titular);
                salvar.AtualizarClienteCorrente(titular, numero, corrente.getSaldo());


            voltaDeposito:
                Console.Write(" Haverá depósito inicial: (s/n)? ");
                char res = char.Parse(Console.ReadLine().ToLower());
                if (res.Equals('s'))
                {
                    DepositoCorrente();
                }
                else if (res.Equals('n'))
                {
                    MostrarDadosCorrente();
                }
                else
                {
                    Console.WriteLine("OPÇÃO INVALIDA!");
                    Console.ReadLine();
                    goto voltaDeposito;
                }
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
            Console.WriteLine("Digite os dados a seguir para consultar se sua conta já consta no sistema\n");

            Console.Write("Nome do Titular:"); // apenas numero da conta ja basta
            string titular = Console.ReadLine();

            Console.Write("Numero da conta:");
            int numero = int.Parse(Console.ReadLine());

            try
            {
                int Confirmação = 0;
                salvar.SalvarEmListaCorrente();
                foreach (ContaCorrente conta in salvar.LIstaDasCorrentes)
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.Clear();
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}\n");
                        Confirmação++;
                        corrente.setNumero(numero);
                        corrente.setTitular(titular);
                        corrente.Deposito(conta.getSaldo());
                    }
                }
                if (Confirmação == 0)
                {
                    Console.WriteLine("DADOS INCORRETOS OU CONTA NÃO CONSTA NO SISTEMA");
                    Console.ReadLine();
                    Console.Clear();
                    ConsultarContaCorrente();
                }
            }
            catch (FieldAccessException e)
            {
                Console.WriteLine("Ops... isso não deveria ter acontecido.");
                Console.WriteLine(e.Message);
                throw;
            }

        }
        public void DepositoCorrente()
        {
            Console.WriteLine("\n Entre um quantidade para Deposito: ");
            Console.Write(" ");
            double valor = double.Parse(Console.ReadLine());
            corrente.Deposito(valor);
            salvar.AtualizarClienteCorrente(corrente.getTitular(), corrente.getNumero(), valor);

        }
        public void SaqueCorrente()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            double valor = double.Parse(Console.ReadLine());
            corrente.Saque(valor);
            valor = (valor + 5) * -1;
            salvar.AtualizarClienteCorrente(corrente.getTitular(), corrente.getNumero(), valor);

        }
        public void MostrarDadosCorrente()
        {
            Console.Write("\n Dados da conta:");
            Console.WriteLine($"\n Nº da Conta: {corrente.getNumero()}, Titular: {corrente.getTitular()}, Saldo: $ {corrente.getSaldo().ToString("F2")}\n");
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Emprestimo()
        {
            Console.WriteLine("\n Entre o valor do empréstimo: ");
            Console.Write(" ");
            double valor = double.Parse(Console.ReadLine());
            corrente.Emprestimo(valor);
            salvar.AtualizarClienteCorrente(corrente.getTitular(), corrente.getNumero(), valor);
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}


