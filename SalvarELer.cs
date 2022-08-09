using System;
using System.Collections.Generic;
using System.IO;

namespace Banco
{
    class SalvarELer
    {

        //CaminhosParaLocalDeBusca
        const string CaminhoPoupanca = @"C:\temp\BancoFic\DadosClientes\DadosDosClientesPoupanca.txt";
        const string CaminhoCorrente = @"C:\temp\BancoFic\DadosClientes\DadosDosClientesCorrente.txt";

        //Metodos de divição de dados
        internal int NumeroDeConta(string ModeloParaDivisao)
        {
            //DADOS DA CONTA | NUMERO: 4578 | TITULAR: john | SALDO: 0

            string[] ModeloInteiro = ModeloParaDivisao.Split(" | ");
            string[] numeroSemFormat = ModeloInteiro[1].Split("NUMERO: ");
            int numeroFormat = int.Parse(numeroSemFormat[1]);
            return numeroFormat;
        }
        internal string TitularDeConta(string ModeloParaDivisao)
        {
            //DADOS DA CONTA | NUMERO: 4578 | TITULAR: john | SALDO: 0

            string[] ModeloInteiro = ModeloParaDivisao.Split(" | ");
            string[] titularSemFormat = ModeloInteiro[2].Split("TITULAR: ");
            string titularFormat = titularSemFormat[1];
            return titularFormat;
        }
        internal double SaldoDeConta(string ModeloParaDivisao)
        {
            //DADOS DA CONTA | NUMERO: 4578 | TITULAR: john | SALDO: 0

            string[] ModeloInteiro = ModeloParaDivisao.Split(" | ");
            string[] saldoSemFormat = ModeloInteiro[3].Split("SALDO: ");
            double saldoFormat = double.Parse(saldoSemFormat[1]);
            return saldoFormat;
        }

        //Metodos de Save e procura da conta poupanca
        public void RegistrarCliente_AtualizarClientePoupanca(int numero, string titular, double saldo)
        {
            using var file = File.AppendText(CaminhoPoupanca);
            file.WriteLine($"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}");
            file.Close();
        }

        public void procurarLinhapoupanca(string titular, int numero)
        {

            try
            {
                List<string> ModelosDeConta = new List<string>();
                List<ContaPoupanca> LIstaDasPoupancas = new List<ContaPoupanca>();
                string[] LeTexto = File.ReadAllLines(CaminhoPoupanca);

                
                foreach (string s in LeTexto)
                {
                    
                    int numeroPararRegistro = NumeroDeConta(s);
                    string titularPararRegistro = TitularDeConta(s);
                    double saldoPararRegistro = SaldoDeConta(s);

                    LIstaDasPoupancas.Add(new ContaPoupanca(numeroPararRegistro, titularPararRegistro, saldoPararRegistro));

                    
                }
                
                foreach (ContaPoupanca conta in LIstaDasPoupancas)
                {
                    if (conta.getNumero() == numero && conta.getTitular() == titular)
                    {
                        Console.WriteLine(" CONTA SELECIONADA:");
                        Console.WriteLine($"TITULAR:{conta.getTitular()} NUMERO: {conta.getNumero()} SALDO: {conta.getSaldo().ToString("F2")}");
                        
                    }
                    else { Console.WriteLine("CONTA NÃO LOCALIZADA."); }
                }

            }
            catch (FieldAccessException e)
            {
                Console.WriteLine("Ops... isso não deveria ter acontecido.");
                Console.WriteLine(e.Message);
            }
        }

        //Metodos de Save e procura da conta corrente
        public void RegistrarClienteCorrente(int numero, string titular, double saldo)
        {
            using var file = File.AppendText(CaminhoCorrente);
            file.WriteLine($"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}");
            file.Close();
        }

        public void procurarLinhaCorrente(int numero, string titular, double saldo)
        {
            try
            {
                string a = $"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}";
                string[] leOTexto = File.ReadAllLines(CaminhoCorrente);

                foreach (string s in leOTexto)
                {
                    if (s.Equals(a))
                    {
                        Console.WriteLine(s);
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



