using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BorrowerCreditScore : KTWrapMongoEntityId, IKTWrapCheckListItem
    {
        public bool IsBorrower { get; set; }

        public string CreditRepositorySourceType { get; set; }

        public int Score { get; set; }

        public DateTime ProduceDate { get; set; }

        public string ListItemId => Id.ToString();

        public string ListItemName => Id.ToString();
    }
}
