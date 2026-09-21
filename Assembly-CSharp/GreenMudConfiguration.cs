using System;

// Token: 0x02000B0E RID: 2830
public class GreenMudConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BD8 RID: 19416 RVA: 0x001F169C File Offset: 0x001EFA9C
	public GreenMudConfiguration()
	{
	}

	// Token: 0x1700101D RID: 4125
	// (get) Token: 0x06004BD9 RID: 19417 RVA: 0x001F16A4 File Offset: 0x001EFAA4
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenMud;
		}
	}

	// Token: 0x1700101E RID: 4126
	// (get) Token: 0x06004BDA RID: 19418 RVA: 0x001F16AB File Offset: 0x001EFAAB
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
