using System;

// Token: 0x02000A4F RID: 2639
public class OriginalGhoul : MinionUnitConfigurationBase
{
	// Token: 0x060047CD RID: 18381 RVA: 0x001DF027 File Offset: 0x001DD427
	public OriginalGhoul()
	{
	}

	// Token: 0x17000E1B RID: 3611
	// (get) Token: 0x060047CE RID: 18382 RVA: 0x001DF02F File Offset: 0x001DD42F
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Ghoul;
		}
	}

	// Token: 0x17000E1C RID: 3612
	// (get) Token: 0x060047CF RID: 18383 RVA: 0x001DF036 File Offset: 0x001DD436
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
