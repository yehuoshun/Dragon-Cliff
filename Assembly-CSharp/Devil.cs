using System;

// Token: 0x02000B31 RID: 2865
public class Devil : MinionUnitConfigurationBase
{
	// Token: 0x06004C4E RID: 19534 RVA: 0x001F193A File Offset: 0x001EFD3A
	public Devil()
	{
	}

	// Token: 0x17001061 RID: 4193
	// (get) Token: 0x06004C4F RID: 19535 RVA: 0x001F1942 File Offset: 0x001EFD42
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return UnitClass.Devil;
		}
	}

	// Token: 0x17001062 RID: 4194
	// (get) Token: 0x06004C50 RID: 19536 RVA: 0x001F1949 File Offset: 0x001EFD49
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return UnitClassStyle.PhysicalWarrior;
		}
	}
}
