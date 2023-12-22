using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(LosLoanMapping))]
    public abstract partial class LosLoanMapping : KTWrapMongoEntity
    {
    }

    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(LendingQBMappingLoan), typeof(LendingQBMappingDocType), typeof(LendingQBMappingTemplate), 
                    typeof(ByteProMappingLoan), typeof(ByteProMappingDocType), typeof(ByteProExtendField))]
    public abstract partial class LosLoanMapping
    {
        #region LendingQB

        [Serializable]
        [BsonDiscriminator(nameof(LendingQBMappingLoan), Required = true)]
        public class LendingQBMappingLoan : LosLoanMapping
        {
            public int LendingQbDataSection { get; set; }

            public int LendingQbElementType { get; set; }

            public string LendingQbElementName { get; set; }

            public string MappingElementName { get; set; }

            public int? ConvertionType { get; set; }

            public bool IsSubmit { get; set; }

            public bool IsLoad { get; set; }

            public int? LookupAppSettingType { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(LendingQBMappingDocType), Required = true)]
        public class LendingQBMappingDocType : LosLoanMapping
        {
            public string LendingQbDocTypeName { get; set; }

            public int LendingQbDocTypeId { get; set; }

            public int DocumentCategoryId { get; set; }

            public ObjectId OrganizationId { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(LendingQBMappingTemplate), Required = true)]
        public class LendingQBMappingTemplate : LosLoanMapping
        {
            public ObjectId OrganizationId { get; set; }

            public string LendingQbTemplateName { get; set; }

            public decimal MinLoanAmount { get; set; }

            public decimal MaxLoanAmount { get; set; }

            public int LoanPurpose { get; set; }

            public string Occupancy { get; set; }

            public List<ObjectId> ProductIds { get; set; } = new List<ObjectId>();

        }

        #endregion

        #region BytePro

        [Serializable]
        [BsonDiscriminator(nameof(ByteProMappingLoan), Required = true)]
        public class ByteProMappingLoan : LosLoanMapping
        {
            public int DataSection { get; set; }

            public string ByteProElementName { get; set; }

            public string MappingElementName { get; set; }

            public int? ConvertionType { get; set; }

            public bool IsSubmit { get; set; }

            public bool IsLoad { get; set; }

            public int? LookupAppSettingType { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(ByteProMappingDocType), Required = true)]
        public class ByteProMappingDocType : LosLoanMapping
        {
            public string ByteProDocType { get; set; }

            public string ByteProDocCate { get; set; }

            public int DocumentCategoryId { get; set; }

            public ObjectId OrganizationId { get; set; }
        }

        [Serializable]
        [BsonDiscriminator(nameof(ByteProExtendField), Required = true)]
        public class ByteProExtendField : LosLoanMapping
        {
            public string Name { get; set; }

            public string DataType { get; set; }
        }

        #endregion
    }
}
