using System;
using System.IO;
using System.Collections.Generic;
namespace Banco
{

    public class SalvarELer
    {
        //Caminhos Para Local De Busca
        internal const string CaminhoPoupanca = @"C:\temp\bancofic\DadosClientes\DadosDosClientesPoupanca.txt";
        internal const string CaminhoCorrente = @"C:\temp\bancofic\DadosClientes\DadosDosClientesCorrente.txt";

        //Listas dos tipos de Conta
        public List<ContaPoupanca> LIstaDasPoupancas = new List<ContaPoupanca>();
        public List<ContaCorrente> LIstaDasCorrentes = new List<ContaCorrente>();

        //Metodos de Save e atualização da Conta Poupanca
        public List<ContaPoupanca> TxtParaPoupancas()
        {   //Nome | Numero | Saldo
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
                    LIstaDasPoupancas.Add(new ContaPoupanca(titular, numero, saldo));

                }
                return LIstaDasPoupancas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void AtualizarContaPoupanca(ContaPoupanca Poupanca)
        {

            if (LIstaDasPoupancas.Count == 0)
            {
                TxtParaPoupancas();
            }
            foreach (ContaPoupanca Conta in LIstaDasPoupancas)
            {
                if (Poupanca.Titular == Conta.Titular && Poupanca.Numero == Conta.Numero)
                {

                    LIstaDasPoupancas.Remove(Conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoPoupanca);
            LIstaDasPoupancas.Add(new ContaPoupanca(Poupanca.Titular, Poupanca.Numero, Poupanca.Saldo));
            file.Close();

            SalvarListaContaPoupancaNoTxt();
            Console.WriteLine($"\n TITULAR:{Poupanca.Titular} NUMERO: {Poupanca.Numero} SALDO: {Poupanca.Saldo.ToString("F2")}\n");
        }
        public void SalvarListaContaPoupancaNoTxt()
        {
            File.Delete(CaminhoPoupanca);

            using var file = File.AppendText(CaminhoPoupanca);

            foreach (ContaPoupanca Conta in LIstaDasPoupancas)
            {
                string titular = Conta.Titular;
                int numero = Conta.Numero;
                double saldo = Conta.Saldo;
                file.WriteLine($"{titular} | {numero} | {saldo.ToString("F2")}");
            }
            file.Close();
        }

        //Metodos de save e atualização da Conta corrente
        internal List<ContaCorrente> TxtParaCorrentes()
        {   //Nome | Numero | Saldo | Limite de emprestimo
            //john | 4578 | 100 | 500
            try
            {
                string[] LeTexto = File.ReadAllLines(CaminhoCorrente);
                foreach (string s in LeTexto)
                {
                    string[] ModeloInteiro = s.Split(" | ");

                    string titular = ModeloInteiro[0];
                    int numero = int.Parse(ModeloInteiro[1]);
                    double saldo = double.Parse(ModeloInteiro[2]);
                    double limite = double.Parse(ModeloInteiro[3]);
                    LIstaDasCorrentes.Add(new ContaCorrente(titular, numero, saldo, limite));

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
            foreach (ContaCorrente Conta in LIstaDasCorrentes)
            {
                if (corrente.Titular == Conta.Titular && corrente.Numero == Conta.Numero)
                {

                    LIstaDasCorrentes.Remove(Conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoCorrente);
            LIstaDasCorrentes.Add(new ContaCorrente(corrente.Titular, corrente.Numero, corrente.Saldo, corrente.LimiteEmprestimo));
            file.Close();

            SalvarListaContaCorrenteNoTxt();
            Console.WriteLine($"\n TITULAR:{corrente.Titular} NUMERO: {corrente.Numero} SALDO: {corrente.Saldo.ToString("F2")}\n");
        }
        public void SalvarListaContaCorrenteNoTxt()
        {
            File.Delete(CaminhoCorrente);

            using var file = File.AppendText(CaminhoCorrente);

            foreach (ContaCorrente Conta in LIstaDasCorrentes)
            {
                string titular = Conta.Titular;
                int numero = Conta.Numero;
                double saldo = Conta.Saldo;
                file.WriteLine($"{titular} | {numero} | {saldo.ToString("F2")} | {Conta.LimiteEmprestimo}");
            }
            file.Close();
        }
    }
}