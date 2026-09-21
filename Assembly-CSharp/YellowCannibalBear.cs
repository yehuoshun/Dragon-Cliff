using System;

// Token: 0x02000B06 RID: 2822
public class YellowCannibalBear : MinionUnitConfigurationBase
{
	// Token: 0x06004BAE RID: 19374 RVA: 0x001F1616 File Offset: 0x001EFA16
	public YellowCannibalBear()
	{
	}

	// Token: 0x17001011 RID: 4113
	// (get) Token: 0x06004BAF RID: 19375 RVA: 0x001F1631 File Offset: 0x001EFA31
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17001012 RID: 4114
	// (get) Token: 0x06004BB0 RID: 19376 RVA: 0x001F1639 File Offset: 0x001EFA39
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003ACA RID: 15050
	private readonly UnitClass _correspondingUnitClass = UnitClass.YellowCannibalBear;

	// Token: 0x04003ACB RID: 15051
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.SpellSupporter;
}
