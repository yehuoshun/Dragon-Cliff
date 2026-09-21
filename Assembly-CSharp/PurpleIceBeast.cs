using System;

// Token: 0x02000AD5 RID: 2773
public class PurpleIceBeast : MiniBossUnitConfigurationBase
{
	// Token: 0x06004AC9 RID: 19145 RVA: 0x001EA6FB File Offset: 0x001E8AFB
	public PurpleIceBeast()
	{
	}

	// Token: 0x17000FB5 RID: 4021
	// (get) Token: 0x06004ACA RID: 19146 RVA: 0x001EA703 File Offset: 0x001E8B03
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleIceBeast;
		}
	}

	// Token: 0x17000FB6 RID: 4022
	// (get) Token: 0x06004ACB RID: 19147 RVA: 0x001EA70A File Offset: 0x001E8B0A
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
