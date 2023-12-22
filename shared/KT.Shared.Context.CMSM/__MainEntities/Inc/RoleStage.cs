
using MongoDB.Bson;
using System;

namespace KT.Shared.Context.CMSM.Inc
{
    [Serializable]
    public class RoleStage 
    {
        public int BusinessType { get; set; }

        public ObjectId StageId { get; set; }

        public bool CanCreate { get; set; }

        public bool CanView { get; set; }

        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }

        public bool CanViewAll { get; set; }

        public bool CanEditAll { get; set; }

        public bool CanDeleteAll { get; set; }

        public bool CanViewTeam { get; set; }

        public bool CanEditTeam { get; set; }

        public bool CanDeleteTeam { get; set; }
    }
}
