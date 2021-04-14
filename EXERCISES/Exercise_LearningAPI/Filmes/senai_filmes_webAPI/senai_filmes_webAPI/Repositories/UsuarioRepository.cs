using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório de usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=Filmes; user Id=SA; pwd=Soufoda2";


        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // define a conexão "connection", passando a string de conexão
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // define a query a ser executada no banco de dados
                string querySelect = "SELECT idUsuario, email, senha, permissao FROM Usuarios WHERE email = @email AND senha = @senha";

                using (SqlCommand command = new SqlCommand(querySelect, connection))
                {
                    // define os valores dos parametros
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha);

                    // abre a conexão com o banco de dados
                    connection.Open();

                    // executa o comando e armazena os dados no objeto "reader"
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain()
                        {
                            // atribui as propriedades os valores das colunas
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),
                            email = reader["email"].ToString(),
                            senha = reader["senha"].ToString(),
                            permissao = reader["permissao"].ToString()
                        };

                        // retorna o objeto usuarioBuscado
                        return usuarioBuscado;
                    }

                    // caso não encontre o email ou a senha correspondentes, retorna null
                    return null;
                }
            }
        }
    }
}
