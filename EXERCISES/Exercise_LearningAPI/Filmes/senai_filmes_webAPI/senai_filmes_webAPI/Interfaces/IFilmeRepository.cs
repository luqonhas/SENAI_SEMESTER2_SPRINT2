using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> ListarTodos();
        FilmeDomain BuscarPorId(int id);
        void Cadastrar(FilmeDomain novoFilme);
        void AtualizarIdCorpo(FilmeDomain filme);
        void AtualizarIdUrl(int id, FilmeDomain filme);
        void Deletar(int id);
    }
}
