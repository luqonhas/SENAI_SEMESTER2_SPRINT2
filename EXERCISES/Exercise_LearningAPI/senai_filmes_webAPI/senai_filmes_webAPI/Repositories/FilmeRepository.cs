using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=Filmes; user Id=SA; pwd=Soufoda2";

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Filmes(idGenero, Titulo) VALUES ('"+novoFilme.idGenero+"', '"+novoFilme.titulo+"')";

                using (SqlCommand command = new SqlCommand(queryInsert, connection))
                {
                    // abre a conexão com o banco de dados
                    connection.Open();

                    // executa a query
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um filmes pelo seu id
        /// </summary>
        /// <param name="id"> Id do filme será apagado </param>
        public void Deletar(int id)
        {
            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // declara a query que será executada tendo o atributo "id" que terá o valor do idFilme que será apagado
                string queryDelete = "DELETE Filmes WHERE Filmes.idFilmes = "+id;

                using (SqlCommand command = new SqlCommand(queryDelete, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                // esta query "queryInnerJoin" está selecionando os filmes que tem relação com os gêneros na tabela
                string queryInnerJoin = "SELECT Filmes.idFilmes, Filmes.Titulo, Generos.idGenero, Generos.Nome FROM Filmes INNER JOIN Generos ON Filmes.idGenero = Generos.idGenero";

                // esta query "querySelectAll" está selecionando TODOS os filmes que existem na tabela
                /// string querySelectAll = "SELECT idFilmes, idGenero, Titulo FROM Filmes";

                connection.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(queryInnerJoin, connection))
                {
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            idFilme = Convert.ToInt32(reader[0]),
                            titulo = reader[1].ToString(),
                            idGenero = Convert.ToInt32(reader[2]),

                            // instancia um objeto genero do tipo GeneroDomain dentro de Filmes
                            genero = new GeneroDomain()
                            {
                                idGenero = Convert.ToInt32(reader[2]), // vai linkar com o gênero que está na tabela de Filmes(vai referenciar a FK)
                                nome = reader[3].ToString()
                            }
                        };

                        listaFilmes.Add(filme);
                    }

                    return listaFilmes;
                }
            }
        }
    }
}
