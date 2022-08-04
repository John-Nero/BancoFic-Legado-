using System;
using System.IO;

namespace Banco
{
    class SalvarELer
    {

        const string CaminhoPoupanca = @"C:\temp\BancoFic\DadosClientes\DadosDosClientesPoupanca.txt";
        const string CaminhoCorrente = @"C:\temp\BancoFic\DadosClientes\DadosDosClientesCorrente.txt";
        //Metodos de Save e procura da conta poupanca
        public void RegistrarCliente_AtualizarClientePoupanca(int numero, string titular, double saldo)
        {
            using var file = File.AppendText(CaminhoPoupanca);
            file.WriteLine($"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}");
            file.Close();
        }
        
        public void procurarLinhapoupanca(int numero, string titular, double saldo)
        {
            try
            {
                string a = $"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}";
                string[] leOTexto = File.ReadAllLines(CaminhoPoupanca);

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


    
