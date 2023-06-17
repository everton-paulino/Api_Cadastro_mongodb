using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data.Configurations;
using WebApplication3.Models;

namespace WebApplication3.Data.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IMongoCollection<Pessoa> _pessoas;

        public PessoaRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _pessoas = database.GetCollection<Pessoa>("pessoas");
        }

        public void Adicionar(Pessoa novapessoa)
        {
            _pessoas.InsertOne(novapessoa);
        }

        public void Atualizar(Pessoa pessoaAtualizada)
        {
            _pessoas.ReplaceOne(pessoa => pessoa.Key == pessoaAtualizada.Key, pessoaAtualizada);
        }

        public IEnumerable<Pessoa> Buscar()
        {
            return _pessoas.Find(b => b.IsActive).ToList();
        }

        public Pessoa BuscarporKey(string key)
        {
            return _pessoas.Find(pessoa => pessoa.Key == key).FirstOrDefault();
        }

        
    }
}
