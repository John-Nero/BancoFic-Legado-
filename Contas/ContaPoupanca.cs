

namespace Banco
{
    sealed class ContaPoupanca : Conta
    {
        private double taxaDeRentabilidade = 0.05; // Iniciar ocm letra maiuscula

        public ContaPoupanca() { }

        public ContaPoupanca(string titular, int numero) : base(titular, numero) { }
        public ContaPoupanca(string titular, int numero, double saldo) : base(titular, numero) { Saldo = saldo; }


        public double Rentabiliade()
        {
            return Saldo * taxaDeRentabilidade;
        }

    }
}
