using MySql.Data.MySqlClient;

namespace MarketplaceOnline.Models.Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        private string connectionString = "Server=127.0.0.1;Cache=Shared;Database=marketplacedb;User=root;Password=root";

        public void Adicionar(Categoria categoria)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO categoria (categoria_nome, descricao) VALUES (@CategoriaNome, @Descricao)";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@CategoriaNome", categoria.CategoriaNome);
            cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Atualizar(Categoria categoria)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE categoria SET categoria_nome = @CategoriaNome, descricao = @Descricao WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", categoria.Id);
            cmd.Parameters.AddWithValue("@CategoriaNome", categoria.CategoriaNome);
            cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Excluir(Categoria categoria)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM categoria WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", categoria.Id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Categoria ObterPorId(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT categoria_nome, descricao FROM categoria WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                Categoria categoria = new Categoria
                {
                    CategoriaNome = reader.GetString("categoria_nome"),
                    Descricao = reader.GetString("descricao")
                };
                return categoria;
            }

            conn.Close();
            return null;

        }

        public List<Categoria> ObterTodos()
        {
            List<Categoria> categorias = new List<Categoria>();

            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT categoria_nome, descricao FROM categoria";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Categoria categoria = new Categoria
                {
                    CategoriaNome = reader.GetString("categoria_nome"),
                    Descricao = reader.GetString("descricao")
                };
                categorias.Add(categoria);
            }

            conn.Close();
            return categorias;
        }
    }
}
