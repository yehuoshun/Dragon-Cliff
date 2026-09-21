using System;

// Token: 0x02000B30 RID: 2864
public class BlueSharpTeethConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C4B RID: 19531 RVA: 0x001F1928 File Offset: 0x001EFD28
	public BlueSharpTeethConfiguration()
	{
	}

	// Token: 0x1700105F RID: 4191
	// (get) Token: 0x06004C4C RID: 19532 RVA: 0x001F1930 File Offset: 0x001EFD30
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueSharpTeeth;
		}
	}

	// Token: 0x17001060 RID: 4192
	// (get) Token: 0x06004C4D RID: 19533 RVA: 0x001F1937 File Offset: 0x001EFD37
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
