using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aula82.MongoDB.Models.Referencia
{
    public class ClienteReferencia
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonRequired]
        [BsonElement("cpf")]
        public string CPF { get; set; }


        [BsonRequired]
        [BsonElement("nome")]
        public string Nome { get; set; }


        [BsonRequired]
        [BsonElement("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [BsonRequired]
        [BsonElement("dependenteReferencias")]
        public List<DependenteReferencia>? DependenteReferencias { get; set; }
    }
}
