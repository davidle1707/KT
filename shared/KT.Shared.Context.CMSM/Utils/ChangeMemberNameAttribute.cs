using System.ComponentModel;

namespace KT.Shared.Context
{
    public class ChangeMemberNameAttribute : DescriptionAttribute
	{
		public ChangeMemberNameAttribute(string memberName) : base(memberName)
		{
		}
	}
}
