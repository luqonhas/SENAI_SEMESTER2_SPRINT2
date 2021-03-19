using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    // NESTE ARQUIVO(FilmeRepository) terá que adicionar um pacote:
    // Projeto > Gerenciar Pacotes do NuGet... > Procurar(na aba) > SqlClient > Baixar o primeiro

    /// <summary>
    /// Esta é a interface que é responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        /// TipoRetorno NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        /// Esta será a lista que mostra todos os filmes existentes
        /// </summary>
        /// <returns>Uma lista de gêneros</returns>
        List<GeneroDomain> ListarTodos(); // aqui será tipo SELECT * generos

        /// <summary>
        /// Será buscado um gênero pelo seu id
        /// </summary>
        /// <param name="id">é o id que será buscado</param>
        /// <returns>Um objeto gênero que foi buscado</returns>
        GeneroDomain BuscarPorId(int id); // aqui será tipo usar o WHERE idGenero = 1

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto novoGenero com as informações que serão cadastradas</param>
        void Cadastrar(GeneroDomain novoGenero); // aqui seria tipo usar o INSERT INTO

        /// <summary>
        /// Atualiza um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um gênero existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="genero"></param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        void Deletar(int id); // aqui seria tipo o DELETE com o WHERE = id
    }
}