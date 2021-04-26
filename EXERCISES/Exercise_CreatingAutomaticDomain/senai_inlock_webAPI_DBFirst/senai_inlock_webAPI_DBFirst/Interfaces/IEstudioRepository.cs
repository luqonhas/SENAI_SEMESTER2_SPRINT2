using senai_inlock_webAPI_DBFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_inlock_webAPI_DBFirst.Interfaces
{
    /// <summary>
    /// responsável pelo EstudioRepository
    /// </summary>
    interface IEstudioRepository
    {
        List<Estudio> Listar();

        Estudio BuscarPorId(int id);

        void Cadastrar(Estudio novoEstudio);

        void Atualizar(int id, Estudio estudioAtualizado);

        void Deletar(int id);

        /// <summary>
        /// Lista todos os estúdios com a lista de jogos 
        /// </summary>
        /// <returns> uma lista de estúdios com seus respectivos jogos </returns>
        List<Estudio> ListarJogos();
    }
}
