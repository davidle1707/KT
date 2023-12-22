
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.Inc
{
    [Serializable]
    public class RoleContent
    {
        public string DefaultName { get; set; }

        public string ContentTitle { get; set; }

        public int ContentType { get; set; }

        public string ContentScriptType { get; set; } // html, form

        public string ContentScriptReference { get; set; }

        public string ContentScriptBody { get; set; }

        public int BusinessType { get; set; }

        public bool ShowInShortApp { get; set; }

        public bool ShowInFullApp { get; set; }

        public bool ShowInShortAppBroker { get; set; }

        public bool ShowInFullAppBroker { get; set; }

        public int? Index { get; set; }

        public RoleContentLockDown LockDown { get; set; }

        public RoleContentQuestionnaire Questionnaire { get; set; }
    }

    [Serializable]
    public class RoleContentLockDown
    {
        public bool CanOverride { get; set; }

        public List<RoleContentLockDownTrigger> Triggers { get; set; }
    }

    [Serializable]
    public class RoleContentLockDownTrigger
    {
        public int Type { get; set; }

        public List<ObjectId> TriggerIds { get; set; } = new List<ObjectId>();
    }

    [Serializable]
    public class RoleContentQuestionnaire
    {
        public ObjectId Id { get; set; }

        public List<ValidateStage> ValidateStages { get; set; } = new List<ValidateStage>();

        [Serializable]
        public class ValidateStage
        {
            public ObjectId StageId { get; set; }

            public ObjectId StatusId { get; set; }
        }
    }
}
