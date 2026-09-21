using System;

// Token: 0x02000AD7 RID: 2775
public class RedIceBeast : MiniBossUnitConfigurationBase
{
	// Token: 0x06004AD3 RID: 19155 RVA: 0x001EA81F File Offset: 0x001E8C1F
	public RedIceBeast()
	{
	}

	// Token: 0x17000FB9 RID: 4025
	// (get) Token: 0x06004AD4 RID: 19156 RVA: 0x001EA827 File Offset: 0x001E8C27
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedIceBeast;
		}
	}

	// Token: 0x17000FBA RID: 4026
	// (get) Token: 0x06004AD5 RID: 19157 RVA: 0x001EA82E File Offset: 0x001E8C2E
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
