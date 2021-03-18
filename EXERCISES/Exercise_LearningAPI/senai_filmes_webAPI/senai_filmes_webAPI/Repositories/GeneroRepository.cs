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
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository // os dois pontos(:) é a HERANÇA, pois está herdando a Interface do Genero
    {
        // varíavel privada pra poder se conectar com o SQL Server
        // aqui são todos os parâmetros necessários para se conectar no SQL Server:
        // "data source" é o nome do Servidor do SQL;
        // "initial catalog" é o nome do banco de dados que quer se conectar, que no caso vai ser o Filmes;
        // "user id" é o id do usuário, que no caso é o "sa";
        // "integrated security = true" entraria no lugar do "user id = sa" quando é pra entrar com a autenticação do windows;
        // "pwd" é a senha do usuário, por exemplo, senai@132.
        private string stringConexao = "Data Source=DESKTOP-HMTUR0P; initial catalog=Filmes; user Id=SA; pwd=Soufoda2";

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Uma lista de gêneros </returns>
        public List<GeneroDomain> ListarTodos()
        {
            // cria uma lista listaGeneros onde serão armazenados os dados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // declara a SqlConnection "connection" passando a string de conexão(stringConexao) como parâmetro
            // então o using vai rodar um comando no SQL, por exemplo uma tabela de generos, qnd comunicarmos e trouxer oq queremos do SQL, será cortado a conexão
            using (SqlConnection connection = new SqlConnection(stringConexao)) // um determinado recurso, aqui será uma conexão || vai rodar um comando no SQL, qnd comunicarmos e trouxer oq quer, será cortado a conexão
            {
                // declara a instrução(query) a ser executada(ainda não é pra executar, apenas para armazenar o que será pra fazer)
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

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
                        // instancia um objeto genero do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // atribui à propriedade "idGenero" o valor da primeira[0] coluna do banco de dados
                            idGenero = Convert.ToInt32(reader[0]), // vai ter o valor do id do genero

                            // atribui à propriedade "nome" o valor da segunda[1] coluna do banco de dados
                            nome = reader[1].ToString()
                        };

                        // adiciona o objeto genero criado à lista listaGeneros
                        listaGeneros.Add(genero);
                    }

                    // retorna a lista de gêneros
                    return listaGeneros;
                }
            }
        }
    }
}
