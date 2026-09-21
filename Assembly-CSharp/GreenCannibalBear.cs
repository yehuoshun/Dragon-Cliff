using System;

// Token: 0x02000B00 RID: 2816
public class GreenCannibalBear : MinionUnitConfigurationBase
{
	// Token: 0x06004B98 RID: 19352 RVA: 0x001F1398 File Offset: 0x001EF798
	public GreenCannibalBear()
	{
	}

	// Token: 0x17001005 RID: 4101
	// (get) Token: 0x06004B99 RID: 19353 RVA: 0x001F13B2 File Offset: 0x001EF7B2
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17001006 RID: 4102
	// (get) Token: 0x06004B9A RID: 19354 RVA: 0x001F13BA File Offset: 0x001EF7BA
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003AC2 RID: 15042
	private readonly UnitClass _correspondingUnitClass = UnitClass.GreenCannibalBear;

	// Token: 0x04003AC3 RID: 15043
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.PhysicalKiller;
}
