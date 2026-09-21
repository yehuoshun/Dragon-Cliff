using System;

// Token: 0x02000A4C RID: 2636
public class PurpleSharpTeethConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x060047C4 RID: 18372 RVA: 0x001DEFF1 File Offset: 0x001DD3F1
	public PurpleSharpTeethConfiguration()
	{
	}

	// Token: 0x17000E15 RID: 3605
	// (get) Token: 0x060047C5 RID: 18373 RVA: 0x001DEFF9 File Offset: 0x001DD3F9
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleSharpTeeth;
		}
	}

	// Token: 0x17000E16 RID: 3606
	// (get) Token: 0x060047C6 RID: 18374 RVA: 0x001DF000 File Offset: 0x001DD400
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalKiller;
		}
	}
}
