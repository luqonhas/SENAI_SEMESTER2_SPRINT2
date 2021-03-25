using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_peoples_webAPI.Domains;
using senai_peoples_webAPI.Interfaces;
using senai_peoples_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _funcionarioRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _funcionarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        /// método contrutor é uma função que vai ser executada toda vez que essa classe for chamada
        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }


        //////////////////// ÁREA GET: ////////////////////


        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns> Uma lista de funcionários e um status code </returns>
        [HttpGet]
        public IActionResult Get()
        {
            // cria uma lista nomeada "listaFuncionarios" para receber os dados
            // aqui está sendo listado todos os funcionários e armazenando na lista
            // se eu quero enviar uma lista pra quem tá pedindo
            List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.Listar();

            // retorna o status code 200(Ok) com a lista de funcionarios no formato JSON
            return Ok(listaFuncionarios);
        }


        /// <summary>
        /// Busca atráves do seu id
        /// </summary>
        /// <param name="id"> id do funcionário que será buscado </param>
        /// <returns> Um funcionário buscado ou NotFound caso nenhum funcionário seja encontrado </returns>
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // cria um objeto "funcionarioBuscado" que irá receber o "funcionarioBuscado" no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);
            // um "=" é atribuição, um "==" é uma comparação

            // verifica se nenhum funcionário foi encontrado
            if (funcionarioBuscado == null)
            {
                // caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum funcionário encontrado!");
            }

            // caso seja encontrado, retorna o funcionário buscado com um status code 200 - Ok
            return Ok(funcionarioBuscado);
        }


        //////////////////// ÁREA POST: ////////////////////


        /// <summary>
        /// Cadastra um novo funcionario
        /// </summary>
        /// <returns> Um status code 201 - Created </returns>
        /// exemplo: http://localhost:5000/api/funcionarios
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            // faz a chamada para o método Cadastrar
            _funcionarioRepository.Cadastrar(novoFuncionario);

            // retorna o status code 201 - Created
            return StatusCode(201);
        }


        //////////////////// ÁREA PUT: ////////////////////


        /// <summary>
        /// Atualiza um funcionário existente passando o seu id pela URL da requisição
        /// </summary>
        /// <param name="id"> id do funcionário que será atualizado </param>
        /// <param name="funcionarioAtualizado"> objeto "funcionarioAtualizado" com as novas informações </param>
        /// <returns> um status code </returns>
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        {
            // cria um objeto "funcionarioBuscado" que irá receber o gênero buscado do banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // caso ele não seja encontrado, retorna um NotFoud com uma mensagem personalizada
            // e um bool para apresentar que houve um erro
            if (funcionarioBuscado == null)
            {
                return NotFound(new { mensagem = "Funcionário não encontrado!" });
            }

            // o "try/catch" serve para tratamento de erros
            // tenta atualizar o registro(funcionario) || se não acontece nenhum erro...
            try
            {
                // faz a chamada para o método .AtualizarIdUrl()
                _funcionarioRepository.Atualizar(id, funcionarioAtualizado);

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


        //////////////////// ÁREA DELETE: ////////////////////


        /// <summary>
        /// Deleta uma funcionário existente
        /// </summary>
        /// <param name="id"> id do funcionário que será deletado </param>
        /// <returns> Um status code 204 - No Content </returns>
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método .Deletar
            _funcionarioRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }
    }
}
