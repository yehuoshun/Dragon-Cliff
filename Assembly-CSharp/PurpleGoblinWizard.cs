using System;

// Token: 0x02000AFB RID: 2811
public class PurpleGoblinWizard : MinionUnitConfigurationBase
{
	// Token: 0x06004B88 RID: 19336 RVA: 0x001F12B8 File Offset: 0x001EF6B8
	public PurpleGoblinWizard()
	{
	}

	// Token: 0x17000FFB RID: 4091
	// (get) Token: 0x06004B89 RID: 19337 RVA: 0x001F12C0 File Offset: 0x001EF6C0
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleGoblinWizard;
		}
	}

	// Token: 0x17000FFC RID: 4092
	// (get) Token: 0x06004B8A RID: 19338 RVA: 0x001F12C7 File Offset: 0x001EF6C7
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
