using MongoDB.Bson.Serialization.Attributes;

namespace Marketing.Domain.Models
{
    public class Customer
    {
        public string Id = Guid.NewGuid().ToString();

        [BsonElement("customer_name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;
        [BsonElement("cnpj")]
        public string Cnpj { get; set; } = string.Empty;
        [BsonElement("postal_code")]
        public string PostalCode { get; set; } = string.Empty;
        [BsonElement("address")]
        public string Address { get; set; } = string.Empty;
        [BsonElement("city")]
        public string City { get; set; } = string.Empty ;
        [BsonElement("region")]
        public string Region { get; set; } = string.Empty ;
        [BsonElement("type_contract")]
        public string TypeContract {  get; set; } = string.Empty;
        [BsonElement("status")]
        public bool Status { get; set; }
    }
}
