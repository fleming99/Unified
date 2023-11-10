using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;

namespace MarketplaceOnline.Models.Repository
{
    public class EnderecoRepository : IRepository<Endereco>
    {
        private string connectionString = "Server=127.0.0.1;Cache=Shared;Database=marketplacedb;User=root;Password=root";

        public void Adicionar(Endereco endereco)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO endereco (nome_rua, numero_casa, nome_bairro, nome_cidade, nome_estado, nome_pais) VALUES (@NomeRua, @NumeroCasa, @NomeBairro, @NomeCidade, @NomeEstado, @NomePais)";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@NomeRua", endereco.NomeRua);
            cmd.Parameters.AddWithValue("@NumeroCasa", endereco.NumeroCasa);
            cmd.Parameters.AddWithValue("@NomeBairro", endereco.NomeBairro);
            cmd.Parameters.AddWithValue("@NomeCidade", endereco.NomeCidade);
            cmd.Parameters.AddWithValue("@NomeEstado", endereco.NomeEstado);
            cmd.Parameters.AddWithValue("@NomePais", endereco.NomePais);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Atualizar(Endereco endereco)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE endereco SET nome_rua = @NomeRua, numero_casa = @NumeroCasa, nome_bairro = @NomeBairro, nome_cidade = @NomeCidade, nome_estado = @NomeEstado, nome_pais = @NomePais WHERE id = @Id";
            
            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", endereco.Id);
            cmd.Parameters.AddWithValue("@NomeRua", endereco.NomeRua);
            cmd.Parameters.AddWithValue("@NumeroCasa", endereco.NumeroCasa);
            cmd.Parameters.AddWithValue("@NomeBairro", endereco.NomeBairro);
            cmd.Parameters.AddWithValue("@NomeCidade", endereco.NomeCidade);
            cmd.Parameters.AddWithValue("@NomeEstado", endereco.NomeEstado);
            cmd.Parameters.AddWithValue("@NomePais", endereco.NomePais);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void Excluir(Endereco endereco)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "DELETE FROM endereco WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", endereco.Id);

            cmd.ExecuteNonQuery ();

            conn.Close();
        }

        public Endereco ObterPorId(int id)
        {
            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT nome_rua, numero_casa, nome_bairro, nome_cidade, nome_estado, nome_pais FROM endereco WHERE id = @Id";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@Id", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Endereco endereco = new Endereco
                {
                    Id = reader.GetInt32("id"),
                    NomeRua = reader.GetString("nome_rua"),
                    NumeroCasa = reader.GetString("numero_casa"),
                    NomeBairro = reader.GetString("nome_bairro"),
                    NomeCidade = reader.GetString("nome_cidade"),
                    NomeEstado = reader.GetString("nome_estado"),
                    NomePais = reader.GetString("nome_pais")
                };

                return endereco;
            }

            conn.Close();
            return null;
        }

        public List<Endereco> ObterTodos()
        {
            List<Endereco> enderecos = new List<Endereco>();

            using MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT nome_rua, numero_casa, nome_bairro, nome_cidade, nome_estado, nome_pais FROM endereco";

            using MySqlCommand cmd = new MySqlCommand(query, conn);

            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Endereco endereco = new Endereco
                {
                    Id = reader.GetInt32("id"),
                    NomeRua = reader.GetString("nome_rua"),
                    NumeroCasa = reader.GetString("numero_casa"),
                    NomeBairro = reader.GetString("nome_bairro"),
                    NomeCidade = reader.GetString("nome_cidade"),
                    NomeEstado = reader.GetString("nome_estado"),
                    NomePais = reader.GetString("nome_pais")
                };

                enderecos.Add(endereco);
            }

            conn.Close();
            return enderecos;
        }
    }
}
