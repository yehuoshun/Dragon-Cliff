using System;

// Token: 0x02000A5A RID: 2650
public class Werewolf : MinionUnitConfigurationBase
{
	// Token: 0x060047EE RID: 18414 RVA: 0x001DF108 File Offset: 0x001DD508
	public Werewolf()
	{
	}

	// Token: 0x17000E31 RID: 3633
	// (get) Token: 0x060047EF RID: 18415 RVA: 0x001DF110 File Offset: 0x001DD510
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Werewolf;
		}
	}

	// Token: 0x17000E32 RID: 3634
	// (get) Token: 0x060047F0 RID: 18416 RVA: 0x001DF117 File Offset: 0x001DD517
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
