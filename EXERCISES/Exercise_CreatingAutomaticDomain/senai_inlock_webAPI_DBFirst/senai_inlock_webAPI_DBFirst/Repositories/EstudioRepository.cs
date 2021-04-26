using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using senai_inlock_webAPI_DBFirst.Contexts;
using senai_inlock_webAPI_DBFirst.Domains;
using senai_inlock_webAPI_DBFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_DBFirst.Repositories
{
    /// <summary>
    /// classe responsável pelo repositório dos estúdios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// objeto "context" por onde serão chamadosos métodos do EF Core
        /// </summary>
        InLockContext context = new InLockContext();

        public void Atualizar(int id, Estudio estudioAtualizado)
        {
            // busca o estúdio através do seu id
            Estudio estudioBuscado = context.Estudios.Find(id);

            // verifica se o nome do estúdio tem informado
            if (estudioAtualizado.NomeEstudio != null)
            {
                // atribui os novos valores aos valores existentes
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            // atualiza o estúdio que foi buscado
            context.Estudios.Update(estudioBuscado);

            // salva as informações para que sejam gravadas no banco de dados
            context.SaveChanges();
        }

        public Estudio BuscarPorId(int id)
        {
            // retorna o primeiro estúdio encontrado para o id informado
            return context.Estudios.FirstOrDefault(objetoEstudio => objetoEstudio.IdEstudio == id);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            // adiciona esse novo estúdio
            context.Estudios.Add(novoEstudio);

            // salva as informações para serem gravadas no banco de dados
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Estudio estudioBuscado = context.Estudios.Find(id);

            context.Estudios.Remove(estudioBuscado);

            context.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            // retorna uma lista com todas as informações dos estúdios
            return context.Estudios.ToList();
        }

        public List<Estudio> ListarJogos()
        {
            // retorna uma lista de estudios com sua lista de jogos
            // return context.Estudios.Include("Jogos").ToList()
            return context.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
