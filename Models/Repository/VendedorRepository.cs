using MySql.Data.MySqlClient;

namespace MarketplaceOnline.Models.Repository
{
    public class VendedorRepository : IRepository<Vendedor>
    {
        private string connectionString = "Server=127.0.0.1;Cache=Shared;Database=marketplacedb;User=root;Password=root";
        public VendedorRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Adicionar(Vendedor vendedor)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO vendedor (razao_social, nome_fantasia, email, senha, cnpj, comissao) VALUES (@RazaoSocial, @NomeFantasia, @Email, @Senha, @Cnpj, @Comissao)";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@RazaoSocial", vendedor.RazaoSocial);
            cmd.Parameters.AddWithValue("@NomeFantasia", vendedor.NomeFantasia);
            cmd.Parameters.AddWithValue("@Email", vendedor.Email);
            cmd.Parameters.AddWithValue("@Senha", vendedor.Senha);
            cmd.Parameters.AddWithValue("@Cnpj", vendedor.Cnpj);
            cmd.Parameters.AddWithValue("@Comissao", vendedor.Comissao);

            cmd.ExecuteNonQuery();
            
            conn.Close();
        }

        public void Atualizar(Vendedor vendedor)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE vendedor SET razao_social = @RazaoSocial, nome_fantasia = @NomeFantasia, email = @Email, senha = @Senha, cnpj = @Cnpj, comissao = @Comissao WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", vendedor.Id);
            cmd.Parameters.AddWithValue("@RazaoSocial", vendedor.RazaoSocial);
            cmd.Parameters.AddWithValue("@NomeFantasia", vendedor.NomeFantasia);
            cmd.Parameters.AddWithValue("@Email", vendedor.Email);
            cmd.Parameters.AddWithValue("@Senha", vendedor.Senha);
            cmd.Parameters.AddWithValue("@Cnpj", vendedor.Cnpj);
            cmd.Parameters.AddWithValue("@Comissao", vendedor.Comissao);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Excluir(Vendedor vendedor)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM vendedor WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", vendedor.Id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public Vendedor ObterPorId(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT razao_social, nome_fantasia, email, cnpj, comissao FROM cliente WHERE id = @Id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                Vendedor vendedor = new Vendedor
                {
                    Id = reader.GetInt32("id"),
                    RazaoSocial = reader.GetString("razao_social"),
                    NomeFantasia = reader.GetString("nome_fantasia"),
                    Email = reader.GetString("email"),
                    Cnpj = reader.GetString("cnpj"),
                    Comissao = reader.GetInt32("comissao")
                };
                return vendedor;
            }

            conn.Close();
            return null;
        }

        public List<Vendedor> ObterTodos()
        {
            List<Vendedor> vendedores = new List<Vendedor>();

            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT id, razao_social, nome_fantasia, email, cnpj, comissao FROM vendedor";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Vendedor vendedor = new Vendedor
                {
                    Id = reader.GetInt32("id"),
                    RazaoSocial = reader.GetString("razao_social"),
                    NomeFantasia = reader.GetString("nome_fantasia"),
                    Email = reader.GetString("email"),
                    Cnpj = reader.GetString("cnpj"),
                    Comissao = reader.GetInt32("comissao")
                };

                vendedores.Add(vendedor);
            }

            conn.Close();
            return vendedores;
        }
    }
}
