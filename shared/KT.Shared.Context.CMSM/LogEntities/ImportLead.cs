using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM.LogEntities
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ImportLead))]
    public class ImportLead : KTWrapMongoEntity
    {
        public ObjectId OrganizationId { get; set; }
       
        public ObjectId? CampaignId { get; set; }
     
        public DateTime ImportedDate { get; set; }
     
        public ObjectId ImportedBy { get; set; }
      
        public int TotalRecords { get; set; }
       
        public int TotalFailRecords { get; set; }
      
        public string FileExtention { get; set; }
     
        public string ImportedName { get; set; }   

        public string Source { get; set; }

        public string SourceMetadata { get; set; }
    }
}
