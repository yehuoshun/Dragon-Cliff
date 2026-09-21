using System;

// Token: 0x02000AF5 RID: 2805
public class BlueGoblinWizard : MinionUnitConfigurationBase
{
	// Token: 0x06004B76 RID: 19318 RVA: 0x001F1232 File Offset: 0x001EF632
	public BlueGoblinWizard()
	{
	}

	// Token: 0x17000FEF RID: 4079
	// (get) Token: 0x06004B77 RID: 19319 RVA: 0x001F123A File Offset: 0x001EF63A
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.BlueGoblinWizard;
		}
	}

	// Token: 0x17000FF0 RID: 4080
	// (get) Token: 0x06004B78 RID: 19320 RVA: 0x001F1241 File Offset: 0x001EF641
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
