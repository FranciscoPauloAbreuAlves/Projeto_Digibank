using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public static int opcao = 0;

        public static void Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("SYSTEM PERSONAL FACILITY DIGIBANK                                     ");
            Console.WriteLine("======================================================================");
        }

        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Cabecalho();

            Console.WriteLine("Escolha sua opção abaixo!                                             ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                1 - Criar Conta | 2 Entrar com CPF e Senha            ");
            Console.WriteLine("----------------------------------------------------------------------");
           
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("                             Opção Inválida                           ");
                    Console.WriteLine("======================================================================");
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Cabecalho();
            Console.WriteLine("DIGIBANK | CRIAR SUA CONTA");
            Console.WriteLine("                                                                      ");

            Console.WriteLine("Digite seu nome:  ");
            string nome = Console.ReadLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Digite seu CPF:   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Escolha uma senha:");
            string senha = Console.ReadLine();
            Console.WriteLine("------------------");


            //Criar uma conta
            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();
            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);
            Console.Clear();
            Cabecalho();

            Console.WriteLine("                   Conta cadastrada com sucesso"                       );
            Console.WriteLine("======================================================================");

            //Irá esperar por 1 segundo
            Thread.Sleep(1000);
            TelaContaLogada(pessoa);
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            Cabecalho();

            string msgTelaBemVinda =
            $"{pessoa.Nome} | Banco: {pessoa.Conta.GetCodigoDoBanco()} " +
            $"| Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroDaConta()}";

            Console.WriteLine($"Seja bem vindo, {msgTelaBemVinda}");
            Console.WriteLine("");
        }

        private static void TelaLogin()
        {
            Cabecalho();
            Console.WriteLine("DIGIBANKC | LOGIN");
            Console.WriteLine("                                                                      ");

            Console.WriteLine("");
            Console.WriteLine("Digite seu CPF:   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            Console.WriteLine("------------------");


            //Logar no sistema
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("                      Pessao não cadastrada!                          ");
                Console.WriteLine("======================================================================");
            }
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Cabecalho(); TelaBoasVindas(pessoa);

            Console.WriteLine("O que deseja fazer?                                                   ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("    1 - Depósito | 2 - Saque | 3 - Saldo | 4 - Extrato | 5 - Sair     ");
            Console.WriteLine("----------------------------------------------------------------------");
            
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("                             Opção Inválida!                          ");
                    Console.WriteLine("======================================================================");
                    break;
            }
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("O que deseja fazer?                                                   ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("                     1 - Minha conta | 2 - Sair                       ");
            Console.WriteLine("----------------------------------------------------------------------");


            opcao = int.Parse(Console.ReadLine());
            //if (opcao == 1)
            //    TelaContaLogada(pessoa);
            //else
            //    TelaPrincipal();

            switch (opcao)
            {
                case 1:
                    TelaContaLogada(pessoa);
                    break;
                case 2:
                    TelaPrincipal();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("                            Opção Inválida!                           ");
                    Console.WriteLine("======================================================================");
                    break;
            }
        }

        private static void OpcaoVoltarDeslogado()
        {
            Cabecalho();

            Console.WriteLine("Escolha sua opção abaixo!                                             ");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("             1 - Voltar para menu principal | 2 - Sair                ");
            Console.WriteLine("----------------------------------------------------------------------");


            opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
                TelaPrincipal();
            else
            {
                Console.WriteLine("                            Opção Inválida!                           ");
                Console.WriteLine("======================================================================");
            }
        }

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            Cabecalho(); //TelaBoasVindas(pessoa);
            Console.WriteLine("DIGIBANK | SEU DEPÓSITO");
            Console.WriteLine("                                                                      ");

            Console.WriteLine("Digite o valor do depósito!                                           ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------------------");

            pessoa.Conta.Deposita(valor);
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                                      ");
            Console.WriteLine("                                                                      ");
            Console.WriteLine("                       Depósito realizado com sucesso!                ");
            Console.WriteLine("======================================================================");
            Console.WriteLine("                                                                      ");
            Console.WriteLine("                                                                      ");

            //Método para listar novos métodos
            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaque(Pessoa pessoa)
        {
            Cabecalho();//TelaBoasVindas(pessoa);
            Console.WriteLine("DIGIBANK | SEU SAQUE");
            Console.WriteLine("                                                                      ");

            Console.WriteLine("Digite o valor do saque!                                              ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("----------------------------------------------------------------------");

            bool okSaque = pessoa.Conta.Saca(valor);

            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("");
            Console.WriteLine("");

            if (okSaque)
            {
                Console.WriteLine("                       Saque realizado com sucesso!                   ");
                Console.WriteLine("======================================================================");
            }
            else
            {
                Console.WriteLine("                          Saldo insuficiente!                         ");
                Console.WriteLine("======================================================================");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            //Método para listar novos métodos
            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            Cabecalho(); //TelaBoasVindas(pessoa);
            Console.WriteLine("DIGIBANK | SEU SALDO");

            Console.WriteLine("                                                                      ");
            Console.WriteLine($"Seu SALDO é: R${pessoa.Conta.ConsultaSaldo()}                        ");
            Console.WriteLine("======================================================================");
            Console.WriteLine("                                                                      ");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Cabecalho(); //TelaBoasVindas(pessoa);
            Console.WriteLine("DIGIBANK | SEU EXTRATO");
            Console.WriteLine("                                                                      ");

            if (pessoa.Conta.Extrato().Any())
            {
                //Mostra extrato
                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);
                foreach(Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine($"Data: {extrato.Data.ToString("dd/mm/yyyy HH:mm:ss")}                 ");
                    Console.WriteLine($"Tipo de Movimentação: {extrato.Descricao}                            ");
                    Console.WriteLine($"Valor: R${extrato.Valor}                                             ");
                    Console.WriteLine("----------------------------------------------------------------------");
                }

                Console.WriteLine("                                                                      ");
                Console.WriteLine("                                                                      ");
                Console.WriteLine($"Sub TOTAL: R${total}                                                 ");
                Console.WriteLine("======================================================================");
                Console.WriteLine("                                                                      ");  
            }
            else
            {
                Console.WriteLine("                      Não há extrato a ser exibido!                   ");
                Console.WriteLine("======================================================================");
                Console.WriteLine("                                                                      ");
            }

            OpcaoVoltarLogado(pessoa);
        }

    }     
}
