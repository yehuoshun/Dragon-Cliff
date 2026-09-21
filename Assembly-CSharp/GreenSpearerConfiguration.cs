using System;

// Token: 0x02000B24 RID: 2852
public class GreenSpearerConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C1B RID: 19483 RVA: 0x001F1817 File Offset: 0x001EFC17
	public GreenSpearerConfiguration()
	{
	}

	// Token: 0x17001043 RID: 4163
	// (get) Token: 0x06004C1C RID: 19484 RVA: 0x001F181F File Offset: 0x001EFC1F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenSpearer;
		}
	}

	// Token: 0x17001044 RID: 4164
	// (get) Token: 0x06004C1D RID: 19485 RVA: 0x001F1826 File Offset: 0x001EFC26
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
