using System;

// Token: 0x02000B0F RID: 2831
public class GreenShadowBatConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BDB RID: 19419 RVA: 0x001F16AE File Offset: 0x001EFAAE
	public GreenShadowBatConfiguration()
	{
	}

	// Token: 0x1700101F RID: 4127
	// (get) Token: 0x06004BDC RID: 19420 RVA: 0x001F16B6 File Offset: 0x001EFAB6
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenShadowBat;
		}
	}

	// Token: 0x17001020 RID: 4128
	// (get) Token: 0x06004BDD RID: 19421 RVA: 0x001F16BD File Offset: 0x001EFABD
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalDefender;
		}
	}
}
