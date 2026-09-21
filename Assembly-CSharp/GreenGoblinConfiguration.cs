using System;

// Token: 0x02000A4B RID: 2635
public class GreenGoblinConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x060047C1 RID: 18369 RVA: 0x001DEFDF File Offset: 0x001DD3DF
	public GreenGoblinConfiguration()
	{
	}

	// Token: 0x17000E13 RID: 3603
	// (get) Token: 0x060047C2 RID: 18370 RVA: 0x001DEFE7 File Offset: 0x001DD3E7
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenGoblin;
		}
	}

	// Token: 0x17000E14 RID: 3604
	// (get) Token: 0x060047C3 RID: 18371 RVA: 0x001DEFEE File Offset: 0x001DD3EE
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
