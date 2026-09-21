using System;

// Token: 0x02000B0B RID: 2827
public class BlueShadowBatConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BCF RID: 19407 RVA: 0x001F1666 File Offset: 0x001EFA66
	public BlueShadowBatConfiguration()
	{
	}

	// Token: 0x17001017 RID: 4119
	// (get) Token: 0x06004BD0 RID: 19408 RVA: 0x001F166E File Offset: 0x001EFA6E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueShadowBat;
		}
	}

	// Token: 0x17001018 RID: 4120
	// (get) Token: 0x06004BD1 RID: 19409 RVA: 0x001F1675 File Offset: 0x001EFA75
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
