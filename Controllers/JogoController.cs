using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Jogame.Domains;
using API_Jogame.Interfaces;
using API_Jogame.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Jogame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _JogoRepository;
        public JogoController()
        {
            _JogoRepository = new JogoRepository();
        }

        [HttpGet]
        public List<Jogo> Get()
        {
            return _JogoRepository.LerTodos();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Jogo Get(Guid id)
        {
            return _JogoRepository.BuscarPorId(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post(Jogo jogo)
        {
             _JogoRepository.Cadastrar(jogo);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, Jogo jogo)
        {
            jogo.Id = id;
            _JogoRepository.Alterar(jogo);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _JogoRepository.Excluir(id);
        }
    }
}
