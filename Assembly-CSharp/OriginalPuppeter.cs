using System;

// Token: 0x02000A54 RID: 2644
public class OriginalPuppeter : MinionUnitConfigurationBase
{
	// Token: 0x060047DC RID: 18396 RVA: 0x001DF082 File Offset: 0x001DD482
	public OriginalPuppeter()
	{
	}

	// Token: 0x17000E25 RID: 3621
	// (get) Token: 0x060047DD RID: 18397 RVA: 0x001DF08A File Offset: 0x001DD48A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Puppeteer;
		}
	}

	// Token: 0x17000E26 RID: 3622
	// (get) Token: 0x060047DE RID: 18398 RVA: 0x001DF091 File Offset: 0x001DD491
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}
}
