using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SalaoApi.Models {
    public class Cadastro {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("nome")]
        public string Nome { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonRequired]
        [BsonElement("telefone")]
        [StringLength(25, ErrorMessage = "O campo telefone não pode ter mais do que 25 caracteres.")]
        public string Telefone { get; set; }

        [BsonElement("pedido")]
        public Pedido Pedido { get; set; }
    }
}
