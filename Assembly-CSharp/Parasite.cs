using System;

// Token: 0x02000AE7 RID: 2791
public class Parasite : MinionUnitConfigurationBase
{
	// Token: 0x06004B36 RID: 19254 RVA: 0x001EBD51 File Offset: 0x001EA151
	public Parasite()
	{
	}

	// Token: 0x17000FD7 RID: 4055
	// (get) Token: 0x06004B37 RID: 19255 RVA: 0x001EBD59 File Offset: 0x001EA159
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Parasite;
		}
	}

	// Token: 0x17000FD8 RID: 4056
	// (get) Token: 0x06004B38 RID: 19256 RVA: 0x001EBD60 File Offset: 0x001EA160
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
