using System;
using System.Globalization;

namespace Banco
{
    public class OpcoesDeConta
    {
<<<<<<< HEAD
        SalvarELer Salvar = new SalvarELer();
        ContaPoupanca Poupanca = new ContaPoupanca();
        ContaCorrente Corrente = new ContaCorrente();
        // coleta de dados e Opções da conta poupança

        public ContaPoupanca CriarContaPoupanca()
        {
            try
            { 
=======
        SalvarELer salvar = new SalvarELer();

        // coleta de dados e Opções da conta poupança
        ContaPoupanca poupanca = new ContaPoupanca();
        public ContaPoupanca CriarContaPoupanca()
        {
            try
            {
                salvar.SalvarEmListaPoupanca();

>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());


                if (numero >= 1000 || numero <= 10000)
                {
<<<<<<< HEAD
                    foreach (ContaPoupanca conta in Salvar.LIstaDasPoupancas)
=======
                    foreach (ContaPoupanca conta in salvar.LIstaDasPoupancas)
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
                    {
                        if (conta.getNumero() == numero)
                        {
                            Console.WriteLine("NUMERO DE CONTA JÁ CONSTA NO SISTEMA");
                            Console.ReadLine();
                            Console.Clear();
                            CriarContaPoupanca();
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
<<<<<<< HEAD
                Poupanca.setNumero(numero);
                Poupanca.setTitular(titular);
                Salvar.AtualizarContaPoupanca(Poupanca);
=======
                poupanca.setNumero(numero);
                poupanca.setTitular(titular);
                salvar.AtualizarClientePoupanca(titular, numero, poupanca.getSaldo());
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd


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
                return Poupanca;
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

<<<<<<< HEAD
                Salvar.TxtParaPoupancas();
                foreach (ContaPoupanca conta in Salvar.LIstaDasPoupancas)
=======
                salvar.SalvarEmListaPoupanca();
                foreach (ContaPoupanca conta in salvar.LIstaDasPoupancas)
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.Clear();
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}\n");
                        Confirmação++;
<<<<<<< HEAD
                        Poupanca.setNumero(numero);
                        Poupanca.setTitular(titular);
                        Poupanca.Depositar(conta.getSaldo());
=======
                        poupanca.setNumero(numero);
                        poupanca.setTitular(titular);
                        poupanca.Deposito(conta.getSaldo());
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
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
<<<<<<< HEAD
            Poupanca.Depositar(double.Parse(Console.ReadLine()));

            Salvar.AtualizarContaPoupanca(Poupanca);
=======
            double valor = double.Parse(Console.ReadLine());
            poupanca.Deposito(valor);
            salvar.AtualizarClientePoupanca(poupanca.getTitular(), poupanca.getNumero(), valor);
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd

        }
        public void SaquePoupanca()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            double valor = double.Parse(Console.ReadLine());
<<<<<<< HEAD
            Poupanca.Sacar(valor);
            Salvar.AtualizarContaPoupanca(Poupanca);
=======
            poupanca.Saque(valor);
            valor = valor * -1;
            salvar.AtualizarClientePoupanca(poupanca.getTitular(), poupanca.getNumero(), valor);
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd

        }
        public void MostrarDadosPoupanca()
        {
            Console.WriteLine(" Saldo atualizado: ");
            Console.Write("\n Dados da conta:");
<<<<<<< HEAD
            Console.WriteLine($"\n Nº da Conta: {Poupanca.getNumero()} , Titular: {Poupanca.getTitular()}, Saldo: $ {Poupanca.getSaldo().ToString("F2")}\n");
=======
            Console.WriteLine($"\n Nº da Conta: {poupanca.getNumero()} , Titular: {poupanca.getTitular()}, Saldo: $ {poupanca.getSaldo().ToString("F2")}\n");
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Render()
        {
            Console.WriteLine("Conta atualizada:");
<<<<<<< HEAD
            Poupanca.Depositar(Poupanca.Render());
            Salvar.AtualizarContaPoupanca(Poupanca);
=======
            poupanca.Deposito(poupanca.Rentabiliade());
            salvar.AtualizarClientePoupanca(poupanca.getTitular(), poupanca.getNumero(), poupanca.Rentabiliade());
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd

            Console.ReadLine();
        }

        // Coleta de dados e Opções da conta corrente

        public ContaCorrente CriarContaCorrente()
        {
            try
            {
<<<<<<< HEAD
                
=======
                salvar.SalvarEmListaCorrente();
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd

                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());


                if (numero >= 1000 || numero <= 10000)
                {
<<<<<<< HEAD
                    foreach (ContaCorrente conta in Salvar.LIstaDasCorrentes)
=======
                    foreach (ContaCorrente conta in salvar.LIstaDasCorrentes)
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
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
                Corrente.setNumero(numero);
                Corrente.setTitular(titular);
                Salvar.AtualizarContaCorrente(Corrente);


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
                return Corrente;
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

            Console.Write("Nome do Titular:");
            string titular = Console.ReadLine();

            Console.Write("Numero da conta:");
            int numero = int.Parse(Console.ReadLine());

            try
            {
                int Confirmação = 0;
<<<<<<< HEAD
                Salvar.TxtParaCorrentes();
                foreach (ContaCorrente conta in Salvar.LIstaDasCorrentes)
=======
                salvar.SalvarEmListaCorrente();
                foreach (ContaCorrente conta in salvar.LIstaDasCorrentes)
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.Clear();
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}\n");
                        Confirmação++;
<<<<<<< HEAD
                        Corrente.setNumero(numero);
                        Corrente.setTitular(titular);
                        Corrente.Depositar(conta.getSaldo());
=======
                        corrente.setNumero(numero);
                        corrente.setTitular(titular);
                        corrente.Deposito(conta.getSaldo());
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
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
<<<<<<< HEAD
            Corrente.Depositar(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);
=======
            double valor = double.Parse(Console.ReadLine());
            corrente.Deposito(valor);
            salvar.AtualizarClienteCorrente(corrente.getTitular(), corrente.getNumero(), valor);
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd

        }
        public void SaqueCorrente()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
<<<<<<< HEAD
            Corrente.Sacar(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);
=======
            double valor = double.Parse(Console.ReadLine());
            corrente.Saque(valor);
            valor = (valor + 5) * -1;
            salvar.AtualizarClienteCorrente(corrente.getTitular(), corrente.getNumero(), valor);
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd

        }
        public void MostrarDadosCorrente()
        {
            Console.Write("\n Dados da conta:");
<<<<<<< HEAD
            Console.WriteLine($"\n Nº da Conta: {Corrente.getNumero()}, Titular: {Corrente.getTitular()}, Saldo: $ {Corrente.getSaldo().ToString("F2")}\n");
=======
            Console.WriteLine($"\n Nº da Conta: {corrente.getNumero()}, Titular: {corrente.getTitular()}, Saldo: $ {corrente.getSaldo().ToString("F2")}\n");
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Emprestimo()
        {
            Console.WriteLine("\n Entre o valor do empréstimo: ");
            Console.Write(" ");
<<<<<<< HEAD
            Corrente.SolicitarEmprestimo(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);
=======
            double valor = double.Parse(Console.ReadLine());
            corrente.Emprestimo(valor);
            salvar.AtualizarClienteCorrente(corrente.getTitular(), corrente.getNumero(), valor);
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}


