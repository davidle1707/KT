using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [KTWrapMongoCollectionName(typeof(Questionnaire)), Serializable]
	public partial class Questionnaire : KTWrapMongoEntity
	{
        public ObjectId OrganizationId { get; set; }

        public int ViewMode { get; set; }

		public string Title { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public int ForType { get; set; }

		public BsonDocument ForRef { get; set; }

		public List<Question> Questions { get; set; } = new List<Question>();
	}

	public partial class Questionnaire
	{
		[Serializable]
		public class Question : KTWrapMongoEntity
		{
			public string Reference { get; set; }

			public string Text { get; set; }

			public int AnswerMode { get; set; } // single (radio), multiple (checkbox)

			public bool IsRequiredAnswer { get; set; }

			public string ExpectAnswser { get; set; }

			public List<SuggestAnswer> SuggestAnswers { get; set; } = new List<SuggestAnswer>();
		}

		[Serializable]
		public class SuggestAnswer : KTWrapMongoEntity
		{
			public string Text { get; set; }

			public string Value { get; set; }

            public string DocMapKey { get; set; } // use for map value to FileApp

            public int? ExtendControl { get; set; } // text, select, list-check, list-radio

			public KeyText[] Lookup { get; set; } // (select, list-check, list-radio)
		}
	}

}
