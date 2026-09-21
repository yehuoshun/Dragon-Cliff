using System;

// Token: 0x02000B16 RID: 2838
public class Thug1Configuration : MinionUnitConfigurationBase
{
	// Token: 0x06004BF1 RID: 19441 RVA: 0x001F1716 File Offset: 0x001EFB16
	public Thug1Configuration()
	{
	}

	// Token: 0x17001027 RID: 4135
	// (get) Token: 0x06004BF2 RID: 19442 RVA: 0x001F171E File Offset: 0x001EFB1E
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Thug1;
		}
	}

	// Token: 0x17001028 RID: 4136
	// (get) Token: 0x06004BF3 RID: 19443 RVA: 0x001F1725 File Offset: 0x001EFB25
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
