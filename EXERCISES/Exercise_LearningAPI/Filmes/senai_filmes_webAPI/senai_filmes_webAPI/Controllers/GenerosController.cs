using Microsoft.AspNetCore.Authorization;
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
        /// se você quer listar algo, você usa um GET
        [Authorize] // verifica se o usuário está logado, se não estiver logado, vai ser barrado (o Authorize é uma condição)
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
        /// Busca atráves do seu id
        /// </summary>
        /// <param name="id"> id do gênero que será buscado </param>
        /// <returns> Um gênero buscado ou NotFound caso nenhum gênero seja encontrado </returns>

        /// somente o usuário administrador pode buscar um gênero pelo id
        [Authorize(Roles = "administrador")]
        /// http://localhost:5000/api/generos/idGenero
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cria um objeto "generoBuscado" que irá receber o "generoBuscado" no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);
            // um "=" é atribuição, um "==" é uma comparação

            // verifica se nenhum gênero foi encontrado
            if (generoBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado!");
            }

            // caso seja encontrado, retorna o gênero buscado com um status code 200 - Ok
            return Ok(generoBuscado);
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

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pela URL da requisição
        /// </summary>
        /// <param name="id"> id do gênero que será atualizado </param>
        /// <param name="generoAtualizado"> objeto "generoAtualizado" com as novas informações </param>
        /// <returns> um status code </returns>
        /// http://localhost:5000/api/generos/idGenero
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain generoAtualizado)
        {
            // cria um objeto "generoBuscado" que irá receber o gênero buscado do banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

            // caso ele não seja encontrado, retorna um NotFoud com uma mensagem personalizada
            // e um bool para apresentar que houve um erro
            if (generoBuscado == null)
            {
                return NotFound(new { mensagem = "Gênero não encontrado!", erro = true });
            }

            // o "try/catch" serve para tratamento de erros
            // tenta atualizar o registro(genero) || se não acontece nenhum erro...
            try
            {
                // faz a chamada para o método .AtualizarIdUrl()
                _generoRepository.AtualizarIdUrl(id, generoAtualizado);

                // retorna um status code 204 - No Content
                return NoContent();
            }

            // caso ocorra algum erro...
            catch (Exception codErro)
            {
                // retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="generoAtualizado"> objeto "generoAtualizado" com as novas informações </param>
        /// <returns> um status code </returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain generoAtualizado)
        {
            // cria um objeto "generoBuscado" que irá receber o gênero buscado no banco de dados
            GeneroDomain generoBuscado = _generoRepository.BuscarPorId(generoAtualizado.idGenero);

            // verifica se algum gênero foi encontrado
            // se o "generoBuscado" não é igual a null...
            if (generoBuscado != null)
            {
                // tenta atualizar o registro
                try
                {
                    // faz a chamada para o método .AtualizarIdCorpo
                    _generoRepository.AtualizarIdCorpo(generoAtualizado);

                    // retorna um status code 204 - No Content
                    return NoContent();
                }
                // caso ocorra algum erro...
                catch (Exception codErro)
                {
                    // retorna BadRequest com o código do erro
                    return BadRequest(codErro);
                }
            }
            // se não...
            else
                // caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                return NotFound(new { mensagem = "Gênero não encontrado!" });
        }

        /// <summary>
        /// Deleta uma gênero existente
        /// </summary>
        /// <param name="id"> id do gênero que será deletado </param>
        /// <returns> Um status code 204 - No Content </returns>
        /// http://localhost:5000/api/generos/idGenero
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método .Deletar
            _generoRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }
    }
}