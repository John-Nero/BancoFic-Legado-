using System;
using System.Collections.Generic;
using System.IO;

namespace Banco
{
<<<<<<< HEAD

    public class SalvarELer
    {
        //Caminhos Para Local De Busca
        internal const string CaminhoPoupanca = @"C:\temp\projeto\DadosClientes\DadosDosClientesPoupanca.txt";
        internal const string CaminhoCorrente = @"C:\temp\projeto\DadosClientes\DadosDosClientesCorrente.txt";

        //Metodos de Save e atualização da conta poupanca
        public List<ContaPoupanca> LIstaDasPoupancas = new List<ContaPoupanca>();

        internal List<ContaPoupanca> TxtParaPoupancas()
=======
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
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
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

<<<<<<< HEAD
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
                if (poupanca.getTitular() == conta.getTitular() && poupanca.getNumero() == conta.getNumero())
                {

                    LIstaDasPoupancas.Remove(conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoPoupanca);
            LIstaDasPoupancas.Add(new ContaPoupanca(poupanca.getTitular(), poupanca.getNumero(), poupanca.getSaldo()));
            file.Close();

            SalvarListaContaPoupancaNoTxt();
            Console.WriteLine($"\n TITULAR:{poupanca.getTitular()} NUMERO: {poupanca.getNumero()} SALDO: {poupanca.getSaldo().ToString("F2")}\n");
        }
        public void SalvarListaContaPoupancaNoTxt()
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
                if (corrente.getTitular() == conta.getTitular() && corrente.getNumero() == conta.getNumero())
                {

                    LIstaDasCorrentes.Remove(conta);
                    break;
                }
            }

            using var file = File.AppendText(CaminhoCorrente);
            LIstaDasCorrentes.Add(new ContaCorrente(corrente.getTitular(), corrente.getNumero(), corrente.getSaldo()));
            file.Close();

            SalvarListaContaCorrenteNoTxt();
            Console.WriteLine($"\n TITULAR:{corrente.getTitular()} NUMERO: {corrente.getNumero()} SALDO: {corrente.getSaldo().ToString("F2")}\n");
        }
        public void SalvarListaContaCorrenteNoTxt()
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

=======
                    
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






>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
    }
}



