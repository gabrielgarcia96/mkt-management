using MongoDB.Bson.Serialization.Attributes;

namespace Marketing.Domain.Models
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("social_reason")]
        public string SocialReason { get; set; } = string.Empty;
        [BsonElement("tradeName")]
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
        [BsonElement("contract_start_date")]
        public DateTime ContractStartDate { get; set; } = DateTime.UtcNow.AddHours(-3);

        [BsonElement("contract_end_date")]
        public DateTime ContractEndDate { get; set; } = DateTime.UtcNow.AddHours(-3);

        [BsonElement("ContractFile")]
        public byte[]? ContractFile { get; set; }
        

        public bool Status { get; set; }
    }
}
