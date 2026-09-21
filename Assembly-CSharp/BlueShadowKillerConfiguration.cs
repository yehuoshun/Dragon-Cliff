using System;

// Token: 0x02000B21 RID: 2849
public class BlueShadowKillerConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C12 RID: 19474 RVA: 0x001F17E0 File Offset: 0x001EFBE0
	public BlueShadowKillerConfiguration()
	{
	}

	// Token: 0x1700103D RID: 4157
	// (get) Token: 0x06004C13 RID: 19475 RVA: 0x001F17E8 File Offset: 0x001EFBE8
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueShadowKiller;
		}
	}

	// Token: 0x1700103E RID: 4158
	// (get) Token: 0x06004C14 RID: 19476 RVA: 0x001F17EF File Offset: 0x001EFBEF
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
