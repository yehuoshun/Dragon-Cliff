using System;

// Token: 0x02000B22 RID: 2850
public class GreenDragonPrayerConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C15 RID: 19477 RVA: 0x001F17F2 File Offset: 0x001EFBF2
	public GreenDragonPrayerConfiguration()
	{
	}

	// Token: 0x1700103F RID: 4159
	// (get) Token: 0x06004C16 RID: 19478 RVA: 0x001F17FA File Offset: 0x001EFBFA
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenDragonPrayer;
		}
	}

	// Token: 0x17001040 RID: 4160
	// (get) Token: 0x06004C17 RID: 19479 RVA: 0x001F1801 File Offset: 0x001EFC01
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}
}
