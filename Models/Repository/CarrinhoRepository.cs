using MySql.Data.MySqlClient;

namespace MarketplaceOnline.Models.Repository
{
    public class CarrinhoRepository : IRepository<Carrinho>
    {
        private string connectionString = "Server=127.0.0.1;Cache=Shared;Database=marketplacedb;User=root;Password=root";

        public CarrinhoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Adicionar(Carrinho carrinho)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO carrinho (data_pedido, valor_total) VALUES (@DataPedido, @ValorTotal)";
            
            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DataPedido", carrinho.DataPedido);
            cmd.Parameters.AddWithValue("@ValorTotal", carrinho.ValorTotal);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Atualizar(Carrinho carrinho)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE carrinho SET data_pedido = @DataPedido, valor_total = @ValorTotal WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", carrinho.Id);
            cmd.Parameters.AddWithValue("@DataPedido", carrinho.DataPedido);
            cmd.Parameters.AddWithValue("@ValorTotal", carrinho.ValorTotal);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Excluir(Carrinho carrinho)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM carrinho WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", carrinho.Id);

            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public Carrinho ObterPorId(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM carrinho WHERE Id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Carrinho carrinho = new Carrinho
                {
                    DataPedido = reader.GetDateTime("data_pedido"),
                    ValorTotal = reader.GetDouble("valor_total"),
                    Cliente = new Cliente
                    {
                        Nome = reader.GetString("nome"),
                        Email = reader.GetString("email"),
                        Cpf = reader.GetInt32("cpf"),
                        Endereco = new Endereco
                        {
                            NomeRua = reader.GetString("nome_rua"),
                            NumeroCasa = reader.GetString("numero_casa"),
                            NomeBairro = reader.GetString("nome_bairro"),
                            NomeCidade = reader.GetString("nome_cidade"),
                            NomeEstado = reader.GetString("nome_estado"),
                            NomePais = reader.GetString("nome_pais")
                        }
                    }
                };

                return carrinho;
            }
            conn.Close();
            return null;
        }

        public List<Carrinho> ObterTodos()
        {
            List<Carrinho> carrinhos = new List<Carrinho>();

            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM carrinho WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Carrinho carrinho = new Carrinho
                {
                    DataPedido = reader.GetDateTime("data_pedido"),
                    ValorTotal = reader.GetDouble("valor_total"),
                    Cliente = new Cliente
                    {
                        Nome = reader.GetString("nome"),
                        Email = reader.GetString("email"),
                        Cpf = reader.GetInt32("cpf"),
                        Endereco = new Endereco
                        {
                            NomeRua = reader.GetString("nome_rua"),
                            NumeroCasa = reader.GetString("numero_casa"),
                            NomeBairro = reader.GetString("nome_bairro"),
                            NomeCidade = reader.GetString("nome_cidade"),
                            NomeEstado = reader.GetString("nome_estado"),
                            NomePais = reader.GetString("nome_pais")
                        }
                    }
                };

                carrinhos.Add(carrinho);
            }

            conn.Close();
            return carrinhos;
        }
    }
}
