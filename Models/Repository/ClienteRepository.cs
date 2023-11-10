using MySql.Data.MySqlClient;

namespace MarketplaceOnline.Models.Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private string connectionString = "Server=127.0.0.1;Cache=Shared;Database=marketplacedb;User=root;Password=root";

        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Adicionar(Cliente cliente)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO cliente (nome, cpf, email, senha) VALUES (@Nome, @Cpf, @Email, @Senha)";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Senha", cliente.Senha);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Atualizar(Cliente cliente)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE cliente SET nome = @Nome, cpf = @Cpf, email = @Email, senha = @Senha WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Senha", cliente.Senha);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Excluir(Cliente cliente)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM cliente WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", cliente.Id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Cliente ObterPorId(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT id, nome, email, cpf FROM cliente WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Cliente cliente = new Cliente
                {
                    Id = reader.GetInt32("id"),
                    Nome = reader.GetString("nome"),
                    Email = reader.GetString("email"),
                    Cpf = reader.GetInt32("cpf")
                };
                return cliente;
            }

            conn.Close();
            return null;
        }

        public List<Cliente> ObterTodos()
        {
            List<Cliente> clientes = new List<Cliente>();

            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT id, nome, email, cpf FROM cliente";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Cliente cliente = new Cliente
                {
                    Id = reader.GetInt32("id"),
                    Nome = reader.GetString("nome"),
                    Email = reader.GetString("email"),
                    Cpf = reader.GetInt32("cpf")
                };
                clientes.Add(cliente);
            }

            conn.Close();
            return clientes;
        }
    }
}
