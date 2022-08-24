

namespace Banco
{
<<<<<<< HEAD
    public sealed class ContaPoupanca : Conta
=======
   sealed class ContaPoupanca : Conta
>>>>>>> parent of adbc1bb (Metodos da classe OpcoesDeConta adaptados para o novo sistema de save. A classe SalvarELer sofreu grandes mudanças para pode efetuar de maneira mais rapida e pratica as ações de ler e salvar novas contas, modelo de save foi alterado de --DADOS DA CONTA: NOME DO TITULAR: [NOME] | NUMERO DE CONTA: [NUMERO] | SALDO DE CONTA: [SALDO]-- para --[NOME] | [NUMERO] | [SALDO]--  para almentar a efetividade do sistema de leitura.)
    {
        private double TaxaDeRentabilidade = 0.05;

        public ContaPoupanca(){}

        public ContaPoupanca(int numero, string titular) : base(numero, titular) { }
        public ContaPoupanca(int numero, string titular, double saldo) : base(numero, titular) { Saldo = saldo; }


        public double Render()
        {
            return Saldo * TaxaDeRentabilidade;
        }

    }
}
