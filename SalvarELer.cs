using System;
using System.IO;
using System.Collections.Generic;
namespace Banco
{

    class SalvarELer
    {
        ContaPoupanca a = new ContaPoupanca();
        //Caminhos Para Local De Busca
        const string CaminhoPoupanca = @"C:\temp\projeto\DadosClientes\DadosDosClientesPoupanca.txt";
        const string CaminhoCorrente = @"C:\temp\projeto\DadosClientes\DadosDosClientesCorrente.txt";

        //Metodos de Save e procura da conta poupanca
        public List<ContaPoupanca> LIstaDasPoupancas = new List<ContaPoupanca>();

        internal List<ContaPoupanca> salvarEmListaPoupanca()
        {
            //john | 4578 | 0
            try
            {
                string[] LeTexto = File.ReadAllLines(CaminhoPoupanca);
                foreach (string s in LeTexto)
                {
                    string[] ModeloInteiro = s.Split(" | ");

                    string titular = ModeloInteiro[0];
                    int numero = int.Parse(ModeloInteiro[1]);
                    double saldo = double.Parse(ModeloInteiro[2]);
                    ContaPoupanca contacompleta = new ContaPoupanca(titular, numero, saldo);

                    LIstaDasPoupancas.Add(contacompleta);
                    
                }
                return LIstaDasPoupancas;
            }
            catch (Exception e) { Console.WriteLine(e); throw;}
        }
        public void AtualizarClientePoupanca(string titular, int numero, double saldo)
        {
            foreach (ContaPoupanca conta in LIstaDasPoupancas)
            {
                if (titular == conta.getTitular() && numero == conta.getNumero())
                {
                    File.Delete(CaminhoPoupanca);
                    LIstaDasPoupancas.Remove(conta);
                    break;
                }
            }
            using var file = File.AppendText(CaminhoPoupanca);
            LIstaDasPoupancas.Add(new ContaPoupanca(titular, numero, saldo));
            file.Close();
            RegistrarClientePoupanca();
        }
        public void RegistrarClientePoupanca()
        {
            using var file = File.AppendText(CaminhoPoupanca);
            foreach (ContaPoupanca conta in LIstaDasPoupancas)
            {
                string titular = conta.getTitular();
                int numero = conta.getNumero();
                double saldo = conta.getSaldo();
                file.WriteLine($"{titular} | {numero} | {saldo}");
            }
            file.Close();
        }
        public void ProcurarLinhaPoupanca(string titular, int numero)
        {
            try
            {
                salvarEmListaPoupanca();
                foreach (ContaPoupanca conta in LIstaDasPoupancas)
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"\n TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}\n");
                    }
                }
            }
            catch (FieldAccessException e)
            {
                Console.WriteLine("Ops... isso não deveria ter acontecido.");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("DADOS INCORRETOS OU CONTA NÂO CONSTA NO SISTEMA");
        }

        //Metodos de save e procura da conta corrente
        List<ContaCorrente> LIstaDasCorrentes = new List<ContaCorrente>();

        internal void salvarEmListaCorrente()
        {
            //john | 4578 | 0
            try
            {
                string[] LeTexto = File.ReadAllLines(CaminhoCorrente);
                foreach (string s in LeTexto)
                {
                    string[] ModeloInteiro = s.Split(" | ");

                    string titular = ModeloInteiro[0];
                    int numero = int.Parse(ModeloInteiro[1]);
                    double saldo = double.Parse(ModeloInteiro[2]);
                    ContaCorrente contacompleta = new ContaCorrente(titular, numero, saldo);

                    LIstaDasCorrentes.Add(contacompleta);
                }

            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void AtualizarClienteCorrente(string titular, int numero, double saldo)
        {
            foreach (ContaCorrente conta in LIstaDasCorrentes)
            {
                if (titular == conta.getTitular() && numero == conta.getNumero())
                {
                    File.Delete(CaminhoCorrente);
                    LIstaDasCorrentes.Remove(conta);
                    break;
                }
            }
            using var file = File.AppendText(CaminhoCorrente);
            LIstaDasCorrentes.Add(new ContaCorrente(titular, numero, saldo));
            file.Close();
            RegistrarClienteCorrente();
        }
        public void RegistrarClienteCorrente()
        {
            using var file = File.AppendText(CaminhoCorrente);
            foreach (ContaCorrente conta in LIstaDasCorrentes)
            {
                string titular = conta.getTitular();
                int numero = conta.getNumero();
                double saldo = conta.getSaldo();
                file.WriteLine($"{titular} | {numero} | {saldo}");
            }
            file.Close();
        }
        public void ProcurarLinhaCorrente(string titular, int numero)
        {
            try
            {
                foreach (ContaCorrente conta in LIstaDasCorrentes)
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}");
                    }
                }
            }
            catch (FieldAccessException e)
            {
                Console.WriteLine("Ops... isso não deveria ter acontecido.");
                Console.WriteLine(e.Message);
            }
        }
    }
}