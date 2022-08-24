using System;
using System.IO;
using System.Collections.Generic;
namespace Banco
{

    public class SalvarELer
    {
        //Caminhos Para Local De Busca
        internal const string CaminhoPoupanca = @"C:\temp\projeto\DadosClientes\DadosDosClientesPoupanca.txt";
        internal const string CaminhoCorrente = @"C:\temp\projeto\DadosClientes\DadosDosClientesCorrente.txt";

        //Listas dos tipos de conta
        public List<ContaPoupanca> LIstaDasPoupancas = new List<ContaPoupanca>();
        public List<ContaCorrente> LIstaDasCorrentes = new List<ContaCorrente>();

        //Metodos de Save e atualização da conta poupanca
        internal List<ContaPoupanca> TxtParaPoupancas()
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
        public void AtualizarContaPoupanca(ContaPoupanca poupanca)
        {

            if (LIstaDasPoupancas.Count == 0)
            {
                TxtParaPoupancas();
            }
            foreach (ContaPoupanca conta in LIstaDasPoupancas)
            {
                if (poupanca.Titular == conta.Titular && poupanca.Numero == conta.Numero)
                {

                    LIstaDasPoupancas.Remove(conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoPoupanca);
            LIstaDasPoupancas.Add(new ContaPoupanca(poupanca.Titular, poupanca.Numero, poupanca.Saldo));
            file.Close();

            SalvarListaContaPoupancaNoTxt();
            Console.WriteLine($"\n TITULAR:{poupanca.Titular} NUMERO: {poupanca.Numero} SALDO: {poupanca.Saldo.ToString("F2")}\n");
        }
        public void SalvarListaContaPoupancaNoTxt()
        {
            File.Delete(CaminhoPoupanca);

            using var file = File.AppendText(CaminhoPoupanca);

            foreach (ContaPoupanca conta in LIstaDasPoupancas)
            {
                string titular = conta.Titular;
                int numero = conta.Numero;
                double saldo = conta.Saldo;
                file.WriteLine($"{titular} | {numero} | {saldo.ToString("F2")}");
            }
            file.Close();
        }

        //Metodos de save e atualização da conta corrente
        internal List<ContaCorrente> TxtParaCorrentes()
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void AtualizarContaCorrente(ContaCorrente corrente)
        {
            if (LIstaDasCorrentes.Count == 0)
            {
                TxtParaPoupancas();
            }
            foreach (ContaCorrente conta in LIstaDasCorrentes)
            {
                if (corrente.Titular == conta.Titular && corrente.Numero == conta.Numero)
                {

                    LIstaDasCorrentes.Remove(conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoCorrente);
            LIstaDasCorrentes.Add(new ContaCorrente(corrente.Titular, corrente.Numero, corrente.Saldo));
            file.Close();

            SalvarListaContaCorrenteNoTxt();
            Console.WriteLine($"\n TITULAR:{corrente.Titular} NUMERO: {corrente.Numero} SALDO: {corrente.Saldo.ToString("F2")}\n");
        }
        public void SalvarListaContaCorrenteNoTxt()
        {
            File.Delete(CaminhoCorrente);

            using var file = File.AppendText(CaminhoCorrente);

            foreach (ContaCorrente conta in LIstaDasCorrentes)
            {
                string titular = conta.Titular;
                int numero = conta.Numero;
                double saldo = conta.Saldo;
                file.WriteLine($"{titular} | {numero} | {saldo.ToString("F2")}");
            }
            file.Close();
        }

    }
}