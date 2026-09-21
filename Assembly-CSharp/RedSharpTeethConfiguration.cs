using System;

// Token: 0x02000AB0 RID: 2736
public class RedSharpTeethConfiguration : MiniBossUnitConfigurationBase
{
	// Token: 0x060049F6 RID: 18934 RVA: 0x001E811E File Offset: 0x001E651E
	public RedSharpTeethConfiguration()
	{
	}

	// Token: 0x17000F71 RID: 3953
	// (get) Token: 0x060049F7 RID: 18935 RVA: 0x001E8126 File Offset: 0x001E6526
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.RedSharpTeeth;
		}
	}

	// Token: 0x17000F72 RID: 3954
	// (get) Token: 0x060049F8 RID: 18936 RVA: 0x001E812D File Offset: 0x001E652D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
