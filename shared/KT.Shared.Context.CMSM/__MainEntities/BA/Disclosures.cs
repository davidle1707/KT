using MongoDB.Bson.Serialization.Attributes;
using System;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(Disclosures), Required = true)]
    public sealed class Disclosures : BaseStep
    {
        public bool? Question1 { get; set; }
        public bool? Question2 { get; set; }
        public bool? Question3 { get; set; }
        public bool? Question4 { get; set; }
        public bool? Question5 { get; set; }
        public bool? Question6 { get; set; }
        public bool? Question7 { get; set; }
        public bool? Question8 { get; set; }
        public bool? Question9 { get; set; }
        public bool? Question10 { get; set; }
        public bool? Question11 { get; set; }

        public string Question1To7ExplainForYes { get; set; }

        public bool Question8QCPlanForYes { get; set; }
        public bool Question8PartyReviewForYes { get; set; }
        public bool Question8OtherForYes { get; set; }
        public string Question8ExplainForYes { get; set; }

        public bool Question8DoNotParticipateForNo { get; set; }
        public bool Question8CompliantForNo { get; set; }
        public bool Question8OtherForNo { get; set; }
        public string Question8ExplainForNo { get; set; }

        public int Question9NumberOfLoanForYes { get; set; }
        public decimal Question9TotalAmountForYes { get; set; }

        public string Question10ExplainForNo { get; set; }
        public string Question11ExplainForNo { get; set; }

    }
}
