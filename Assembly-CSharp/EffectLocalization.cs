using System;
using UnityEngine;

// Token: 0x020009CB RID: 2507
[Serializable]
public class EffectLocalization
{
	// Token: 0x06004505 RID: 17669 RVA: 0x001BEDB0 File Offset: 0x001BD1B0
	public EffectLocalization()
	{
	}

	// Token: 0x06004506 RID: 17670 RVA: 0x001BEDB8 File Offset: 0x001BD1B8
	public Description CreateDescription()
	{
		return new Description
		{
			Title = this.Title,
			Details1 = this.Description,
			Details2 = this.Short
		};
	}

	// Token: 0x04003405 RID: 13317
	public BattleEffectType BattleEffectType;

	// Token: 0x04003406 RID: 13318
	public string Title;

	// Token: 0x04003407 RID: 13319
	[TextArea]
	public string Description;

	// Token: 0x04003408 RID: 13320
	[TextArea]
	public string Short;
}
