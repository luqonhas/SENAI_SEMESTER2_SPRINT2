using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_inlock_webAPI_DBFirst.Domains;
using senai_inlock_webAPI_DBFirst.Interfaces;
using senai_inlock_webAPI_DBFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_DBFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_estudioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudio estudioAtualizado)
        {
            _estudioRepository.Atualizar(id, estudioAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpGet("jogos")]
        public IActionResult GetGames()
        {
            return Ok(_estudioRepository.ListarJogos());
        }

    }
}
