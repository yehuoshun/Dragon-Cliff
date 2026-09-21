using System;

// Token: 0x02000B17 RID: 2839
public class Thug2Configuration : MinionUnitConfigurationBase
{
	// Token: 0x06004BF4 RID: 19444 RVA: 0x001F1728 File Offset: 0x001EFB28
	public Thug2Configuration()
	{
	}

	// Token: 0x17001029 RID: 4137
	// (get) Token: 0x06004BF5 RID: 19445 RVA: 0x001F1730 File Offset: 0x001EFB30
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Thug2;
		}
	}

	// Token: 0x1700102A RID: 4138
	// (get) Token: 0x06004BF6 RID: 19446 RVA: 0x001F1737 File Offset: 0x001EFB37
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.SpellWarrior;
		}
	}
}
