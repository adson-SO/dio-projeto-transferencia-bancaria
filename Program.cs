using System;
using System.Collections.Generic;

namespace Project.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        SacarConta();
                        break;
                    case "4":
                        DepositarConta();
                        break;
                    case "5":
                        TransferirConta();
                        break;
                    case "6":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write($"{i} - ");
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.Write("Digite 1 para conta de Pessoa Física ou 2 para Pessoa Jurídica: ");
            int entradaTipoConta = Int32.Parse(Console.ReadLine());
            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            Console.Write("Digite o saldo da conta: ");
            double saldoConta = Double.Parse(Console.ReadLine()); 
            Console.Write("Digite o crédito da conta: ");
            double creditoConta = Double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        nome: nomeCliente,
                                        saldo: saldoConta,
                                        credito: creditoConta);

            listContas.Add(novaConta);
        }

        private static void SacarConta()
        {
            Console.WriteLine("Realizar Saque");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void DepositarConta()
        {
            Console.WriteLine("Realizar Depósito");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void TransferirConta()
        {
            Console.WriteLine("Fazer Transferência");

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

            
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Menu de Opções");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir conta");
            Console.WriteLine("3- Realizar saque");
            Console.WriteLine("4- Realizar um depósito");
            Console.WriteLine("5- Fazer uma transferência");
            Console.WriteLine("6- Limpar a tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
