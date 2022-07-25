

namespace Banco
{
   sealed class ContaPoupanca : Conta
    {
        private double taxaDeRentabilidade = 0.05;

        public ContaPoupanca(){}

        public ContaPoupanca(int numero, string titular) : base(numero, titular) { }
        
        public void Rentabiliade()
        {

            Saldo = Saldo + Saldo * taxaDeRentabilidade;
        }

    }
}
