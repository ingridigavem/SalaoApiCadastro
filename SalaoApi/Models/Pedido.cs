using MongoDB.Bson.Serialization.Attributes;

namespace SalaoApi.Models {
    public class Pedido {
        [BsonRequired]
        [BsonElement("servico")]
        public string Servico { get; set; }

        [BsonRequired]
        [BsonElement("data")]
        public string Data { get; set; }

        [BsonRequired]
        [BsonElement("hora")]
        public string Hora { get; set; }

        [BsonRequired]
        [BsonElement("formaPagamento")]
        public string FormaPagamento { get; set; }

        [BsonElement("observacoes")]
        [BsonDefaultValue("")]
        public string Observacoes { get; set; }
    }
}
