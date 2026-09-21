using System;

// Token: 0x02000B1E RID: 2846
public class ConjourerSpiritRedConfiguration : UnitConfigurationBase
{
	// Token: 0x06004C09 RID: 19465 RVA: 0x001F17A9 File Offset: 0x001EFBA9
	public ConjourerSpiritRedConfiguration()
	{
	}

	// Token: 0x17001037 RID: 4151
	// (get) Token: 0x06004C0A RID: 19466 RVA: 0x001F17B1 File Offset: 0x001EFBB1
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ConjourerSpiritRed;
		}
	}

	// Token: 0x17001038 RID: 4152
	// (get) Token: 0x06004C0B RID: 19467 RVA: 0x001F17B8 File Offset: 0x001EFBB8
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellKiller;
		}
	}
}
