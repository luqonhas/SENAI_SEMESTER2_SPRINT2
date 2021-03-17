using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Esta é a interface que é responsável pelo repositório FilmeRepository
    /// </summary>
    interface IFilmesRepository
    {
        /// TipoRetorno NomeMetodo(TipoParametro NomeParametro)

        /// <summary>
        /// Esta será a lista que mostra todos os filmes existentes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        List<FilmeDomain> ListarTodos(); // aqui será tipo SELECT * filmes

        /// <summary>
        /// Será buscado um filme pelo seu id
        /// </summary>
        /// <param name="id">é o id que será buscado</param>
        /// <returns>Um objeto filme que foi buscado</returns>
        FilmeDomain BuscarPorId(int id); // aqui será tipo usar o WHERE idFilme = 1

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com as informações que serão cadastradas</param>
        void Cadastrar(FilmeDomain novoFilme); // aqui seria tipo usar o INSERT INTO

        /// <summary>
        /// Atualiza um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme existente passando o id pela url da requisição
        /// </summary>
        /// <param name="id">id do filme que será atualizado</param>
        /// <param name="filme"></param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        void Deletar(int id); // aqui seria tipo o DELETE com o WHERE = id
    }
}
