using API_Jogame.Context;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        // readonly significa somente leitura, sem alterações
        // uso do encapsulamento
        private readonly JogoContext cont;
        // fiz o  metodo construtor para instanciar o context dentro do repository
        public JogoRepository()
        {
            cont = new JogoContext();
        }

        // Region é um comando de organização dos codigos
        #region Gravação
        /// <summary>
        /// Altera um jogo
        /// </summary>
        /// <param name="jogo">jogo a ser editado</param>
        public void Alterar(Jogo jogo)
        {
            try
            {
                //Busca jogo pelo seu id
                Jogo jogoTemp = BuscarPorId(jogo.Id);

                // Verifica se o jogo existe 
                // Caso n exista gera uma exception
                if(jogoTemp == null)
                
                    throw new Exception("Jogo não encontrado");

                    // Caso exista altera
                    jogoTemp.Nome = jogo.Nome;
                    jogoTemp.Descricao = jogo.Descricao;

                    // Altera os produtos no context
                    cont.Jogos.Update(jogoTemp);

                    cont.SaveChanges();
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Cadastra os jogos
        /// </summary>
        /// <param name="jogo">Objeto jogo</param>
        public void Cadastrar(Jogo jogo)
        {
            // try - tente
            // catch - excessão
            // Try catch é um tipo de tratativa para o nosso erro
            try
            {
                //Adiciona objeto do tipo jogo ao dbset do contexto
                cont.Jogos.Add(jogo);

                // Salva as alterações no contexto
                cont.SaveChanges();
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Exclui o jogo cadastrado
        /// </summary>
        /// <param name="id">ID do jogo</param>
        public void Excluir(Guid id)
        {
            try
            {
                // Buscar jogo pelo ID
                Jogo jogoTemp = BuscarPorId(id);

                // verifica se o produto existe
                // Caso não gera um ex
                if(jogoTemp == null)
                
                    throw new Exception("Jogo não encontrado");         

                // Remove os jogos no DbSet
                cont.Jogos.Remove(jogoTemp);
                // salva as alterações do contexto
                cont.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Leitura
        /// <summary>
        /// Busca um jogo pelo seu Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns>Jogo</returns>
        public Jogo BuscarPorId(Guid id)
        {
            try
            {
                //return cont.Jogos.FirstOrDefault(c => c.Id == id);
                return cont.Jogos.Find(id);
               
            }
            catch (Exception ex)
            {
                // caso ocorra algum erro vai retornar uma excessao
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista todos os jogos cadastrados
        /// </summary>
        /// <returns>retorna uma lista de jogos cadastrados</returns>
        public List<Jogo> LerTodos()
        {
            try
            {
                // faz o retorno dessa lista de jogos no contexto
                return cont.Jogos.ToList();
            }
            catch (Exception ex)
            {
                // caso ocorra algum erro vai retornar uma excessao
                throw new Exception(ex.Message);
            }
        }
        #endregion


    }

}
