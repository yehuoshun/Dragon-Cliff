using System;

// Token: 0x02000B11 RID: 2833
public class YellowMudConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004BE1 RID: 19425 RVA: 0x001F16D3 File Offset: 0x001EFAD3
	public YellowMudConfiguration()
	{
	}

	// Token: 0x17001023 RID: 4131
	// (get) Token: 0x06004BE2 RID: 19426 RVA: 0x001F16DB File Offset: 0x001EFADB
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.YellowMud;
		}
	}

	// Token: 0x17001024 RID: 4132
	// (get) Token: 0x06004BE3 RID: 19427 RVA: 0x001F16E2 File Offset: 0x001EFAE2
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellSupporter;
		}
	}
}
