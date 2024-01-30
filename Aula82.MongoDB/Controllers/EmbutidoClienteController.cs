using Aula82.MongoDB.Models.Embutido;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Aula82.MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbutidoClienteController : ControllerBase
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<ClienteEmbutido> _dbCollection;

        public EmbutidoClienteController()
        {
            _client = new MongoClient("mongodb://root:exemplo@localhost");
            _database = _client.GetDatabase("Dados");
            _dbCollection = _database.GetCollection<ClienteEmbutido>("ClienteEmbutido");
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ClienteEmbutido clienteEmbutido)
        {
            await _dbCollection.InsertOneAsync(clienteEmbutido);
            return Ok(clienteEmbutido);
        }

        //[HttpGet]
        //public async Task<ActionResult> GetById(string id)
        //{
        //    var filter = Builders<ClienteEmbutido>.Filter;
        //    var eqFilter = filter.Eq(x => x.Id, id);
        //    var retorno = await _dbCollection.FindAsync<ClienteEmbutido>(eqFilter).ConfigureAwait(false);
        //    return Ok(retorno.FirstOrDefaultAsync());
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteEmbutido>>> GetAll()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        //[HttpPut(Name = "UpdateClienteEmbutido")]
        //public async Task<ActionResult> Update([FromQuery] string id, [FromBody] ClienteEmbutido clienteEmbutido)
        //{
        //    FilterDefinitionBuilder<ClienteEmbutido> eqFilter = Builders<ClienteEmbutido>.Filter;
        //    FilterDefinition<ClienteEmbutido> eqFilterDefinition = eqFilter.Eq(x => x.Id, id);

        //    UpdateDefinitionBuilder<ClienteEmbutido> updateFilter = Builders<ClienteEmbutido>.Update;
        //    UpdateDefinition<ClienteEmbutido> updateDefinition = updateFilter
        //        .Set(x => x.Nome, clienteEmbutido.Nome)
        //        .Set(x => x.DataNascimento, clienteEmbutido.DataNascimento);

        //    UpdateResult updateResult = await _dbCollection.UpdateOneAsync(eqFilterDefinition, updateDefinition).ConfigureAwait(false);

        //    if (updateResult.ModifiedCount > 0)
        //        return Ok();
        //    else
        //        return BadRequest();
        //}

        //[HttpDelete(Name = "DeleteClienteEmbutido")]
        //public async Task<ActionResult> Delete([FromQuery] string id, [FromBody] ClienteEmbutido clienteEmbutido)
        //{
        //    FilterDefinitionBuilder<ClienteEmbutido> eqFilter = Builders<ClienteEmbutido>.Filter;
        //    FilterDefinition<ClienteEmbutido> eqFilterDefinition = eqFilter.Eq(x => x.Id, id);

        //    DeleteResult deleteResult = await _dbCollection.DeleteOneAsync(eqFilterDefinition).ConfigureAwait(false);

        //    if (deleteResult.DeletedCount > 0)
        //        return Ok();
        //    else
        //        return BadRequest();
        //}


    }
}
