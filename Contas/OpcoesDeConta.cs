using System;
using System.Globalization;

namespace Banco
{
    public class OpcoesDeConta
    {
        SalvarELer Salvar = new SalvarELer();
        ContaPoupanca Poupanca = new ContaPoupanca();
        ContaCorrente Corrente = new ContaCorrente();
        // coleta de dados e Opções da conta poupança

        public ContaPoupanca CriarContaPoupanca()
        {
            try
            {
                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());


                if (numero >= 1000 || numero <= 10000)
                {
                    foreach (ContaPoupanca conta in Salvar.LIstaDasPoupancas)
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
                salvar.RegistrarCliente_AtualizarClientePoupanca(numero, titular, poupanca.getSaldo());
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)


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
<<<<<<< HEAD
            Console.WriteLine("Digite os dados a seguir para consultar se sua conta já consta no sistema\n");
=======
            
            Console.WriteLine("Digite os dados a seguir para consultar se sua conta já consta no sistema");
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)

            Console.Write("Nome do Titular:");
            string titular = Console.ReadLine();

            Console.WriteLine("");

            Console.Write("Numero da conta:");
            int numero = int.Parse(Console.ReadLine());
<<<<<<< HEAD

            try
            {
                int Confirmação = 0;

                Salvar.TxtParaPoupancas();
                foreach (ContaPoupanca conta in Salvar.LIstaDasPoupancas)
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.Clear();
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}\n");
                        Confirmação++;
                        Poupanca.setNumero(numero);
                        Poupanca.setTitular(titular);
                        Poupanca.Depositar(conta.getSaldo());
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
=======
                        
            salvar.procurarLinhapoupanca(titular, numero);
             
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
        }
        public void DepositoPoupanca()
        {
            Console.WriteLine("\n Entre um quantidade para Deposito: ");
            Console.Write(" ");
<<<<<<< HEAD
            Poupanca.Depositar(double.Parse(Console.ReadLine()));

            Salvar.AtualizarContaPoupanca(Poupanca);

=======
            poupanca.Deposito(double.Parse(Console.ReadLine()));
            salvar.RegistrarCliente_AtualizarClientePoupanca(poupanca.getNumero(), poupanca.getTitular(), poupanca.getSaldo());
            MostrarDadosPoupanca();
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
        }
        public void SaquePoupanca()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
<<<<<<< HEAD
            double valor = double.Parse(Console.ReadLine());
            Poupanca.Sacar(valor);
            Salvar.AtualizarContaPoupanca(Poupanca);

=======
            double saque = double.Parse(Console.ReadLine());
            poupanca.Saque(saque);
            salvar.RegistrarCliente_AtualizarClientePoupanca(poupanca.getNumero(), poupanca.getTitular(), poupanca.getSaldo());
            MostrarDadosPoupanca();
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
        }
        public void MostrarDadosPoupanca()
        {
            Console.WriteLine(" Saldo atualizado: ");
            Console.Write("\n Dados da conta:");
            Console.WriteLine($"\n Nº da Conta: {Poupanca.getNumero()} , Titular: {Poupanca.getTitular()}, Saldo: $ {Poupanca.getSaldo().ToString("F2")}\n");
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Render()
        {
<<<<<<< HEAD
            Console.WriteLine("Conta atualizada:");
            Poupanca.Depositar(Poupanca.Render());
            Salvar.AtualizarContaPoupanca(Poupanca);

=======
            Console.WriteLine("Saldo após renda:");
            poupanca.Rentabiliade();
            salvar.RegistrarCliente_AtualizarClientePoupanca(poupanca.getNumero(), poupanca.getTitular(), poupanca.getSaldo());
            Console.WriteLine(poupanca.getSaldo());
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
            Console.ReadLine();
        }

        // Coleta de dados e Opções da conta corrente
<<<<<<< HEAD

        public ContaCorrente CriarContaCorrente()
=======
        ContaCorrente corrente = new ContaCorrente();
        public Conta CriarContaCorrente()
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
        {
            try
            {


                Console.Write(" Entre com o numero da conta: ");
                int numero = int.Parse(Console.ReadLine());


                if (numero >= 1000 || numero <= 10000)
                {
                    foreach (ContaCorrente conta in Salvar.LIstaDasCorrentes)
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
<<<<<<< HEAD
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 15)
=======
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 10)
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da conta:{numero}");
                    goto VoltaNome;
                }
<<<<<<< HEAD
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
=======
                corrente.setNumero(numero);
                corrente.setTitular(titular);
                salvar.RegistrarClienteCorrente(numero, titular, corrente.getSaldo());
                return corrente;
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
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
<<<<<<< HEAD

            try
            {
                int Confirmação = 0;
                Salvar.TxtParaCorrentes();
                foreach (ContaCorrente conta in Salvar.LIstaDasCorrentes)
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.Clear();
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}\n");
                        Confirmação++;
                        Corrente.setNumero(numero);
                        Corrente.setTitular(titular);
                        Corrente.Depositar(conta.getSaldo());
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

=======
            Console.WriteLine("");
            Console.WriteLine("Saldo:");
            double saldo = double.Parse(Console.ReadLine());
            salvar.procurarLinhaCorrente(numero, titular, saldo);
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
        }
        public void DepositoCorrente()
        {
            Console.WriteLine("\n Entre um quantidade para Deposito: ");
            Console.Write(" ");
<<<<<<< HEAD
            Corrente.Depositar(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);

=======
            corrente.Deposito(double.Parse(Console.ReadLine()));
            salvar.RegistrarClienteCorrente(corrente.getNumero(), corrente.getTitular(), corrente.getSaldo());
            MostrarDadosCorrente();
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
        }
        public void SaqueCorrente()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
<<<<<<< HEAD
            Corrente.Sacar(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);

=======
            corrente.Saque(double.Parse(Console.ReadLine()));
            salvar.RegistrarClienteCorrente(corrente.getNumero(), corrente.getTitular(), corrente.getSaldo());
            MostrarDadosCorrente();
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
        }
        public void MostrarDadosCorrente()
        {
            Console.Write("\n Dados da conta:");
            Console.WriteLine($"\n Nº da Conta: {Corrente.getNumero()}, Titular: {Corrente.getTitular()}, Saldo: $ {Corrente.getSaldo().ToString("F2")}\n");
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
            corrente.Emprestimo(double.Parse(Console.ReadLine()));
            salvar.RegistrarClienteCorrente(corrente.getNumero(), corrente.getTitular(), corrente.getSaldo());
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }

    }
}


