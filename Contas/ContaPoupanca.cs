

namespace Banco
{
    public sealed class ContaPoupanca : Conta
    {
        private double TaxaDeRentabilidade = 0.05;

        public ContaPoupanca() { }


        public ContaPoupanca(string titular, int numero, double saldo) : base(titular, numero) { Saldo = saldo; }

        public double Render()
        {
            return Saldo * TaxaDeRentabilidade;
        }
    }
}
