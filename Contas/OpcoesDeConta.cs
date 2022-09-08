using System;
using System.Globalization;

namespace Banco
{
    public class OpcoesDeConta
    {
        SalvarELer Salvar = new SalvarELer();
        ContaPoupanca Poupanca = new ContaPoupanca();
        ContaCorrente Corrente = new ContaCorrente();
        // coleta de dados e Opções da Conta poupança

        public ContaPoupanca CriarContaPoupanca()
        {
            try
            {
                Random random = new Random();
                int numero = random.Next(1000, 10000);
                Salvar.TxtParaPoupancas();
                foreach (ContaPoupanca Conta in Salvar.LIstaDasPoupancas)
                {
                    if (Conta.Numero == numero && numero.ToString().Length != 4)
                    {
                        Console.WriteLine("aaaaaaaaaaaaaaaaa");
                    }
                    else { break; }
                }


            VoltaNome:
                Console.Write(" Entre com o titular da Conta: ");
                string titular = Console.ReadLine();


                int confirmacaoTitular = titular.Length;
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 15)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da Conta:{numero}");
                    goto VoltaNome;
                }
                Poupanca.setNumero(numero);
                Poupanca.setTitular(titular);
                Salvar.AtualizarContaPoupanca(Poupanca);

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
            Console.WriteLine("Digite os dados a seguir para consultar se sua Conta já consta no sistema\n");

            Console.Write("Nome do Titular:");
            string titular = Console.ReadLine();

            Console.Write("Numero da Conta:");
            int numero = int.Parse(Console.ReadLine());

            try
            {
                int Confirmação = 0;

                Salvar.TxtParaPoupancas();
                foreach (ContaPoupanca Conta in Salvar.LIstaDasPoupancas)
                {
                    if (Conta.Numero == numero && Conta.Titular == titular)
                    {

                        Console.Clear();
                        Console.WriteLine(" Conta SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{Conta.Titular} NUMERO: {Conta.Numero} SALDO: {Conta.Saldo.ToString("F2")}\n");
                        Confirmação++;
                        Poupanca.setNumero(numero);
                        Poupanca.setTitular(titular);
                        Poupanca.Depositar(Conta.Saldo);
                    }
                }
                if (Confirmação == 0)
                {
                    Console.WriteLine("DADOS INCORRETOS OU Conta NÃO CONSTA NO SISTEMA");
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
            Poupanca.Depositar(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaPoupanca(Poupanca);
        }
        public void SaquePoupanca()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            double valor = double.Parse(Console.ReadLine());
            Poupanca.Sacar(valor);
            Salvar.AtualizarContaPoupanca(Poupanca);
        }
        public void MostrarDadosPoupanca()
        {
            Console.WriteLine(" Saldo atualizado: ");
            Console.Write("\n Dados da Conta:");
            Console.WriteLine($"\n Nº da Conta: {Poupanca.Numero} , Titular: {Poupanca.Titular}, Saldo: $ {Poupanca.Saldo.ToString("F2")}\n");
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Render()
        {
            Console.WriteLine("Conta atualizada:");
            Poupanca.Depositar(Poupanca.Render());
            Salvar.AtualizarContaPoupanca(Poupanca);
            Console.ReadLine();
        }

        // Coleta de dados e Opções da Conta corrente

        public ContaCorrente CriarContaCorrente()
        {
            try
            {
                Random random = new Random();
                int numero = random.Next(1000, 10000);
                Salvar.TxtParaCorrentes();
                foreach (ContaCorrente Conta in Salvar.LIstaDasCorrentes)
                {
                    if (Conta.Numero == numero && numero.ToString().Length != 4)
                    {
                        Console.WriteLine("aaaaaaaaaaaaaaaaa");
                    }
                    else { break; }
                }

            VoltaNome:
                Console.Write(" Entre com o titular da Conta: ");
                string titular = Console.ReadLine();

                int confirmacaoTitular = titular.Length;
                if (confirmacaoTitular < 3 || confirmacaoTitular >= 15)
                {
                    Console.WriteLine(" NOME MUITO CURTO OU MUITO LONGO, DIGITE ENTRE QUATRO E DEZ CARACTERES");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($" Numero da Conta:{numero}");
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
            Console.WriteLine("Digite os dados a seguir para consultar se sua Conta já consta no sistema\n");

            Console.Write("Nome do Titular:");
            string titular = Console.ReadLine();

            Console.Write("Numero da Conta:");
            int numero = int.Parse(Console.ReadLine());

            try
            {
                int Confirmação = 0;
                Salvar.TxtParaCorrentes();
                foreach (ContaCorrente Conta in Salvar.LIstaDasCorrentes)
                {
                    if (Conta.Numero == numero && Conta.Titular == titular)
                    {
                        Console.Clear();
                        Console.WriteLine(" Conta SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{Conta.Titular} NUMERO: {Conta.Numero} SALDO: {Conta.Saldo.ToString("F2")}\n");
                        Confirmação++;
                        Corrente.setNumero(numero);
                        Corrente.setTitular(titular);
                        Corrente.Depositar(Conta.Saldo);
                        Corrente.SetLimitEmprestimo(Conta.LimiteEmprestimo);

                    }
                }
                if (Confirmação == 0)
                {
                    Console.WriteLine("DADOS INCORRETOS OU Conta NÃO CONSTA NO SISTEMA");
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
            Corrente.Depositar(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);
        }
        public void SaqueCorrente()
        {
            Console.WriteLine("\n Entre um valor para saque: ");
            Console.Write(" ");
            Corrente.Sacar(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);
        }
        public void MostrarDadosCorrente()
        {
            Console.Write("\n Dados da Conta:");
            Console.WriteLine($"\n Nº da Conta: {Corrente.Numero}, Titular: {Corrente.Titular}, Saldo: $ {Corrente.Saldo.ToString("F2")}\n");
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
        public void Emprestimo()
        {
            Console.WriteLine("\n Entre o valor do empréstimo: ");
            Console.Write(" ");
            Corrente.SolicitarEmprestimo(double.Parse(Console.ReadLine()));
            Salvar.AtualizarContaCorrente(Corrente);
            Console.WriteLine(" Tecle Enter para continuar.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}


