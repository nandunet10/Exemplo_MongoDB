using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aula82.MongoDB.Models.Referencia
{
    public class DependenteReferencia
    {

        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonRequired]
        [BsonElement("clienteId")]
        public int ClienteId { get; set; }

        [BsonRequired]
        [BsonElement("nome")]
        public string Nome { get; set; }


        [BsonRequired]
        [BsonElement("dataNascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
