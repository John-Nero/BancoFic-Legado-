using System.IO;

namespace Banco
{
     class SalvarELer
    {
        const string CaminhoPoupanca = @"C:\temp\BancoFic\DadosDosClientesPoupanca.txt";
        const string CaminhoCorrente = @"C:\temp\BancoFic\DadosDosClientesCorrente.txt";

        //Metodos de Save da conta poupanca
        public void RegistrarClientePoupanca(int numero, string titular, double saldo)
        {
            using var file = File.AppendText(CaminhoPoupanca);
            file.WriteLine($"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}");
            file.Close();
        }
        public void DeletarEAtualizarClientePoupanca(int numero, string titular, double saldo)
        {
            File.Delete(CaminhoPoupanca);
            using var file = File.AppendText(CaminhoPoupanca);
            file.WriteLine($"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}");
            file.Close();
        }

        //Metodos de Save da conta corrente
        public void RegistrarClienteCorrente(int numero, string titular, double saldo)
        {
            using var file = File.AppendText(CaminhoCorrente);
            file.WriteLine($"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}");
            file.Close();
        }
        public void DeletarEAtualizarClienteCorrente(int numero, string titular, double saldo)
        {
            File.Delete(CaminhoCorrente);
            using var file = File.AppendText(CaminhoCorrente);
            file.WriteLine($"DADOS DA CONTA | NUMERO: {numero} | TITULAR: {titular} | SALDO: {saldo}");
            file.Close();
        }
    }
}
