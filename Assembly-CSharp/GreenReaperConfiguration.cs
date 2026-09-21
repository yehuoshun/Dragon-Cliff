using System;

// Token: 0x02000B23 RID: 2851
public class GreenReaperConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C18 RID: 19480 RVA: 0x001F1805 File Offset: 0x001EFC05
	public GreenReaperConfiguration()
	{
	}

	// Token: 0x17001041 RID: 4161
	// (get) Token: 0x06004C19 RID: 19481 RVA: 0x001F180D File Offset: 0x001EFC0D
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.GreenReaper;
		}
	}

	// Token: 0x17001042 RID: 4162
	// (get) Token: 0x06004C1A RID: 19482 RVA: 0x001F1814 File Offset: 0x001EFC14
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
