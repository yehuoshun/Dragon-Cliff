using System;

// Token: 0x02000AFE RID: 2814
public class CannibalBear : MinionUnitConfigurationBase
{
	// Token: 0x06004B91 RID: 19345 RVA: 0x001F12EF File Offset: 0x001EF6EF
	public CannibalBear()
	{
	}

	// Token: 0x17001001 RID: 4097
	// (get) Token: 0x06004B92 RID: 19346 RVA: 0x001F12F7 File Offset: 0x001EF6F7
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.CannibalBear;
		}
	}

	// Token: 0x17001002 RID: 4098
	// (get) Token: 0x06004B93 RID: 19347 RVA: 0x001F12FE File Offset: 0x001EF6FE
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
