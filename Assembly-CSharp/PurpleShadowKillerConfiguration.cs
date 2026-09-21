using System;

// Token: 0x02000B28 RID: 2856
public class PurpleShadowKillerConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C27 RID: 19495 RVA: 0x001F185F File Offset: 0x001EFC5F
	public PurpleShadowKillerConfiguration()
	{
	}

	// Token: 0x1700104B RID: 4171
	// (get) Token: 0x06004C28 RID: 19496 RVA: 0x001F1867 File Offset: 0x001EFC67
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleShadowKiller;
		}
	}

	// Token: 0x1700104C RID: 4172
	// (get) Token: 0x06004C29 RID: 19497 RVA: 0x001F186E File Offset: 0x001EFC6E
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
