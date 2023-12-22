using System;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
    [KTWrapMongoCollectionName(typeof(ReleaseAnnouncement))]
    public class ReleaseAnnouncement : KTWrapMongoEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsActive { get; set; }

        public DateTime ReleasedDate { get; set; }

        public DateTime? AnnouncementDate { get; set; }

        public string ReleasedVersion { get; set; }

        public int[] ViewUserTypes { get; set; } = new int[] { };
    }
}
