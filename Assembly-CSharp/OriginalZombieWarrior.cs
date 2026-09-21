using System;

// Token: 0x02000A56 RID: 2646
public class OriginalZombieWarrior : MinionUnitConfigurationBase
{
	// Token: 0x060047E2 RID: 18402 RVA: 0x001DF0A7 File Offset: 0x001DD4A7
	public OriginalZombieWarrior()
	{
	}

	// Token: 0x17000E29 RID: 3625
	// (get) Token: 0x060047E3 RID: 18403 RVA: 0x001DF0AF File Offset: 0x001DD4AF
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.ZombieWarrior;
		}
	}

	// Token: 0x17000E2A RID: 3626
	// (get) Token: 0x060047E4 RID: 18404 RVA: 0x001DF0B6 File Offset: 0x001DD4B6
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
