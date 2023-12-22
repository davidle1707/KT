using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
	[Serializable, KTWrapMongoCollectionName(typeof(QuestionnaireAnswer))]
	[BsonDiscriminator(Required = true)]
	public abstract partial class QuestionnaireAnswer : KTWrapMongoEntity
	{
		public ObjectId QuestionnaireId { get; set; }

		public List<Answer> Answers { get; set; } = new List<Answer>();

		[Serializable]
		public class Answer
		{
			public ObjectId QuestionId { get; set; }

			public ObjectId SuggestAnswerId { get; set; }

			public DateTime Date { get; set; }

            public ObjectId? By { get; set; }

            public string Value { get; set; }

			public string ExtendValue { get; set; }
		}
	}

	[BsonKnownTypes(typeof(FileApp))]
	public partial class QuestionnaireAnswer
	{
		[Serializable, BsonDiscriminator(nameof(FileApp), Required = true)]
		public class FileApp : QuestionnaireAnswer
		{
			public ObjectId ShareDataId { get; set; }
		}
	}

	[BsonKnownTypes(typeof(General))]
	public partial class QuestionnaireAnswer
	{
		[Serializable, BsonDiscriminator(nameof(General), Required = true)]
		public class General : QuestionnaireAnswer
		{
			public string IpAddress { get; set; }
		}
	}

}
