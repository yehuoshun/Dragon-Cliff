using System;

// Token: 0x02000B25 RID: 2853
public class PurpleArcherConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C1E RID: 19486 RVA: 0x001F1829 File Offset: 0x001EFC29
	public PurpleArcherConfiguration()
	{
	}

	// Token: 0x17001045 RID: 4165
	// (get) Token: 0x06004C1F RID: 19487 RVA: 0x001F1831 File Offset: 0x001EFC31
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleArcher;
		}
	}

	// Token: 0x17001046 RID: 4166
	// (get) Token: 0x06004C20 RID: 19488 RVA: 0x001F1838 File Offset: 0x001EFC38
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
