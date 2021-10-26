using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProjetoVendas
{
    class Venda
    {
        public int Id { get; set; }

        public int IdProduto { get; set; }

        public string NomeCliente { get; set; }

        public decimal Quantidade { get; set; }

        public DateTime DataVenda { get; set; }

        public bool RegistrarVenda(out string mensagemValidacao)
        {
            bool registrouVenda = false;
            mensagemValidacao = "";

            MySqlConnection conn = new("server=127.0.0.1;user=root;password=root;database=bd_vendas");
            try
            {
                conn.Open();

                MySqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = "select Estoque from produtos where CodProduto = @codigoproduto";
                cmd.Parameters.AddWithValue("@codigoproduto", this.IdProduto);
                decimal estoque = Convert.ToDecimal(cmd.ExecuteScalar());

                if (estoque < this.Quantidade)
                    mensagemValidacao = "Estoque não é suficiente. Venda não efetivada";
                else
                {
                    cmd.CommandText = "insert into vendas (id_produto, nome_cliente, quantidade, data_venda) values (@codigoproduto, @nomecliente, @quantidade, now())";
                    cmd.Parameters.AddWithValue("@nomecliente", this.NomeCliente);
                    cmd.Parameters.AddWithValue("@quantidade", this.Quantidade);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update produtos set estoque = @novoestoque where CodProduto = @codigoproduto";
                    cmd.Parameters.AddWithValue("@novoestoque", estoque - this.Quantidade);
                    cmd.ExecuteNonQuery();

                    registrouVenda = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return registrouVenda;
        }
    }
}