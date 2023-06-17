using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public interface IPessoaRepository
    {
        void Adicionar(Pessoa novapessoa);
        void Atualizar(Pessoa pessoaAtualizada);
        IEnumerable<Pessoa> Buscar();
        Pessoa BuscarporKey(string key);


    }
}
