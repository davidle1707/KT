using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM.BA
{
    [Serializable]
    [BsonDiscriminator(nameof(ReviewAndSign), Required = true)]
    public sealed class ReviewAndSign : BaseStep
    {
        public bool IsDownloaded { get; set; }

        public bool IsESignRequested { get; set; }

        public List<MapESigner> MapESigners { get; set; }

    }

    [Serializable]
    public class MapESigner
    {
        public ObjectId From { get; set; }

        public ObjectId To { get; set; }

        public string Source { get; set; }

    }
}
