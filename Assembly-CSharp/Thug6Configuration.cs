using System;

// Token: 0x02000B1B RID: 2843
public class Thug6Configuration : MinionUnitConfigurationBase
{
	// Token: 0x06004C00 RID: 19456 RVA: 0x001F1771 File Offset: 0x001EFB71
	public Thug6Configuration()
	{
	}

	// Token: 0x17001031 RID: 4145
	// (get) Token: 0x06004C01 RID: 19457 RVA: 0x001F1779 File Offset: 0x001EFB79
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Thug6;
		}
	}

	// Token: 0x17001032 RID: 4146
	// (get) Token: 0x06004C02 RID: 19458 RVA: 0x001F1780 File Offset: 0x001EFB80
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}
}
