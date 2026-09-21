using System;

// Token: 0x02000B0C RID: 2828
public class GreenBirdMonsterConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BD2 RID: 19410 RVA: 0x001F1678 File Offset: 0x001EFA78
	public GreenBirdMonsterConfiguration()
	{
	}

	// Token: 0x17001019 RID: 4121
	// (get) Token: 0x06004BD3 RID: 19411 RVA: 0x001F1680 File Offset: 0x001EFA80
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenBirdMonster;
		}
	}

	// Token: 0x1700101A RID: 4122
	// (get) Token: 0x06004BD4 RID: 19412 RVA: 0x001F1687 File Offset: 0x001EFA87
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
