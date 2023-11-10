using MySql.Data.MySqlClient;

namespace MarketplaceOnline.Models.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private string connectionString = "Server=127.0.0.1;Cache=Shared;Database=marketplacedb;User=root;Password=root";
        public ProdutoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Adicionar(Produto produto)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO produto (descricao, preco, imagem, status) VALUES (@Descricao, @Preco, @Imagem, @Status)";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@Preco", produto.Preco);
            cmd.Parameters.AddWithValue("@Imagem", produto.Imagem);
            cmd.Parameters.AddWithValue("@Status", produto.Status);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Atualizar(Produto produto)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE produto SET descricao = @Descricao, preco = @Preco, imagem = @Imagem, status = @Status WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", produto.Id);
            cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
            cmd.Parameters.AddWithValue("@Preco", produto.Preco);
            cmd.Parameters.AddWithValue("@Imagem", produto.Imagem);
            cmd.Parameters.AddWithValue("@Status", produto.Status);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Excluir(Produto produto)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM produto WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(@query, conn);
            cmd.Parameters.AddWithValue("@Id", produto.Id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Produto ObterPorId(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT descricao, preco, imagem, status FROM produto WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Produto produto = new Produto
                {
                    Id = reader.GetInt32("id"),
                    Descricao = reader.GetString("descricao"),
                    Preco = reader.GetDouble("preco"),
                    Imagem = reader.GetString("imagem"),
                    Status = reader.GetBoolean("status")
                };
                return produto;
            }

            conn.Close();
            return null;
        }

        public List<Produto> ObterTodos()
        {
            List<Produto> produtos = new List<Produto>();

            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT descricao, preco, imagem, status FROM produto";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Produto produto = new Produto
                {
                    Descricao = reader.GetString("descricao"),
                    Preco = reader.GetDouble("preco"),
                    Imagem = reader.GetString("imagem"),
                    Status = reader.GetBoolean("status")
                };

                produtos.Add(produto);
            }

            conn.Close();
            return produtos;
        }
    }
}
