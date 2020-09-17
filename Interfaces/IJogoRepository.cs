using API_Jogame.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Interfaces
{
    interface IJogoRepository
    {
        // Aqui fazemos o CRUD
        // Lista todos os jogos cadastrados
        List<Jogo> LerTodos();
        // Neste metodo buscamos por id
        Jogo BuscarPorId(Guid id);
        // Cadastramos o jogo
        void Cadastrar(Jogo jogo);
        // Alteramos o jogo
        void Alterar(Jogo jogo);
        // Excluimos o jogo pelo seu Id
        void Excluir(Guid id);
      
        
    }
}
