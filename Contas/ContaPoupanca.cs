

namespace Banco
{
   public sealed class ContaPoupanca : Conta
    {
        private double TaxaDeRentabilidade = 0.05;

        public ContaPoupanca() { }

        public ContaPoupanca(string titular, int numero) : base(titular, numero) { }
        public ContaPoupanca(string titular, int numero, double saldo) : base(titular, numero) { Saldo = saldo; }


<<<<<<< HEAD
        public double Render()
        {
            return Saldo * TaxaDeRentabilidade;
=======
        public double Rentabiliade()
        {
            return Saldo * taxaDeRentabilidade;
>>>>>>> 6f0f105bad7a033c7455109d8c5fa87650e2c6dd
        }

    }
}
