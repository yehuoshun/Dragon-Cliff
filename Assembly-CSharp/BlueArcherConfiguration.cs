using System;

// Token: 0x02000B1F RID: 2847
public class BlueArcherConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C0C RID: 19468 RVA: 0x001F17BB File Offset: 0x001EFBBB
	public BlueArcherConfiguration()
	{
	}

	// Token: 0x17001039 RID: 4153
	// (get) Token: 0x06004C0D RID: 19469 RVA: 0x001F17C3 File Offset: 0x001EFBC3
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueArcher;
		}
	}

	// Token: 0x1700103A RID: 4154
	// (get) Token: 0x06004C0E RID: 19470 RVA: 0x001F17CA File Offset: 0x001EFBCA
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
