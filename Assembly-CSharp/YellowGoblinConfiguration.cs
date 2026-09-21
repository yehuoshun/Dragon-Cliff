using System;

// Token: 0x02000A4D RID: 2637
public class YellowGoblinConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x060047C7 RID: 18375 RVA: 0x001DF003 File Offset: 0x001DD403
	public YellowGoblinConfiguration()
	{
	}

	// Token: 0x17000E17 RID: 3607
	// (get) Token: 0x060047C8 RID: 18376 RVA: 0x001DF00B File Offset: 0x001DD40B
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowGoblin;
		}
	}

	// Token: 0x17000E18 RID: 3608
	// (get) Token: 0x060047C9 RID: 18377 RVA: 0x001DF012 File Offset: 0x001DD412
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
