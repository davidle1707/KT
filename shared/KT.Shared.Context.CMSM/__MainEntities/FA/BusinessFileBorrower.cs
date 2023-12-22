using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [ChangeMemberName("Borrower Info")]
    public class BusinessFileBorrower : KTWrapMongoEntityId
    {
        public Borrower Borrower { get; set; } = new Borrower();
    }
}
