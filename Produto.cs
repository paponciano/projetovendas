using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProjetoVendas
{
    class Produto
    {
        public int CodProduto { get; set; }

        public string Nome { get; set; }

        public decimal Estoque { get; set; }

        public decimal Valor { get; set; }

        public bool CadastrarProduto()
        {
            bool inseriuProduto = false;
            MySqlConnection conn = new("server=127.0.0.1;user=root;password=root;database=bd_vendas");
            try
            {
                conn.Open();
                MySqlCommand cmd = new();
                cmd.Connection = conn;
                cmd.CommandText = "insert into produtos (Nome, Estoque, Valor) values (@nome, @estoque, @valor)";
                cmd.Parameters.AddWithValue("@nome", this.Nome);
                cmd.Parameters.AddWithValue("@estoque", this.Estoque);
                cmd.Parameters.AddWithValue("@valor", this.Valor);
                cmd.ExecuteNonQuery();
                inseriuProduto = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return inseriuProduto;
        }

        public List<Produto> SelecionarProdutos()
        {
            return this.SelecionarProdutos(null);
        }
        
        public List<Produto> SelecionarProdutos(int? codProduto)
        {
            List<Produto> listaProdutos = new();

            return listaProdutos;
        }
    }
}