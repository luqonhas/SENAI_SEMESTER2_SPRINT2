using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    // NESTE ARQUIVO(FilmeRepository) terá que adicionar um pacote:
    // Projeto > Gerenciar Pacotes do NuGet... > Procurar(na aba) > SqlClient > Baixar o primeiro

    /// <summary>
    /// Classe responsável pelo repositório dos filmes
    /// </summary>
    public class FilmeRepository : IFilmesRepository // os dois pontos(:) é a HERANÇA, pois está herdando a Interface do Filme
    {
        // varíavel privada pra poder se conectar com o SQL Server
        // aqui são todos os parâmetros necessários para se conectar no SQL Server:
        // "data source" é o nome do Servidor do SQL;
        // "initial catalog" é o nome do banco de dados que quer se conectar, que no caso vai ser o Filmes;
        // "user id" é o id do usuário, que no caso é o "sa";
        // "integrated security = true" entraria no lugar do "user id = sa" quando é pra entrar com a autenticação do windows;
        // "pwd" é a senha do usuário, por exemplo, senai@132.
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
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns> Uma lista de filmes </returns>
        public List<FilmeDomain> ListarTodos()
        {
            // cria uma lista listaFilmes onde serão armazenados os dados
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            // declara a SqlConnection "connection" passando a string de conexão(stringConexao) como parâmetro
            // então o using vai rodar um comando no SQL, por exemplo uma tabela de filmes, qnd comunicarmos e trouxer oq queremos do SQL, será cortado a conexão
            using (SqlConnection connection = new SqlConnection(stringConexao)) // um determinado recurso, aqui será uma conexão || vai rodar um comando no SQL, qnd comunicarmos e trouxer oq quer, será cortado a conexão
            {
                // declara a instrução(query) a ser executada(ainda não é pra executar, apenas para armazenar o que será pra fazer)
                string querySelectAll = "SELECT idFilmes, idGenero, Titulo FROM Filmes";

                // abre a conexão com o banco de dados
                // invocação da função, seria como se estivesse clicando em "conectar" no SQL, mas ainda não executa nenhum comando
                connection.Open();

                // estou criando uma variavel(reader) do tipo SqlDataReader, ela consegue ler dados SQL
                SqlDataReader reader;

                // declara o SqlCommand "command", passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(querySelectAll, connection)) // vai ser criado um comando do SQL || pegamos todo o texto do SELECT e colocamos dentro do querySelectAll
                {
                    // executa a query e armazena os dados no "reader"
                    reader = command.ExecuteReader(); // agora sim está sendo executado a query

                    // enquanto houver registros para serem lidos no "reader", o laço se repete
                    while (reader.Read()) // a condição para o laço continuar executando é que continue tendo linhas, vai ficar lendo as linhas do SQL, assim que acabar as linhas, para de rodar
                    {
                        // instancia um objeto filme do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain()
                        {
                            // atribui à propriedade "idFilmes" o valor da primeira[0] coluna do banco de dados
                            idFilme = Convert.ToInt32(reader[0]), // vai ter o valor do id do filme

                            idGenero = Convert.ToInt32(reader[1]), // atribui à propriedade "idGenero" o valor da segunda[1] coluna do banco de dados

                            // atribui à propriedade "titulo" o valor da terceira[2] coluna do banco de dados
                            titulo = reader[2].ToString()  
                        };

                        // adiciona o objeto filme criado à lista listaFilmes
                        listaFilmes.Add(filme);
                    }

                    // retorna a lista de filmes
                    return listaFilmes;
                }
            }
        }
    }
}
