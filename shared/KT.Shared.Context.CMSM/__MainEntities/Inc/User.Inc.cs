using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
	[Serializable]
	public class UserSetting
	{
		public List<UserViewStageSetting> ViewStages { get; set; } = new List<UserViewStageSetting>();

		public List<UserViewDashBoardStageSetting> ViewDashboardStages { get; set; } = new List<UserViewDashBoardStageSetting>();

		public UserSettingPipeline Pipeline { get; set; } = new UserSettingPipeline();

		public UserSettingReceiveFile ReceiveFile { get; set; } = new UserSettingReceiveFile();

		public bool ViewCalendar { get; set; }

		public bool ViewTask { get; set; }

		public bool ViewCampaignSummary { get; set; }

		public string LeftMenuToggleMode { get; set; }

		public string FooterToggleMode { get; set; }

		public bool CanExpandFirstStageMenu { get; set; }
	}

	[Serializable]
	public class UserViewStageSetting
	{
		public ObjectId StageId { get; set; }

        public int ViewMode { get; set; } // 0(my), 1(team), 2(all), refer enum PipelineViewMode
	}

	[Serializable]
	public class UserViewDashBoardStageSetting
	{
		public ObjectId StageId { get; set; }

		public bool View { get; set; }

		public bool IsViewGrid { get; set; }

		public bool IsViewChart { get; set; }
	}

	[Serializable]
	public class UserSettingPipeline
	{
		public List<UserSettingPipelineColumn> Columns { get; set; } = new List<UserSettingPipelineColumn>();
	}

	[Serializable]
	public class UserSettingPipelineColumn
	{
		public int Index { get; set; }

		public int Field { get; set; }

		public string Title { get; set; }
	}

	[Serializable]
	public class UserSettingReceiveFile
	{
		public bool Enable { get; set; }

		public int MaxPerDay { get; set; }

		public int Priority { get; set; }

		public string AllowStates { get; set; }

		public int? LoanPurpose { get; set; }

		public decimal? LoanAmountFrom { get; set; }

		public decimal? LoanAmountTo { get; set; }

		public List<UserSettingReceiveFilePerCampaign> Campaigns { get; set; } = new List<UserSettingReceiveFilePerCampaign>();
	}

	[Serializable]
	public class UserSettingReceiveFilePerCampaign
	{
		public ObjectId CampaignId { get; set; }

		public int MaxPerDay { get; set; }
	}

	[Serializable]
	public class UserChangePwdSetting
	{
		public DateTime? NeedChangeAfterDate { get; set; }

		public ObjectId? ChangeTransactionId { get; set; }

		public string ChangeToken { get; set; }

		public DateTime? ChangeExpiredDate { get; set; }

		public List<History> Histories { get; set; } = new List<History>();

		[Serializable]
		public class History
		{
			public DateTime Date { get; set; }

			public string Token { get; set; }

			public string OldPwd { get; set; }

			public string NewPwd { get; set; }

			public string Description { get; set; }
		}
	}

	[Serializable]
	public class UserSecondaryConsoleSetting
    {
		public List<ObjectId> LoanOrgIds { get; set; } = new List<ObjectId>();

        public List<SectionInfo> Sections { get; set; } = new List<SectionInfo>();

		public List<SectionInfo> SectionTags { get; set; } = new List<SectionInfo>();

		[Serializable]
        public class SectionInfo
        {
            public string Key { get; set; }

            public string Text { get; set; }

            public int Order { get; set; }

            public bool IsDefExpand { get; set; }
        }
    }
    
    [Serializable]
    public class UserBankStatementAnalyzerSetting
    {
        public bool CanNewRequest { get; set; }
		
        public bool CanManage { get; set; }

        public List<ObjectId> ManageOrgIds { get; set; } = new List<ObjectId>();
	}

	[Serializable]
	public class LoanOfficerSetting
	{
		public string LendingQBLoanOfficerLogin { get; set; }

		public string LendingQBLoanOfficerUserType { get; set; }

		public string LendingQBLoanOfficerRole { get; set; }

        public string ByteProLoanOfficerUserName { get; set; }
    }
}
