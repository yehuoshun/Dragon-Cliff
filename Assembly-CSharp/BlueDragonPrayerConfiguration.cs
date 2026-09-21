using System;

// Token: 0x02000B20 RID: 2848
public class BlueDragonPrayerConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C0F RID: 19471 RVA: 0x001F17CD File Offset: 0x001EFBCD
	public BlueDragonPrayerConfiguration()
	{
	}

	// Token: 0x1700103B RID: 4155
	// (get) Token: 0x06004C10 RID: 19472 RVA: 0x001F17D5 File Offset: 0x001EFBD5
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueDragonPrayer;
		}
	}

	// Token: 0x1700103C RID: 4156
	// (get) Token: 0x06004C11 RID: 19473 RVA: 0x001F17DC File Offset: 0x001EFBDC
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.Healer;
		}
	}
}
