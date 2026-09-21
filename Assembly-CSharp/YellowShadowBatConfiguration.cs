using System;

// Token: 0x02000B12 RID: 2834
public class YellowShadowBatConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BE4 RID: 19428 RVA: 0x001F16E6 File Offset: 0x001EFAE6
	public YellowShadowBatConfiguration()
	{
	}

	// Token: 0x17001025 RID: 4133
	// (get) Token: 0x06004BE5 RID: 19429 RVA: 0x001F16EE File Offset: 0x001EFAEE
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowShadowBat;
		}
	}

	// Token: 0x17001026 RID: 4134
	// (get) Token: 0x06004BE6 RID: 19430 RVA: 0x001F16F5 File Offset: 0x001EFAF5
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
