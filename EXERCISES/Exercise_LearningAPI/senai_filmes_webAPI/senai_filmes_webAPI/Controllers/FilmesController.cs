using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using senai_filmes_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints(pontos onde uma requisição é feita, que são chamados de uma determinada URL/recurso)
/// </summary>
namespace senai_filmes_webAPI.Controllers
{
    // define que o tipo de resposta da API seja no formato JSON
    [Produces("application/json")]

    // define que a rota de uma requisição(URL) vai ser neste formato = domínio/api/nomeController
    // exemplo: http://localhost:5000/api/filmes
    [Route("api/[controller]")]

    // define que pe um controlador de API
    [ApiController]

    // faço uma requisição pelo front-end, chega aqui e busca
    public class FilmesController : ControllerBase
    {
        /// <summary>
        /// Objeto _filmeRepository que irá receber todos os métodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmesRepository _filmeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _filmeRepository para que haja a referência aos métodos no repositório
        /// </summary>
        // método contrutor é uma função que vai ser executada toda vez que essa classe for chamada
        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns> Uma lista de filmes e um status code </returns>
        // se você quer listar algo, você usa um GET
        [HttpGet]
        // nosso endpoint em si
        public IActionResult Get() // quem fez a requisição
        {
            // cria uma lista nomeada "listaFilmes" para receber os dados
            // aqui está sendo listado todos os filmes e armazenando na lista
            // se eu quero enviar uma lista pra quem tá pedindo
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

            // retorna o status code 200(Ok) com a lista de filmes no formato JSON
            return Ok(listaFilmes);
        }
    }
}
