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
                        
                        var listaProdutos = new Produto().SelecionarProdutos();
                        foreach(var item in listaProdutos)
                            Console.WriteLine($"CodProduto: {item.CodProduto}, Nome: {item.Nome}, Estoque: {item.Estoque}, Valor: {item.Valor}");

                        opcao = 0;
                        break;
                    case 3:
                        Console.WriteLine("Opção escolhida: 3");

                        Console.WriteLine("Digite o ID do produto que deseja visualizar: ");
                        int codProduto = Convert.ToInt32(Console.ReadLine());
                        var listaProduto = new Produto().SelecionarProdutos(codProduto);
                        foreach(var item in listaProduto)
                            Console.WriteLine($"CodProduto: {item.CodProduto}, Nome: {item.Nome}, Estoque: {item.Estoque}, Valor: {item.Valor}");

                        if (listaProduto.Count == 0)
                            Console.WriteLine("Não houve produto selecionado");

                        opcao = 0;
                        break;
                    case 4:
                        Console.WriteLine("Opção escolhida: 4");

                        Venda novaVenda = new();
                        Console.WriteLine("Digite o nome do cliente: ");
                        novaVenda.NomeCliente = Console.ReadLine();
                        Console.WriteLine("Digite o ID do produto que se deseja comprar: ");
                        novaVenda.IdProduto = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite a quantidade do produto que deseja comprar: ");
                        novaVenda.Quantidade = Convert.ToDecimal(Console.ReadLine());

                        string mensagemValidacao = "";
                        bool registrouVenda = novaVenda.RegistrarVenda(out mensagemValidacao);
                        if (registrouVenda)
                            Console.WriteLine("Venda registrada com sucesso!");
                        else
                            Console.WriteLine(mensagemValidacao);

                        opcao = 0;
                        break;
                }
            }
        }
    }
}