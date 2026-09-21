using System;

// Token: 0x02000AF9 RID: 2809
public class GreenHighMage : MinionUnitConfigurationBase
{
	// Token: 0x06004B82 RID: 19330 RVA: 0x001F1294 File Offset: 0x001EF694
	public GreenHighMage()
	{
	}

	// Token: 0x17000FF7 RID: 4087
	// (get) Token: 0x06004B83 RID: 19331 RVA: 0x001F129C File Offset: 0x001EF69C
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenHighMage;
		}
	}

	// Token: 0x17000FF8 RID: 4088
	// (get) Token: 0x06004B84 RID: 19332 RVA: 0x001F12A3 File Offset: 0x001EF6A3
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
