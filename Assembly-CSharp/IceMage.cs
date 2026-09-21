using System;

// Token: 0x02000AFA RID: 2810
public class IceMage : MinionUnitConfigurationBase
{
	// Token: 0x06004B85 RID: 19333 RVA: 0x001F12A6 File Offset: 0x001EF6A6
	public IceMage()
	{
	}

	// Token: 0x17000FF9 RID: 4089
	// (get) Token: 0x06004B86 RID: 19334 RVA: 0x001F12AE File Offset: 0x001EF6AE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.IceMage;
		}
	}

	// Token: 0x17000FFA RID: 4090
	// (get) Token: 0x06004B87 RID: 19335 RVA: 0x001F12B5 File Offset: 0x001EF6B5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
