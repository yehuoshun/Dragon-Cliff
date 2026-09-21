using System;

// Token: 0x02000B27 RID: 2855
public class PurpleReaperConfiguration : MinionUnitConfigurationBase
{
	// Token: 0x06004C24 RID: 19492 RVA: 0x001F184D File Offset: 0x001EFC4D
	public PurpleReaperConfiguration()
	{
	}

	// Token: 0x17001049 RID: 4169
	// (get) Token: 0x06004C25 RID: 19493 RVA: 0x001F1855 File Offset: 0x001EFC55
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.PurpleReaper;
		}
	}

	// Token: 0x1700104A RID: 4170
	// (get) Token: 0x06004C26 RID: 19494 RVA: 0x001F185C File Offset: 0x001EFC5C
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
