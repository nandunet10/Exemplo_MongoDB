using MongoDB.Bson.Serialization.Attributes;

namespace Aula82.MongoDB.Models.Embutido
{
    public class DependenteEmbutido
    {
        [BsonRequired]
        [BsonElement("nome")]
        public string Nome { get; set; }


        [BsonRequired]
        [BsonElement("dataNascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
