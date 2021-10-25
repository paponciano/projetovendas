using System;

namespace ProjetoVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            while (opcao >= 0 && opcao <= 4)
            {
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("1: Cadastrar Produto\n" + 
                        "2: Listar Produtos\n" + 
                        "3: Listar Produto de acordo com o ID\n" +
                        "4: Registrar Venda\n" + 
                        "5: Sair");

                        bool digitacaoValida = false;
                        while(!digitacaoValida)
                        {
                            try
                            {
                                opcao = Convert.ToInt32(Console.ReadLine());
                                digitacaoValida = true;
                            }
                            catch
                            {
                                Console.WriteLine("opção inválida...");
                            }                                
                        }
                        break;
                    case 1:
                        Console.WriteLine("Opção escolhida: 1");
                        Produto novoProduto = new();
                        Console.WriteLine("Digite o nome do novo produto: ");
                        novoProduto.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o estoque do novo produto: ");
                        novoProduto.Estoque = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Digite o valor do novo produto: ");
                        novoProduto.Valor = Convert.ToDecimal(Console.ReadLine());
                        bool inseriuProduto = novoProduto.CadastrarProduto();
                        if (inseriuProduto)
                            Console.WriteLine("Produto inserido com sucesso");
                        else
                            Console.WriteLine("Produto não inserido");
                        opcao = 0;
                        break;
                    case 2:
                        Console.WriteLine("Opção escolhida: 2");
                        opcao = 0;
                        break;
                    case 3:
                        Console.WriteLine("Opção escolhida: 3");
                        opcao = 0;
                        break;
                    case 4:
                        Console.WriteLine("Opção escolhida: 4");
                        opcao = 0;
                        break;
                }
            }
        }
    }
}