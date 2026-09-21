using System;
using UnityEngine;

// Token: 0x020009CA RID: 2506
[Serializable]
public class SkillLocalization
{
	// Token: 0x06004503 RID: 17667 RVA: 0x001BED6F File Offset: 0x001BD16F
	public SkillLocalization()
	{
	}

	// Token: 0x06004504 RID: 17668 RVA: 0x001BED78 File Offset: 0x001BD178
	public Description CreateDescription()
	{
		return new Description
		{
			Title = this.Title,
			Details1 = this.Description,
			Details2 = this.PassiveDescription
		};
	}

	// Token: 0x04003401 RID: 13313
	public SkillType SkillType;

	// Token: 0x04003402 RID: 13314
	public string Title;

	// Token: 0x04003403 RID: 13315
	[TextArea]
	public string Description;

	// Token: 0x04003404 RID: 13316
	[TextArea]
	public string PassiveDescription;
}
