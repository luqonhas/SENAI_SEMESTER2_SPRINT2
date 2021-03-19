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
    // exemplo: http://localhost:5000/api/generos
    [Route("api/[controller]")]

    // define que pe um controlador de API
    [ApiController]

    // faço uma requisição pelo front-end, chega aqui e busca
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        // método contrutor é uma função que vai ser executada toda vez que essa classe for chamada
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns> Uma lista de gêneros e um status code </returns>
        // se você quer listar algo, você usa um GET
        [HttpGet]
        // nosso endpoint em si
        public IActionResult Get() // quem fez a requisição
        {
            // cria uma lista nomeada "listaGeneros" para receber os dados
            // aqui está sendo listado todos os generos e armazenando na lista
            // se eu quero enviar uma lista pra quem tá pedindo
            List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

            // retorna o status code 200(Ok) com a lista de gêneros no formato JSON
            return Ok(listaGeneros);
        }

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <returns> Um status code 201 - Created </returns>
        /// exemplo: http://localhost:5000/api/generos
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            // faz a chamada para o método Cadastrar
            _generoRepository.Cadastrar(novoGenero);

            // retorna o status code 201 - Created
            return StatusCode(201);
        }
    }
}
