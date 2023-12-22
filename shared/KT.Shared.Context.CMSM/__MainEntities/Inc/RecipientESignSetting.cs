using System;
using System.Collections.Generic;

namespace KT.Shared.Context.CMSM
{
    [Serializable]
	public class RecipientESignSetting : KTWrapMongoEntityId
    {
        public string SettingName { get; set; }

        public string ActionType { get; set; }

        public string Notes { get; set; }

        public List<FieldESignSetting> Fields { get; set; }

    }

    [Serializable]
    public class FieldESignSetting : KTWrapMongoEntityId
    {
        public string Name { get; set; }

        public string FieldLabel { get; set; }

        public bool IsMandatory { get; set; }

        public int PageNo { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        public int AbsWidth { get; set; }

        public int AbsHeight { get; set; }

        public string FieldType { get; set; }

        public string DescriptionTooltip { get; set; }
    }
}
