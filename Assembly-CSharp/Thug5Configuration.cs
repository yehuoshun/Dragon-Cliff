using System;

// Token: 0x02000B1A RID: 2842
public class Thug5Configuration : MinionUnitConfigurationBase
{
	// Token: 0x06004BFD RID: 19453 RVA: 0x001F175E File Offset: 0x001EFB5E
	public Thug5Configuration()
	{
	}

	// Token: 0x1700102F RID: 4143
	// (get) Token: 0x06004BFE RID: 19454 RVA: 0x001F1766 File Offset: 0x001EFB66
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Thug5;
		}
	}

	// Token: 0x17001030 RID: 4144
	// (get) Token: 0x06004BFF RID: 19455 RVA: 0x001F176D File Offset: 0x001EFB6D
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalSupporter;
		}
	}
}
