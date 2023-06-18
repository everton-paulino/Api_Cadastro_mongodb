using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Models.InputModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private IPessoaRepository _pessoaRepository;
        public CadastroController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        // GET: api/<CadastroController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = _pessoaRepository.Buscar();
            return Ok(response);
        }

        // GET api/<CadastroController>/5
        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            var pessoa = _pessoaRepository.BuscarporKey(key);
            
            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        // POST api/<CadastroController>
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa novaPessoa)
        {
            var addPessoa = new Pessoa();
            addPessoa.Name = novaPessoa.Name;
            addPessoa.Documents = novaPessoa.Documents;

            _pessoaRepository.Adicionar(addPessoa);

            return Ok(addPessoa);
        }

        // PUT api/<CadastroController>/5
        [HttpPut("{key}")]
        public IActionResult Put(string key, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoaUpdate = _pessoaRepository.BuscarporKey(key);

            if (pessoaUpdate == null)
                return NotFound();

            pessoaUpdate.UpdatedAt = DateTime.Now;
            pessoaUpdate.IsActive = pessoaAtualizada.IsActive;
            pessoaUpdate.Name = pessoaAtualizada.Name;
            pessoaUpdate.Documents = pessoaAtualizada.Documents;

            _pessoaRepository.Atualizar(pessoaUpdate);

            return Ok(pessoaAtualizada);
            
        }

        // DELETE api/<CadastroController>/5
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            var pessoadeletada = _pessoaRepository.BuscarporKey(key);

            if (pessoadeletada == null)
                return NotFound();

            pessoadeletada.IsActive = false;

            _pessoaRepository.Atualizar(pessoadeletada);

            return Ok(pessoadeletada);
               
            



        }
    }
}
