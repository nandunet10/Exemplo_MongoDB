using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aula82.MongoDB.Models.Embutido
{
    public class ClienteEmbutido
    {
        [BsonElement("_id")]
        [BsonId]
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
        [BsonElement("dependenteEmbutidos")]
        public List<DependenteEmbutido>? DependenteEmbutidos { get; set; }
    }
}
