using System;

// Token: 0x02000AEB RID: 2795
public class BlueBat : MinionUnitConfigurationBase
{
	// Token: 0x06004B47 RID: 19271 RVA: 0x001EBE10 File Offset: 0x001EA210
	public BlueBat()
	{
	}

	// Token: 0x17000FDB RID: 4059
	// (get) Token: 0x06004B48 RID: 19272 RVA: 0x001EBE18 File Offset: 0x001EA218
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueBat;
		}
	}

	// Token: 0x17000FDC RID: 4060
	// (get) Token: 0x06004B49 RID: 19273 RVA: 0x001EBE1F File Offset: 0x001EA21F
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
