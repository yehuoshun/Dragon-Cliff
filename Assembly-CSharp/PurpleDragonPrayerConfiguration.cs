using System;

// Token: 0x02000B26 RID: 2854
public class PurpleDragonPrayerConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C21 RID: 19489 RVA: 0x001F183B File Offset: 0x001EFC3B
	public PurpleDragonPrayerConfiguration()
	{
	}

	// Token: 0x17001047 RID: 4167
	// (get) Token: 0x06004C22 RID: 19490 RVA: 0x001F1843 File Offset: 0x001EFC43
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleDragonPrayer;
		}
	}

	// Token: 0x17001048 RID: 4168
	// (get) Token: 0x06004C23 RID: 19491 RVA: 0x001F184A File Offset: 0x001EFC4A
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Protector;
		}
	}
}
