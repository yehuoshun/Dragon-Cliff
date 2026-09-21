using System;

// Token: 0x02000A53 RID: 2643
public class OriginalPredator : MinionUnitConfigurationBase
{
	// Token: 0x060047D9 RID: 18393 RVA: 0x001DF070 File Offset: 0x001DD470
	public OriginalPredator()
	{
	}

	// Token: 0x17000E23 RID: 3619
	// (get) Token: 0x060047DA RID: 18394 RVA: 0x001DF078 File Offset: 0x001DD478
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Predator;
		}
	}

	// Token: 0x17000E24 RID: 3620
	// (get) Token: 0x060047DB RID: 18395 RVA: 0x001DF07F File Offset: 0x001DD47F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
