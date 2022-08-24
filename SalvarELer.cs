using System;
using System.IO;
using System.Collections.Generic;
namespace Banco
{

    class SalvarELer
    {
        //Caminhos Para Local De Busca
        internal const string CaminhoPoupanca = @"C:\temp\projeto\DadosClientes\DadosDosClientesPoupanca.txt";
        internal const string CaminhoCorrente = @"C:\temp\projeto\DadosClientes\DadosDosClientesCorrente.txt";

        //Metodos de Save e atualização da conta poupanca
        public List<ContaPoupanca> LIstaDasPoupancas = new List<ContaPoupanca>();

        internal List<ContaPoupanca> SalvarEmListaPoupanca()
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void AtualizarClientePoupanca(string titular, int numero, double valor)
        {
            double saldo = valor;
            foreach (ContaPoupanca conta in LIstaDasPoupancas)
            {
                if (titular == conta.getTitular() && numero == conta.getNumero())
                {
                    saldo += conta.getSaldo();
                    File.Delete(CaminhoPoupanca);
                    LIstaDasPoupancas.Remove(conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoPoupanca);
            LIstaDasPoupancas.Add(new ContaPoupanca(titular, numero, saldo));
            file.Close();
            RegistrarClientePoupanca();
            Console.WriteLine($"\n TITULAR:{titular} NUMERO: {numero} SALDO: {saldo.ToString("F2")}\n");
        }
        public void RegistrarClientePoupanca()
        {
            File.Delete(CaminhoPoupanca);

            using var file = File.AppendText(CaminhoPoupanca);

            foreach (ContaPoupanca conta in LIstaDasPoupancas)
            {
                string titular = conta.getTitular();
                int numero = conta.getNumero();
                double saldo = conta.getSaldo();
                file.WriteLine($"{titular} | {numero} | {saldo.ToString("F2")}");
            }
            file.Close();
        }

        //Metodos de save e atualização da conta corrente
        public List<ContaCorrente> LIstaDasCorrentes = new List<ContaCorrente>();

        internal List<ContaCorrente> SalvarEmListaCorrente()
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
                return LIstaDasCorrentes;
            }
            catch (Exception e) { Console.WriteLine(e); throw; }
        }
        public void AtualizarClienteCorrente(string titular, int numero, double valor)
        {
            double saldo = valor;
            foreach (ContaCorrente conta in LIstaDasCorrentes)
            {
                if (titular == conta.getTitular() && numero == conta.getNumero())
                {
                    saldo += conta.getSaldo();
                    File.Delete(CaminhoCorrente);
                    LIstaDasCorrentes.Remove(conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoCorrente);
            LIstaDasCorrentes.Add(new ContaCorrente(titular, numero, saldo));
            file.Close();
            RegistrarClienteCorrente();
            Console.WriteLine($"\n TITULAR:{titular} NUMERO: {numero} SALDO: {saldo.ToString("F2")}\n");
        }
        public void RegistrarClienteCorrente()
        {
            File.Delete(CaminhoCorrente);
            using var file = File.AppendText(CaminhoCorrente);

            foreach (ContaCorrente conta in LIstaDasCorrentes)
            {
                string titular = conta.getTitular();
                int numero = conta.getNumero();
                double saldo = conta.getSaldo();
                file.WriteLine($"{titular} | {numero} | {saldo.ToString("F2")}");
            }
            file.Close();
        }

    }
}