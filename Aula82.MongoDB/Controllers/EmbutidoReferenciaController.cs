using Aula82.MongoDB.Models.Embutido;
using Aula82.MongoDB.Models.Referencia;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Aula82.MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbutidoReferenciaController : ControllerBase
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<ClienteReferencia> _dbCollection;

        public EmbutidoReferenciaController()
        {
            _client = new MongoClient("mongodb://root:exemplo@localhost");
            _database = _client.GetDatabase("Dados");
            _dbCollection = _database.GetCollection<ClienteReferencia>("ClienteReferencia");
        }

        [HttpPost(Name = "AddClienteReferencia")]
        public async Task<ActionResult> Add([FromBody] ClienteReferencia clienteReferencia)
        {
            await _dbCollection.InsertOneAsync(clienteReferencia);
            return Ok(clienteReferencia);
        }

        //[HttpGet(Name = "TodosReferencia")]
        //public async Task<ActionResult> GetById(string id)
        //{
        //    var filter = Builders<ClienteReferencia>.Filter;
        //    var eqFilter = filter.Eq(x => x.Id, id);
        //    var retorno = await _dbCollection.FindAsync<ClienteReferencia>(eqFilter).ConfigureAwait(false);
        //    return Ok(retorno.FirstOrDefaultAsync());
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteReferencia>>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        //[HttpPut(Name = "UpdateClienteReferencia")]
        //public async Task<ActionResult> Update([FromQuery] string id, [FromBody] ClienteReferencia clienteReferencia)
        //{
        //    FilterDefinitionBuilder<ClienteReferencia> eqFilter = Builders<ClienteReferencia>.Filter;
        //    FilterDefinition<ClienteReferencia> eqFilterDefinition = eqFilter.Eq(x => x.Id, id);

        //    UpdateDefinitionBuilder<ClienteReferencia> updateFilter = Builders<ClienteReferencia>.Update;
        //    UpdateDefinition<ClienteReferencia> updateDefinition = updateFilter
        //        .Set(x => x.Nome, clienteReferencia.Nome)
        //        .Set(x => x.DataNascimento, clienteReferencia.DataNascimento);

        //    UpdateResult updateResult = await _dbCollection.UpdateOneAsync(eqFilterDefinition, updateDefinition).ConfigureAwait(false);

        //    if (updateResult.ModifiedCount > 0)
        //        return Ok();
        //    else
        //        return BadRequest();
        //}

        //[HttpDelete(Name = "DeleteClienteReferencia")]
        //public async Task<ActionResult> Delete([FromQuery] string id)
        //{
        //    FilterDefinitionBuilder<ClienteReferencia> eqFilter = Builders<ClienteReferencia>.Filter;
        //    FilterDefinition<ClienteReferencia> eqFilterDefinition = eqFilter.Eq(x => x.Id, id);

        //    DeleteResult deleteResult = await _dbCollection.DeleteOneAsync(eqFilterDefinition).ConfigureAwait(false);

        //    if (deleteResult.DeletedCount > 0)
        //        return Ok();
        //    else
        //        return BadRequest();
        //}

    }
}
