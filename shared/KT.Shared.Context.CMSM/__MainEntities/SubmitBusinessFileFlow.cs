using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(SubmitBusinessFileFlow))]
    public partial class SubmitBusinessFileFlow : KTWrapMongoEntity, IIdName
    {
        public string Name { get; set; }

        public ObjectId FrontEndOrgId { get; set; }

        public ObjectId BackEndOrgId { get; set; }

        public int BusinessType { get; set; }

        public ObjectId? ReturnFrontEndStageId { get; set; }

        public ObjectId? ReturnFrontEndStatusId { get; set; }

        public ObjectId SubmitBackEndStageId { get; set; }

        public ObjectId SubmitBackEndStatusId { get; set; }

        public ObjectId? ChangeFrontEndStageId { get; set; }

        public ObjectId? ChangeFrontEndStatusId { get; set; }

        public ObjectId? ChangeBackEndStageId { get; set; }

        public ObjectId? ChangeBackEndStatusId { get; set; }

        public bool FrontEndHasNotifyEmail { get; set; }

        public bool BackEndHasNotifyEmail { get; set; }

        public NotifyEmail FrontEndNotifyEmail { get; set; }

        public NotifyEmail BackEndNotifyEmail { get; set; }

        public ObjectId? SubmitBackEndOwnerId { get; set; }

        public BackEndOwner[] SubmitBackEndOwners { get; set; }
    }

    public partial class SubmitBusinessFileFlow
    {
        [Serializable]
        public class NotifyEmail
        {
            public bool ToSyncOwner { get; set; }

            public bool ToAccountExecutive { get; set; }

            public string ToOthers { get; set; }

            public string Subject { get; set; }

            public string Body { get; set; }
        }

        [Serializable]
        public class BackEndOwner
        {
            public ObjectId FEBranchId { get; set; }

            public ObjectId OwnerId { get; set; }
        }
    }
   
}
