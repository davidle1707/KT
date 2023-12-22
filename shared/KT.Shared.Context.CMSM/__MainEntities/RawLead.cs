using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(RawLead))]
    public class RawLead : KTWrapMongoEntity
    {
        public ObjectId? OwnerId { get; set; }
 
        public string Source { get; set; }
     
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
      
        public string Address { get; set; }
      
        public string City { get; set; }
      
        public string State { get; set; }
      
        public string Zip { get; set; }
      
        public string HomePhone { get; set; }
      
        public string CellPhone { get; set; }
      
        public string WorkPhone { get; set; }
       
        public string CoHomePhone { get; set; }
       
        public string CoCellPhone { get; set; }
      
        public string CoWorkPhone { get; set; }
        
        public string Email { get; set; }
       
        public string ReferenceNumber { get; set; }
      
        public ObjectId? ForId { get; set; }
     
        public string ForType { get; set; }
       
        public decimal? TotalLoanAmount { get; set; }
       
        public ObjectId? InstanceId { get; set; }
    }
}
