using System;

//ATENÇÃO PARA VISUALIZAÇÃO DO DIAGRAMA UTILIZAR O SITE:
//https://app.diagrams.net/


namespace Banco
{
    class Program
    {

        static void Main(string[] args)
        {

            OpcoesDeConta opcoes = new OpcoesDeConta();
            SalvarELer salvar = new SalvarELer();
            ContaPoupanca conta = new ContaPoupanca();
            salvar.AtualizarContaPoupanca(conta);
            Console.WriteLine("Selecione a ação que deseja executar:");
            Console.WriteLine(" 1 - Consultar conta poupança(Já existente) \n 2 - Criar conta poupanca \n 3 - Consultar conta corrente (já existente) \n 4 - Criar conta corrente \n 5 - Encerrar");
            int sel = int.Parse(Console.ReadLine());
            bool loop = true;
            while (loop)
            {
                switch (sel)
                {
                    case 1:
                    Console.Clear();
                    Console.WriteLine("CONSULTAR CONTA POUPANÇA SELECIONADA");
                    opcoes.ConsultarContaPoupanca();
                    acaoPoupanca(opcoes);

                    break;

                    case 2:
                    Console.Clear();
                    Console.WriteLine("CRIAR CONTA POUPANCA SELECIONADA");
                    opcoes.CriarContaPoupanca();
                    acaoPoupanca(opcoes);
                    break;

                    case 3:
                    Console.Clear();
                    Console.WriteLine("CONSULTAR CONTA CORRENTE SELECIONADA");
                    opcoes.ConsultarContaCorrente();
                    acaoCorrente(opcoes);
                    break;

                    case 4:
                    Console.Clear();
                    Console.WriteLine("CRIAR CONTA POUPANCA SELECIONADA");
                    opcoes.CriarContaCorrente();
                    acaoCorrente(opcoes);
                    break;

                    case 5:
                    Console.WriteLine("Agradecemos a preferência");
                    loop = false;
                    break;

                    default:
                    Console.WriteLine("OPÇÃO INVALIDA");
                    Console.ReadLine();
                    Console.Clear();
                    Main(args);
                    break;
                }
            }
        }

        static void acaoPoupanca(OpcoesDeConta opcoes)
        {
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine(" Digite a operação que deseja fazer\n");
                    Console.WriteLine(" 1 - Deposito \n 2 - Saque \n 3 - Ver saldo \n 4 - Render \n 5 - Encerrar");
                    Console.Write("\n Opção: ");
                    int op = int.Parse(Console.ReadLine());
                    Console.Clear();

                    switch (op)
                    {
                        case 1:
                        opcoes.DepositoPoupanca();
                        break;

                        case 2:
                        opcoes.SaquePoupanca();
                        break;

                        case 3:
                        opcoes.MostrarDadosPoupanca();
                        break;

                        case 4:
                        opcoes.Render();
                        break;

                        case 5:
                        Console.WriteLine(" Obrigado pela preferencia.");
                        Environment.Exit(op);
                        break;

                        default:
                        Console.WriteLine(" OPÇÃO INVALIDA.");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("DIGITE APENAS NUMEROS");
                }
            }
        }

        static void acaoCorrente(OpcoesDeConta opcoes)
        {
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine(" Digite a operação que deseja fazer\n");
                    Console.WriteLine(" 1 - Deposito \n 2 - Saque \n 3 - Ver saldo \n 4 - emprestimo \n 5 - Encerrar");
                    Console.Write("\n Opção: ");
                    int op = int.Parse(Console.ReadLine());

                    switch (op)
                    {

                        case 1:
                        opcoes.DepositoCorrente();
                        break;

                        case 2:
                        opcoes.SaqueCorrente();
                        break;

                        case 3:
                        opcoes.MostrarDadosCorrente();
                        break;

                        case 4:
                        opcoes.Emprestimo();
                        break;

                        case 5:
                        Console.WriteLine(" Obrigado pela preferencia.");
                        Environment.Exit(op);
                        break;

                        default:
                        Console.WriteLine(" OPÇÃO INVALIDA.");
                        Console.WriteLine(" Tecle Enter para continuar.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("DIGITE APENAS NUMEROS");
                }
            }
        }
    }
}
