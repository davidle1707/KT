using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    public class BusinessFileBrokerApprovalProcess
    {
        public List<BrokerApprovalProcessQuestionItem> Step1 { get; set; } = new List<BrokerApprovalProcessQuestionItem>();

        public List<BrokerApprovalProcessQuestionItem> Step2 { get; set; } = new List<BrokerApprovalProcessQuestionItem>();

        public List<BrokerApprovalProcessQuestionItem> Step3 { get; set; } = new List<BrokerApprovalProcessQuestionItem>();
    }

    [Serializable]
    public class BrokerApprovalProcessQuestionItem: IKTWrapCheckListItem
    {
        public ObjectId AppSettingId { get; set; }

        public string QuestionNote { get; set; }

        public bool Verified { get; set; }

        public string ListItemId => AppSettingId.ToString();

        public string ListItemName => AppSettingId.ToString();
    }
}
